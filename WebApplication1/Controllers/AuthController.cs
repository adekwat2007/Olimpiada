using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Data; // Добавьте этот using
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SignInController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SignInController> _logger;

        public SignInController(
            ApiDbContext context, // Измените AppDbContext на ApiDbContext
            IConfiguration configuration,
            ILogger<SignInController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserLoginRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest(new ErrorResponse(
                        "Email и пароль обязательны",
                        "1001"));
                }

                // Используем Employees вместо Employee
                var employee = await _context.Employees
                    .Include(e => e.Position)
                    .Include(e => e.Department)
                    .FirstOrDefaultAsync(e => e.Email == request.Email);

                if (employee == null || employee.Password != request.Password)
                {
                    return StatusCode(403, new ErrorResponse(
                        "Неверные учетные данные",
                        "1002"));
                }

                var token = GenerateJwtToken(employee);

                _logger.LogInformation("Успешный вход: {Email}", request.Email);

                return Ok(new
                {
                    token = token,
                    user = new
                    {
                        id = employee.PersonalID,
                        name = employee.FullName,
                        email = employee.Email,
                        position = employee.Position?.PositionName,
                        department = employee.Department?.DepartmentName
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при входе");
                return StatusCode(500, new ErrorResponse(
                    "Внутренняя ошибка сервера",
                    "1003"));
            }
        }

        private string GenerateJwtToken(Employee employee)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]
                ?? "YourSuperSecretKeyForJWTTokenGeneration2024!Minimum32CharactersLong!");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, employee.PersonalID.ToString()),
                new Claim(ClaimTypes.Email, employee.Email),
                new Claim(ClaimTypes.Name, employee.FullName),
                new Claim("Position", employee.Position?.PositionName ?? ""),
                new Claim("Department", employee.Department?.DepartmentName ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(24),
                Issuer = _configuration["Jwt:Issuer"] ?? "WebApplication1",
                Audience = _configuration["Jwt:Audience"] ?? "MobileApp",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
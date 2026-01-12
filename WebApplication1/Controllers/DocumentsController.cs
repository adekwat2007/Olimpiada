using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data; // Добавьте этот using
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        private readonly ApiDbContext _context; // Измените AppDbContext на ApiDbContext
        private readonly ILogger<DocumentsController> _logger;

        public DocumentsController(ApiDbContext context, ILogger<DocumentsController> logger) // Измените тип
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            try
            {
                var documents = await _context.Documents
                    .Include(d => d.Author)
                        .ThenInclude(a => a.Position)
                    .Include(d => d.Comments)
                    .OrderByDescending(d => d.DateUpdated)
                    .Select(d => new DocumentResponse
                    {
                        Id = d.Id,
                        Title = d.Title,
                        DateCreated = d.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                        DateUpdated = d.DateUpdated.ToString("yyyy-MM-dd HH:mm:ss"),
                        Category = d.Category,
                        HasComments = d.Comments.Any(),
                        Author = new AuthorInfo
                        {
                            Name = d.Author != null ? d.Author.FullName : "Неизвестный",
                            Position = d.Author != null && d.Author.Position != null
                                ? d.Author.Position.PositionName
                                : ""
                        }
                    })
                    .ToListAsync();

                if (!documents.Any())
                {
                    return NotFound(new ErrorResponse(
                        "Документы не найдены",
                        "2001"));
                }

                return Ok(documents);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении документов");
                return StatusCode(500, new ErrorResponse(
                    "Внутренняя ошибка сервера",
                    "2002"));
            }
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data; // Добавьте этот using
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/Document/{documentId}/[controller]")]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ApiDbContext _context; // Измените AppDbContext на ApiDbContext
        private readonly ILogger<CommentsController> _logger;

        public CommentsController(ApiDbContext context, ILogger<CommentsController> logger) // Измените тип
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments(int documentId)
        {
            try
            {
                var documentExists = await _context.Documents
                    .AnyAsync(d => d.Id == documentId);

                if (!documentExists)
                {
                    return NotFound(new ErrorResponse(
                        $"Документ с ID {documentId} не найден",
                        "3001"));
                }

                var comments = await _context.Comments
                    .Where(c => c.DocumentId == documentId)
                    .Include(c => c.Author)
                        .ThenInclude(a => a.Position)
                    .OrderBy(c => c.DateCreated)
                    .Select(c => new CommentResponse
                    {
                        Id = c.Id,
                        DocumentId = c.DocumentId,
                        Text = c.Text,
                        DateCreated = c.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                        DateUpdated = c.DateUpdated.ToString("yyyy-MM-dd HH:mm:ss"),
                        Author = new AuthorInfo
                        {
                            Name = c.Author != null ? c.Author.FullName : "Неизвестный",
                            Position = c.Author != null && c.Author.Position != null
                                ? c.Author.Position.PositionName
                                : ""
                        }
                    })
                    .ToListAsync();

                if (!comments.Any())
                {
                    return NotFound(new ErrorResponse(
                        $"Не найдены комментарии для документа с ID {documentId}",
                        "2344"));
                }

                return Ok(comments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении комментариев");
                return StatusCode(500, new ErrorResponse(
                    "Внутренняя ошибка сервера",
                    "3002"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int documentId, [FromBody] CommentCreateRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Text))
                {
                    return BadRequest(new ErrorResponse(
                        "Текст комментария обязателен",
                        "4001"));
                }

                var document = await _context.Documents.FindAsync(documentId);
                if (document == null)
                {
                    return NotFound(new ErrorResponse(
                        $"Документ с ID {documentId} не найден",
                        "4002"));
                }

                var userId = GetCurrentUserId();
                // Используем Employees вместо Employee
                var user = await _context.Employees.FindAsync(userId);
                if (user == null)
                {
                    return StatusCode(403, new ErrorResponse(
                        "Пользователь не найден",
                        "4003"));
                }

                var comment = new Comment
                {
                    DocumentId = documentId,
                    AuthorId = userId,
                    Text = request.Text,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                };

                _context.Comments.Add(comment);
                document.HasComments = true;
                document.DateUpdated = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                var response = new CommentResponse
                {
                    Id = comment.Id,
                    DocumentId = comment.DocumentId,
                    Text = comment.Text,
                    DateCreated = comment.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                    DateUpdated = comment.DateUpdated.ToString("yyyy-MM-dd HH:mm:ss"),
                    Author = new AuthorInfo
                    {
                        Name = user.FullName,
                        Position = user.Position != null ? user.Position.PositionName : ""
                    }
                };

                return CreatedAtAction(
                    nameof(GetComments),
                    new { documentId = documentId },
                    response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при добавлении комментария");
                return StatusCode(500, new ErrorResponse(
                    "Внутренняя ошибка сервера",
                    "4005"));
            }
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim != null && int.TryParse(userIdClaim.Value, out var userId)
                ? userId
                : 0;
        }
    }
}
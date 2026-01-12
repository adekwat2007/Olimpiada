// Program.cs
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication1.Data; // Этот using должен работать
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Настройка базы данных
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=(localdb)\\mssqllocaldb;Database=HRManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;";

// Регистрируем ApiDbContext
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(connectionString));

// JWT аутентификация
var key = Encoding.ASCII.GetBytes(
    builder.Configuration["Jwt:Key"]
    ?? "YourSuperSecretKeyForJWTTokenGeneration2024!Minimum32CharactersLong!");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Инициализация БД
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApiDbContext>();

    try
    {
        context.Database.EnsureCreated();
        await SeedTestData(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка инициализации БД: {ex.Message}");
    }
}

app.Run();

async Task SeedTestData(ApiDbContext context)
{
    // Создаем тестового сотрудника если нет
    if (!await context.Employees.AnyAsync())
    {
        var employee = new Employee
        {
            FullName = "Администратор",
            Email = "admin@company.com",
            Password = "admin123",
            BirthDate = new DateTime(1990, 1, 1),
            DepartmentID = 1,
            PositionID = 1
        };
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
    }

    // Создаем тестовые документы если нет
    if (!await context.Documents.AnyAsync())
    {
        var document = new Document
        {
            Title = "Тестовый документ",
            Category = "Тест",
            DateCreated = DateTime.UtcNow,
            DateUpdated = DateTime.UtcNow,
            HasComments = true,
            AuthorId = 1
        };
        context.Documents.Add(document);
        await context.SaveChangesAsync();

        var comment = new Comment
        {
            DocumentId = 1,
            AuthorId = 1,
            Text = "Первый комментарий",
            DateCreated = DateTime.UtcNow,
            DateUpdated = DateTime.UtcNow
        };
        context.Comments.Add(comment);
        await context.SaveChangesAsync();
    }
}
// AppDbContext.cs (исправленная версия)
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ТОЛЬКО те таблицы, которые действительно нужны
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Comment> Comments { get; set; }

        // УБРАТЬ все остальные DbSet если они не нужны для API
        // public DbSet<Position> Positions { get; set; } // Убрать если не нужно
        // public DbSet<Department> Departments { get; set; } // Убрать если не нужно
        // ... и все остальные HR таблицы

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Указываем таблицы (опционально)
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Document>().ToTable("Documents");
            modelBuilder.Entity<Comment>().ToTable("Comments");

            modelBuilder.Entity<EventResponsible>()
                .HasKey(er => new { er.EventID, er.ResponsibleEmployeeID });

            modelBuilder.Entity<EventResponsible>()
                .HasOne(er => er.Event)
                .WithMany()
                .HasForeignKey(er => er.EventID);

            modelBuilder.Entity<EventResponsible>()
                .HasOne(er => er.ResponsibleEmployee)
                .WithMany()
                .HasForeignKey(er => er.ResponsibleEmployeeID);

            // Связи
            ConfigureRelations(modelBuilder);
        }

        private void ConfigureRelations(ModelBuilder modelBuilder)
        {
            // Document - Employee (Author)
            modelBuilder.Entity<Document>()
                .HasOne(d => d.Author)
                .WithMany()
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comment - Document
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Document)
                .WithMany(d => d.Comments)
                .HasForeignKey(c => c.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Comment - Employee (Author)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
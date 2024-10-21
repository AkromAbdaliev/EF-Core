using System;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=CYBERNETIC\\SQLEXPRESS;Initial Catalog=EFCoreDb;Integrated Security=True;TrustServerCertificate=True";
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentProject>()
            .HasKey(std => new { std.StudentId, std.ProjectId });

        modelBuilder.Entity<StudentProject>()
            .HasOne(std => std.Student)
            .WithMany(s => s.StudentProjects)
            .HasForeignKey(std => std.StudentId);

        modelBuilder.Entity<StudentProject>()
            .HasOne(std => std.Project)
            .WithMany(s => s.StudentProjects)
            .HasForeignKey(std => std.ProjectId);
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Advisor> Advisors { get; set; }
    public DbSet<StudentDetails> StudentDetails { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<StudentProject> StudentProjects { get; set; }

}

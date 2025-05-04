using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeFilesApp.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<FileRecord> FileRecords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)        => optionsBuilder.UseSqlServer("Server=DESKTOP-M0EOIR1;Database=EmployeeFilesDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileRecord>(entity =>
        {
            entity.HasOne(d => d.Department).WithMany(p => p.FileRecords).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

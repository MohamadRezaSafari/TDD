﻿using Microsoft.EntityFrameworkCore;

namespace WebApi;

public sealed class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasKey(e => e.Guid);
    }

    public DbSet<Employee> Employees { get; set; }
}

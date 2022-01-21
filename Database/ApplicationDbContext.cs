using ConsoleApp14.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp14.Database
{
  public class ApplicationDbContext : DbContext
  {

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer("Server=.;Database=ExampleRelationships;Trusted_Connection=True;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Order>()
        .HasKey(o => new { o.ProductId, o.UserId });

      modelBuilder.Entity<Order>()
        .HasOne(x=>x.Product)
        .WithMany(z => z.Orders)
        .HasForeignKey(sc => sc.ProductId);

      modelBuilder.Entity<Order>()
        .HasOne(x => x.User)
        .WithMany(z => z.Orders)
        .HasForeignKey(sc => sc.UserId);
    }
  }
}

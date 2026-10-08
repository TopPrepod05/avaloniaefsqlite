using AvaloniaApplication29.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace AvaloniaApplication29;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlite($"Data Source={AppContext.BaseDirectory}/app.db");
    }
}
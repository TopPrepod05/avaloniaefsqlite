using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaApplication29.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication29.Repositories;

public class UserRepository(IDbContextFactory<AppDbContext> factory) : IUserRepository
{
    public async Task AddUserAsync(User user)
    {
        using var db = factory.CreateDbContext();
        await db.AddAsync(user);
        await db.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User? user)
    {
        using var db = factory.CreateDbContext();
        if (user != null)
        {
            db.Remove(user);
            await db.SaveChangesAsync();
        }
    }

    public async Task<List<User>> GetUsersAsync()
    {
        using var db = factory.CreateDbContext();
        var users = await db.Users.ToListAsync();
        return users;
    }
}

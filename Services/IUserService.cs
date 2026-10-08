using AvaloniaApplication29.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaloniaApplication29.Services;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task AddAsync(string login, string email);
    Task DeleteAsync(User? user);
}

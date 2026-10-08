using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using AvaloniaApplication29.Models;
using AvaloniaApplication29;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication29.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _login = "";

    [ObservableProperty]
    private string _email = "";

    public ObservableCollection<User> Users { get; set; } = [];

    public MainViewModel() { _ = LoadUsersAsync(); }

    private async Task LoadUsersAsync()
    {
        using var db = new AppDbContext();
        var urs = await db.Users.ToListAsync();
        Users.Clear();
        foreach (var u in urs) Users.Add(u);
    }

    [RelayCommand]
    private async Task AddUser()
    {
        using var db = new AppDbContext();
        var newUser = new User { Login = this.Login, Email = this.Email };
        _ = db.Users.AddAsync(newUser);
        _ = db.SaveChangesAsync();
        Users.Add(newUser);
    }
}

using CSCI3110AjaxIntro.Models.Entities;

namespace CSCI3110AjaxIntro.Services;

public class DbUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public DbUserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<User> CreateAsync(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public IQueryable<User> ReadAll()
    {
        return _db.Users;
    }
}


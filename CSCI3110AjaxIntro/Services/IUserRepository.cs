using CSCI3110AjaxIntro.Models.Entities;

namespace CSCI3110AjaxIntro.Services;

public interface IUserRepository
{
    IQueryable<User> ReadAll();
    Task<User> CreateAsync(User user);
}

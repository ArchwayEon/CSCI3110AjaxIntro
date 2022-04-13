using CSCI3110AjaxIntro.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSCI3110AjaxIntro.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
}


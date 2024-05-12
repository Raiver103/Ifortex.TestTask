using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserSurvice : IUserService
    {
        private ApplicationDbContext context;
        public UserSurvice(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<User> GetUser()
        {
            return await context.Users.FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }
    }
}

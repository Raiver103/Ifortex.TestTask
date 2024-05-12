using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserSurvice : IUserService
    {
        private ApplicationDbContext _context;
        public UserSurvice(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser()
        {
            return await _context.Orders
            .Where(o => o.CreatedAt.Year == 2003 && o.Status == OrderStatus.Delivered)
            .GroupBy(o => o.UserId)
            .OrderByDescending(g => g.Sum(o => o.Price * o.Quantity))
            .Select(g => g.FirstOrDefault().User)
            .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Orders
            .Where(o => o.CreatedAt.Year == 2010 && o.Status == OrderStatus.Paid)
            .Select(o => o.User)
            .Distinct()
            .ToListAsync();
        }
    }
}

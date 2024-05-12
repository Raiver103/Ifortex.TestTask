using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext context;
        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Order> GetOrder()
        {
            return await context.Orders.FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await context.Orders.ToListAsync();
        }
    }
}

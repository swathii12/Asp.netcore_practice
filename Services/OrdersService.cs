using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.netcore_practice.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrdersByUserId(string userId)
        {
            var orders = _context.Orders.Include(n => n.Items).ThenInclude(n => n.movie).Where(n => n.UserId == userId).ToList();
            return orders;
        }

      

        public void StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };

            _context.Orders.Add(order);
            _context.SaveChanges();


            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    quantity = item.quantity,
                    MovieId = item.Movie.MovieId,
                    OrderId = order.OrderId,
                    Price = item.Movie.Price
                };

                _context.OrderItems.Add(orderItem);
            }
            _context.SaveChanges();

        }
    }
}

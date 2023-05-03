using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Asp.netcore_practice.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public OrdersService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Order> GetOrdersByUserIdAndRole(string userId, string UserRole)
        {
            var orders = _context.Orders.Include(n => n.Items).ThenInclude(n => n.movie).Include(n=>n.User).ToList();

            if (UserRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

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

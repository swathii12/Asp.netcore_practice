using Asp.netcore_practice.Models;

namespace Asp.netcore_practice.Services
{
    public interface IOrdersService
    {
        void StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        List<Order> GetOrdersByUserId(string id);
    }
}

using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IOrderActionService
    {
         Movie AddToShoppingCart(int id);
         ShoppingCartViewModel ShoppingCart();

        void AddShoppingCart(ShoppingViewModel model);

        void RemoveFromShoppingCart(int id);
    }
}

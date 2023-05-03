using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IShoppingCartService
    {
        void AddItem(Movie movie, int shoppingCartId);
        void RemoveItemFromCart(Movie movie, int ShoppingCartId);
        List<ShoppingCartItem> GetShoppingCartItems(int shoppingCartId);
        double ShoppingCartTotal(int shoppingCartId);
       
        public void ClearShoppingCart(int shoppingCartId);
    }
}

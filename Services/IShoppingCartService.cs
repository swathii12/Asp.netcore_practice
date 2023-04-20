using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IShoppingCartService
    {
        public void AddItem(Movie movie);
        public void RemoveItemFromCart(Movie movie);
        public List<ShoppingCartItem> GetShoppingCartItems();
        public double ShoppingCartTotal();
        ShoppingCart GetById(int id);
        void ClearShoppingCart();
    }
}

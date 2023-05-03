using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;

namespace Asp.netcore_practice.Services
{
    public interface IOrderActionService
    {
        Movie AddToShoppingCart(AddMovieViewModel model);
        ShoppingCartViewModel ShoppingCart(int shoppingCartId);

        void AddShoppingCart();

        public void RemoveFromShoppingCart(AddMovieViewModel model);
    }
}

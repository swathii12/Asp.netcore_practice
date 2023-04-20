using Asp.netcore_practice.Context;
using Asp.netcore_practice.Migrations;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Asp.netcore_practice.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;
        private readonly IMapper _mapper;

        
        
        public ShoppingCartService(AppDbContext context,ShoppingCart shoppingCart, IMapper mapper)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _mapper = mapper;
        }

        

        public void AddItem(Movie movie)
        {
            _shoppingCart.ShoppingCartId = 1;
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.MovieId == movie.MovieId && n.ShoppingCartId == _shoppingCart.ShoppingCartId);
            //var efg = _mapper.Map<ShoppingCartItem, ShoppingCartItemViewModel>(shoppingCartItem);

            if (shoppingCartItem == null)
            {


                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = 1,
                    Movie = movie,
                   // MovieId = movie.MovieId,
                    quantity = 1
                };
                //var abc = _mapper.Map<ShoppingCartItemViewModel, ShoppingCartItem>(efg);

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.quantity++;
            }
            _context.SaveChanges();
        }


        public void RemoveItemFromCart(Movie movie)
        {
            _shoppingCart.ShoppingCartId = 1;
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.MovieId == movie.MovieId && n.ShoppingCartId == _shoppingCart.ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.quantity > 1)
                {
                    shoppingCartItem.quantity--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }

            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
           var a= _shoppingCart.ShoppingCartId = 1;
          /* var b= _shoppingCart.ShoppingCartItems ?? (*/
           var b= _shoppingCart.ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == a
            /*_shoppingCart.ShoppingCartId*/).Include(n => n.Movie).ToList();
            return b;
        }

        public double ShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == _shoppingCart.ShoppingCartId)
                .Select(n => n.Movie.Price * n.quantity).Sum();

            return total;
        }


       public ShoppingCart GetById (int id)
        {
                     

            var item = _context.ShoppingCart.Where(n => n.ShoppingCartId == id).Select(cart => new ShoppingCart()
            {
                ShoppingCartId = cart.ShoppingCartId,
                ShoppingCartItems = _context.ShoppingCartItems.ToList()
            }).FirstOrDefault();

            return item;
            

        }


        public void ClearShoppingCart()
        {
           var cartId= _shoppingCart.ShoppingCartId = 1;

            var items = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == cartId).ToList();
            _context.ShoppingCartItems.RemoveRange(items);
            _context.SaveChanges();


        }

    }
}

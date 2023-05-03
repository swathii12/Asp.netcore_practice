using Asp.netcore_practice.Context;
using Asp.netcore_practice.Controllers;
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
        private readonly OrderController _controller;

        
        
        public ShoppingCartService(AppDbContext context,ShoppingCart shoppingCart, IMapper mapper)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _mapper = mapper;
            
        }

        

        public void AddItem(Movie movie, int shoppingCartId)
        {
           var id= _shoppingCart.ShoppingCartId = shoppingCartId;

                
                var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.MovieId == movie.MovieId && n.ShoppingCartId == id);


                if (shoppingCartItem == null)
                {


                    shoppingCartItem = new ShoppingCartItem()
                    {
                        ShoppingCartId = id,
                        Movie = movie,
                        quantity = 1
                    };
                   

                    _context.ShoppingCartItems.Add(shoppingCartItem);
                }
                else
                {
                    shoppingCartItem.quantity++;
                }
                _context.SaveChanges();
            
        }


        public void RemoveItemFromCart(Movie movie, int ShoppingCartId)
        {
           

           var id= _shoppingCart.ShoppingCartId = ShoppingCartId;
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.MovieId == movie.MovieId && n.ShoppingCartId == id);

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

        public List<ShoppingCartItem> GetShoppingCartItems(int shoppingCartId)
        {
           var a= _shoppingCart.ShoppingCartId = shoppingCartId;
         
            var b=  _context.ShoppingCartItems.Where(n => n.ShoppingCartId == a)
           .Include(n => n.Movie).ToList();
            return b;
        }

        public double ShoppingCartTotal(int shoppingCartId)
        {
           var id= _shoppingCart.ShoppingCartId = shoppingCartId;

            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == id)
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


        public void ClearShoppingCart(int shoppingCartId)
        {
           var cartId= _shoppingCart.ShoppingCartId = shoppingCartId;

            var items = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == cartId).ToList();
            _context.ShoppingCartItems.RemoveRange(items);
           
            _context.SaveChanges();


        }

    }
}

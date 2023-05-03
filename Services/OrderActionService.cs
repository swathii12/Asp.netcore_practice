using Asp.netcore_practice.Context;
using Asp.netcore_practice.Models;
using Asp.netcore_practice.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netcore_practice.Services
{
    public class OrderActionService : IOrderActionService
    {
        private readonly IMovieService _service;
        private readonly IShoppingCartService _cartService;
        private readonly IMapper _mapper;
        private readonly ShoppingCartViewModel _shoppingCart;
        private readonly AppDbContext _context;

        public OrderActionService(IMovieService service, IShoppingCartService cartService, IMapper mapper, ShoppingCartViewModel shoppingCart,AppDbContext context)
        {
            _service = service;
            _cartService = cartService;
            _mapper = mapper;
            _shoppingCart = shoppingCart;
            _context = context;
        }

        public void AddShoppingCart()
        {
            var cart = new ShoppingCart()
            {

            };
            

            _context.ShoppingCart.Add(cart);
            _context.SaveChanges();
        }

        public Movie AddToShoppingCart(AddMovieViewModel model)
        {

            var item = _service.GetMovie(model.MovieId);
           

            if (item != null)
            {
                _cartService.AddItem(item,model.ShoppingCartId);
            }

            return item;
        }



        public void RemoveFromShoppingCart(AddMovieViewModel model)
        {

            var item = _service.GetMovie(model.MovieId);
           

            if (item != null)
            {
                _cartService.RemoveItemFromCart(item,model.ShoppingCartId);
            }

            
        }



        public ShoppingCartViewModel ShoppingCart(int shoppingCartId)
        {
            var items = _cartService.GetShoppingCartItems(shoppingCartId);
         
            var cart = new ShoppingCart()
            {
                ShoppingCartId = shoppingCartId,
                ShoppingCartItems = items
            };

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = cart,
                ShoppingCartTotal = _cartService.ShoppingCartTotal(shoppingCartId)
            };

            return response;
        }
    }
}

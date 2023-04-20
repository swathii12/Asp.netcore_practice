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

        public void AddShoppingCart(ShoppingViewModel model)
        {
            var cart = new ShoppingCart()
            {
                
            };
            //var abc = _mapper.Map<ShoppingViewModel, ShoppingCart>(cart);

            _context.ShoppingCart.Add(cart);
            _context.SaveChanges();
        }

        public Movie AddToShoppingCart(int id)
        {

            var item = _service.GetMovie(id);
           // var abc = _mapper.Map<MovieGetByIdViewModel, Movie>(item);

            if (item != null)
            {
                _cartService.AddItem(item);
            }

            return item;
        }



        public void RemoveFromShoppingCart(int id)
        {

            var item = _service.GetMovie(id);
           

            if (item != null)
            {
                _cartService.RemoveItemFromCart(item);
            }

            
        }



        public ShoppingCartViewModel ShoppingCart()
        {
            var items = _cartService.GetShoppingCartItems();
           // _shoppingCart.ShoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart.ShoppingCart,
                ShoppingCartTotal = _cartService.ShoppingCartTotal()
            };

            return response;
        }
    }
}

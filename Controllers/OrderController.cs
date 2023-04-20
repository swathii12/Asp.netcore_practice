using Asp.netcore_practice.Models;
using Asp.netcore_practice.Services;
using Asp.netcore_practice.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Asp.netcore_practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IShoppingCartService _cartService;
       // private readonly IMapper _mapper;

        private readonly IOrderActionService _orderService;
        private readonly IOrdersService _ordersService;

        public OrderController(IMovieService service, IShoppingCartService cartService, /*IMapper mapper*/ IOrderActionService orderService, IOrdersService ordersService)
        {
            _service = service;
            _cartService = cartService;
            // _mapper = mapper;
            _orderService = orderService;
            _ordersService = ordersService;
        }


        /*public OrderController(IOrderActionService service, IShoppingCartService cartService)
        {
            _orderService = service;
            _cartService = cartService;
        }*/





        [HttpPost("{id:int}")]

        public IActionResult AddToShoppingCart(int id)
        {
            var abc = _orderService.AddToShoppingCart(id);
            return Ok(abc);
        }


        [HttpGet]
        public IActionResult ShoppingCart()
        {
            var abc = _orderService.ShoppingCart();
            return Ok(abc);
        }


        [HttpPost]

        public IActionResult AddShoppingCart(ShoppingViewModel model)
        {
            _orderService.AddShoppingCart(model);
            return Ok();
        }

        [HttpGet("{id:int}")]

        public ShoppingCart GetShoppingCart(int id)
        {
            var abc = _cartService.GetById(id);
            return abc;
        }


        [HttpDelete("{id:int}")]

        public void DeleteItemFromCart(int id)
        {
            _orderService.RemoveFromShoppingCart(id);
        }


        [HttpPost]
        [ActionName("orderComplete")]

        public IActionResult CompleteOrder()
        {
            var items = _cartService.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            _ordersService.StoreOrder(items, userId, userEmailAddress);
            _cartService.ClearShoppingCart();

            return Ok("Order Completed");
        }
    }

}

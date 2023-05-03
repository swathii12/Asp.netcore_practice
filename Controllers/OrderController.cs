using Asp.netcore_practice.Models;
using Asp.netcore_practice.Services;
using Asp.netcore_practice.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Asp.netcore_practice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IShoppingCartService _cartService;
       

        private readonly IOrderActionService _orderService;
        private readonly IOrdersService _ordersService;

        public OrderController(IMovieService service, IShoppingCartService cartService, IOrderActionService orderService, IOrdersService ordersService)
        {
            _service = service;
            _cartService = cartService;
            
            _orderService = orderService;
            _ordersService = ordersService;
        }



        [HttpPost]
        public IActionResult AddToShoppingCart(AddMovieViewModel addMovie)
        {
            var abc = _orderService.AddToShoppingCart(addMovie);
            return Ok(abc);
        }



        [HttpGet]
        public IActionResult ShoppingCart(int shoppingCartId)
        {
            var abc = _orderService.ShoppingCart(shoppingCartId);
            return Ok(abc);
        }


        [HttpPost("AddShoppingCart")]
        
        public IActionResult AddShoppingCart()
        {
            _orderService.AddShoppingCart();
            return Ok();
        }


        [HttpGet("AllOrdersList")]
        
        public IActionResult ListAllOrders()
        {
            string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string UserRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = _ordersService.GetOrdersByUserIdAndRole(UserId,UserRole);

            return Ok(orders);

        }



        [HttpDelete]

        public void DeleteItemFromCart(AddMovieViewModel removeMovie)
        {
            _orderService.RemoveFromShoppingCart(removeMovie);
        }


        [HttpPost]
        [ActionName("orderComplete")]

        public IActionResult CompleteOrder(int shoppingCartId)
        {
            var items = _cartService.GetShoppingCartItems(shoppingCartId);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            _ordersService.StoreOrder(items, userId, userEmailAddress);
            _cartService.ClearShoppingCart(shoppingCartId);

            return Ok("Order Completed");
        }
    }

}

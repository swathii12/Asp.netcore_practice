using Asp.netcore_practice.Context;
using Asp.netcore_practice.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Asp.netcore_practice.Models
{
    public class ShoppingCart
    {
        
        public int ShoppingCartId { get; set; }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
       

    }
}

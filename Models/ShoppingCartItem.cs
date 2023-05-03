using Asp.netcore_practice.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.netcore_practice.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public int quantity { get; set; }



        public ShoppingCart shoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
    }
}

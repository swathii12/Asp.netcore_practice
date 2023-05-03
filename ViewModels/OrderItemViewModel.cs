using Asp.netcore_practice.Models;

namespace Asp.netcore_practice.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public double Price { get; set; }
        public string MovieName { get; set; }
        public int OrderId { get; set; }
    }
}

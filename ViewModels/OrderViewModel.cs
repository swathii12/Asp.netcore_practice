using Asp.netcore_practice.Models;

namespace Asp.netcore_practice.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();
    }
}

namespace Asp.netcore_practice.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }


        public ApplicationUser User { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}

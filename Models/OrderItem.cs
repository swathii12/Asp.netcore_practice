namespace Asp.netcore_practice.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public double Price { get; set; }


        public Movie movie { get; set; }
        public int MovieId { get; set; }

        public Order order { get; set; }
        public int OrderId { get; set; }
    }
}

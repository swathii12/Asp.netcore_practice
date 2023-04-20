namespace Asp.netcore_practice.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string ProducerName { get; set; }
        public string Bio { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }=new List<Movie>();
    }
}

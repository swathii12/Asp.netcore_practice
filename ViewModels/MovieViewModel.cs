using Asp.netcore_practice.Models;

namespace Asp.netcore_practice.ViewModels
{
    public class MovieViewModel
    {
        
        public string MovieName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        public MovieCategory MovieCategory { get; set; }

        //Relationships

        public int CinemaId { get; set; }

        public int ProducerId { get; set; }

        public List<int> ActorId { get; set; } = new List<int>();
    }
}

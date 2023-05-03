using Asp.netcore_practice.Models;

namespace Asp.netcore_practice.ViewModels
{
    public class MovieGetByIdViewModel
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships

        public int CinemaId { get; set; }

        public int ProducerId{ get; set; }

        public List<string> ActorNames { get; set; } = new List<string>();
    }
}

namespace Asp.netcore_practice.Models
{
    public class Movie
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

       


        public  Cinema? Cinema { get; set; }
        public int CinemaId { get; set; }


        public Producer? producer { get; set; }
        public int ProducerId { get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; } = new List<Actor_Movie>();


    }
}

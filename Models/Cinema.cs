namespace Asp.netcore_practice.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string CinemaLogo { get; set; }
        public string CinemaName { get; set; }
        public string description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }=new List<Movie>();
    }
}

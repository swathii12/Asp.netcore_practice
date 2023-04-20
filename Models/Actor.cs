namespace Asp.netcore_practice.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string ActorName { get; set; }
        public string Bio { get; set; }

        //Relationships

        public List<Actor_Movie> Actor_Movies { get; set; }=new List<Actor_Movie>();
    }
}

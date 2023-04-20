using Asp.netcore_practice.Models;

namespace Asp.netcore_practice.ViewModels
{
    public class ActorViewModel
    {
       // public int ActorId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string ActorName { get; set; }
        public string Bio { get; set; }

        //Relationships

       // public List<int> MovieIds { get; set; } = new List<int>();
    }
}

using Asp.netcore_practice.Models;

namespace Asp.netcore_practice.ViewModels
{
    public class ProducerGetByIdViewModel
    {
        public int ProducerId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string ProducerName { get; set; }
        public string Bio { get; set; }

        //Relationships
        public List<string> Movies { get; set; } = new List<string>();
    }
}

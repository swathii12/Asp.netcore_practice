namespace Asp.netcore_practice.ViewModels
{
    public class CinemaGetByIdViewModel
    {
        public int CinemaId { get; set; }
        public string CinemaLogo { get; set; }
        public string CinemaName { get; set; }
        public string description { get; set; }

        //Relationships

        public List<string> MovieNames { get; set; } = new List<string>();
    }
}

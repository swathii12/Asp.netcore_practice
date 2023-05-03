using System.ComponentModel.DataAnnotations;

namespace Asp.netcore_practice.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

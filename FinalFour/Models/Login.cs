using System.ComponentModel.DataAnnotations;
namespace FinalFour.Models
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string UserId { get; set; }


    }
}

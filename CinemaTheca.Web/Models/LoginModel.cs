using System.ComponentModel.DataAnnotations;

namespace CinemaTheca.Web.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Электронная почта")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
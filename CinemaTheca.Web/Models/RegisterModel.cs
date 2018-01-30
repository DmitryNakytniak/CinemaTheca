using System.ComponentModel.DataAnnotations;

namespace CinemaTheca.Web.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Электронная почта*")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} должен быть не меньше {2} символов в длину", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль*")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля*")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Город")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Логин*")]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Account
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "Логин обязателен")]
        [DataType(DataType.Text)]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 64 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Пароль должен быть от 8 до 64 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Никнейм обязателен")]
        [DataType(DataType.Text)]
        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Пароль должен быть от 8 до 64 символов")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email обязателен")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Некорректный email")]
        public string Email { get; set; }
    }
}

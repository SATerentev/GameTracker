using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Account
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage="Логин обязателен")]
        [DataType(DataType.Text)]
        [StringLength(64, MinimumLength =3, ErrorMessage ="Логин должен быть от 3 до 64 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage="Пароль обязателен")]
        [DataType(DataType.Password)]
        [StringLength(64, MinimumLength = 8, ErrorMessage="Пароль должен быть от 8 до 64 символов")]
        public string Password { get; set; }
    }
}
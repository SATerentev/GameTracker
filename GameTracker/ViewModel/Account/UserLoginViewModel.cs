using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Account
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage="Логин обязателен")]
        [DataType(DataType.Text)]
        [StringLength(32, MinimumLength =3, ErrorMessage ="Логин должен быть от 3 до 32 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage="Пароль обязателен")]
        [DataType(DataType.Password)]
        [StringLength(32, MinimumLength = 8, ErrorMessage="Пароль должен быть от 8 до 32 символов")]
        public string Password { get; set; }
    }
}
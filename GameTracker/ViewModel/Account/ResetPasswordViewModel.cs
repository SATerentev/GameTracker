using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Account
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Length(8, 32, ErrorMessage = "Пароль должен быть от 8 до 32 символов")]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}

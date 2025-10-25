using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Account
{
    public class ConfirmEmailViewModel
    {
        [Required]
        [Length(3, 32, ErrorMessage ="Код может быть от 3 до 32 цифр")]
        public string Code { get; set; }
    }
}

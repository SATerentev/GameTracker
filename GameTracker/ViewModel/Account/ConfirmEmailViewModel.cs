using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Account
{
    public class ConfirmEmailViewModel
    {
        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Код должен состоять из 6 цифр.")]
        public string Code { get; set; }
    }
}

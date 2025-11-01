using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Account
{
    public class ConfirmEmailViewModel
    {
        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Код должен состоять из 5 цифр.")]
        public string Code { get; set; }
    }
}

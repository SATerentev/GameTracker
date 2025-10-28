using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel
{
    public class MakeModeratorViewModel
    {
        [Required(ErrorMessage = "Логин обязателен")]
        [DataType(DataType.Text)]
        [StringLength(32, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 32 символов")]
        public string Login { get; set; }
    }
}

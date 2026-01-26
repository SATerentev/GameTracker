using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel
{
    public class GameRequestViewModel
    {
        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string GameName { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения")]
        public string GameLink { get; set; }
    }
}

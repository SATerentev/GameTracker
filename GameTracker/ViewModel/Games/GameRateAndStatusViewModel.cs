using GameTracker.Entity.Games;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Games
{
    public class GameRateAndStatusViewModel
    {
        [Required(ErrorMessage = "Выберите статус")]
        public GameStatus Status { get; set; }

        [Range(1, 10, ErrorMessage = "Оценка должна быть от 1 до 10")]
        public int Rating { get; set; }
    }
}

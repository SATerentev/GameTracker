using GameTracker.Entity.Games;
using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Games
{
    public class AddGameToCatalogViewModel
    {
        [Required(ErrorMessage = "Обязательно для заполнения.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения.")]
        public string Link { get; set; } // Ссылка на игру в steam/itch.io и т.д.

        [Required(ErrorMessage = "Обязательно для заполнения.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения.")]
        public string DeveloperName { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения.")]
        public string PublisherName { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения.")]
        public DateTime ReleaseDate { get; set; }
    }
}

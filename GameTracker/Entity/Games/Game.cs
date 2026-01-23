using GameTracker.ViewModel.Games;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Entity.Games
{
    [Table("Games")]
    public class Game
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Link { get; private set; } // Ссылка на игру в steam/itch.io и т.д.
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public string DeveloperName { get; private set; }
        public string PublisherName { get; private set; }
        public string Genre { get; private set; }
        public DateTime ReleaseDate { get; private set; }

        // Надо будет сделать скриншоты. Вроде бы лучший вариант - сделать отдельную сущность Screenshot с полями Id, GameId, Url, но надо проверить.

        public Game(string name, string link, string description, string imageUrl, string developerName,
            string publisherName, string genre, DateTime releaseDate)
        {
            Id = Guid.NewGuid();
            Name = name;
            Link = link;
            Description = description;
            ImageUrl = imageUrl;
            DeveloperName = developerName;
            PublisherName = publisherName;
            Genre = genre;
            ReleaseDate = releaseDate;
        }

        public Game() { } // Вроде без него EF Core не работает. Не удалять.

        public Game UpdateDetails(EditGameViewModel vm)
        {
            Name = vm.Name;
            Link = vm.Link;
            Description = vm.Description;
            ImageUrl = vm.ImageUrl;
            DeveloperName = vm.DeveloperName;
            PublisherName = vm.PublisherName;
            Genre = vm.Genre;
            ReleaseDate = vm.ReleaseDate;

            return this;
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace GameTracker.Entity
{
    [Table("GameRequests")]
    public class GameRequest
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string GameName { get; private set; }
        public string GameLink { get; private set; }

        public GameRequest(string gameName, string gameLink, Guid userId)
        {
            Id = Guid.NewGuid();
            GameName = gameName;
            GameLink = gameLink;
            UserId = userId;
        }

        public GameRequest() { }  //  Надо для ef core вроде бы
    }
}

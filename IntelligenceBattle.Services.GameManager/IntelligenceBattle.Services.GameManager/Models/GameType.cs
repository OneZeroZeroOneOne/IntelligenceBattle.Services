using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class GameType
    {
        public GameType()
        {
            GameTypeTranslations = new HashSet<GameTypeTranslation>();
            Games = new HashSet<Game>();
            SearchGames = new HashSet<SearchGame>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int PlayerCount { get; set; }

        public virtual ICollection<GameTypeTranslation> GameTypeTranslations { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<SearchGame> SearchGames { get; set; }
    }
}

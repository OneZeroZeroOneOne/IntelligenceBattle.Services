using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class GameType
    {
        public GameType()
        {
            Games = new HashSet<Game>();
            SearchGames = new HashSet<SearchGame>();
        }

        public int Id { get; set; }
        public string Tittle { get; set; }
        public int PlayerCount { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<SearchGame> SearchGames { get; set; }
    }
}

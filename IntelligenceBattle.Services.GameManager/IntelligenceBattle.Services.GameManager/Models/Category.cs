using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class Category
    {
        public Category()
        {
            Games = new HashSet<Game>();
            Questions = new HashSet<Question>();
            SearchGames = new HashSet<SearchGame>();
        }

        public int Id { get; set; }
        public string Tittle { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<SearchGame> SearchGames { get; set; }
    }
}

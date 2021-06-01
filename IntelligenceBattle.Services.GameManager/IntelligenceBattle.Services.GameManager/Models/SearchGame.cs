using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class SearchGame
    {
        public int Id { get; set; }
        public int GameTypeId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int ProviderId { get; set; }

        public virtual Category Category { get; set; }
        public virtual GameType GameType { get; set; }
        public virtual AuthorizationProvider Provider { get; set; }
        public virtual User User { get; set; }
    }
}

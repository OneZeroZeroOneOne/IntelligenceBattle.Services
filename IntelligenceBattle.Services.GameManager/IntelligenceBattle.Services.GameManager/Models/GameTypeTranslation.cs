using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class GameTypeTranslation
    {
        public int GameTypeId { get; set; }
        public int LangId { get; set; }
        public string Title { get; set; }

        public virtual GameType GameType { get; set; }
        public virtual Lang Lang { get; set; }
    }
}

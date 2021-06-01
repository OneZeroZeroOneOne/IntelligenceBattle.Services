using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class GameQuestion
    {
        public int QuestionId { get; set; }
        public int GameId { get; set; }
        public bool IsCurrent { get; set; }

        public virtual Game Game { get; set; }
        public virtual Question Question { get; set; }
    }
}

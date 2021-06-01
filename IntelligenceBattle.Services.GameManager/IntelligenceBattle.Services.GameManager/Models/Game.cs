using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class Game
    {
        public Game()
        {
            GameQuestions = new HashSet<GameQuestion>();
            GameUsers = new HashSet<GameUser>();
            SendQuestions = new HashSet<SendQuestion>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public int CategoryId { get; set; }
        public bool IsEnd { get; set; }
        public int GameTypeId { get; set; }

        public virtual Category Category { get; set; }
        public virtual GameType GameType { get; set; }
        public virtual ICollection<GameQuestion> GameQuestions { get; set; }
        public virtual ICollection<GameUser> GameUsers { get; set; }
        public virtual ICollection<SendQuestion> SendQuestions { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}

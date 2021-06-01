using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class UserAnswer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int? AnswerId { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public int QuestionId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}

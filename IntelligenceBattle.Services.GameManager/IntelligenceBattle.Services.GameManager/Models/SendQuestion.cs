using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class SendQuestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProviderId { get; set; }
        public int QuestionId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual AuthorizationProvider Provider { get; set; }
        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}

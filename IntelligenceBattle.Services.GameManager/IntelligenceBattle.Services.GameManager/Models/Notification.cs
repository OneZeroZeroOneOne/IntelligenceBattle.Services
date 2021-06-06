using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TypeId { get; set; }
        public int ProviderId { get; set; }
        public int UserId { get; set; }

        public virtual AuthorizationProvider Provider { get; set; }
        public virtual NotificationType Type { get; set; }
        public virtual User User { get; set; }
    }
}

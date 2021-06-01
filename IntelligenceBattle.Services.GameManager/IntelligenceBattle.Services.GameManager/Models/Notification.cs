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

        public virtual NotificationType Type { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class NotificationType
    {
        public NotificationType()
        {
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }
        public string Tittle { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}

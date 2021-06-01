using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class UserSecurity
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RealId { get; set; }
        public int AuthorizationCenterId { get; set; }

        public virtual AuthorizationCenter AuthorizationCenter { get; set; }
        public virtual User User { get; set; }
    }
}

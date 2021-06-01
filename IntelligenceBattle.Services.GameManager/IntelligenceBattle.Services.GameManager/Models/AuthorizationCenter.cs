using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class AuthorizationCenter
    {
        public AuthorizationCenter()
        {
            AuthorizationProviderTypes = new HashSet<AuthorizationProviderType>();
            UserSecurities = new HashSet<UserSecurity>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<AuthorizationProviderType> AuthorizationProviderTypes { get; set; }
        public virtual ICollection<UserSecurity> UserSecurities { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class AuthorizationProviderType
    {
        public AuthorizationProviderType()
        {
            AuthorizationProviders = new HashSet<AuthorizationProvider>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorizationProviderCenterId { get; set; }

        public virtual AuthorizationCenter AuthorizationProviderCenter { get; set; }
        public virtual ICollection<AuthorizationProvider> AuthorizationProviders { get; set; }
    }
}

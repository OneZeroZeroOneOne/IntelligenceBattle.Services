using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class AuthorizationProvider
    {
        public AuthorizationProvider()
        {
            GameUsers = new HashSet<GameUser>();
            SearchGames = new HashSet<SearchGame>();
            SendQuestions = new HashSet<SendQuestion>();
        }

        public int Id { get; set; }
        public string Key { get; set; }
        public int? AuthorizationProviderTypeId { get; set; }

        public virtual AuthorizationProviderType AuthorizationProviderType { get; set; }
        public virtual ICollection<GameUser> GameUsers { get; set; }
        public virtual ICollection<SearchGame> SearchGames { get; set; }
        public virtual ICollection<SendQuestion> SendQuestions { get; set; }
    }
}

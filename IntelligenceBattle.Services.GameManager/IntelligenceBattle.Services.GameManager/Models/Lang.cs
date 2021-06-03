using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class Lang
    {
        public Lang()
        {
            CategoryTranslations = new HashSet<CategoryTranslation>();
            GameTypeTranslations = new HashSet<GameTypeTranslation>();
        }

        public int Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        public virtual ICollection<GameTypeTranslation> GameTypeTranslations { get; set; }
    }
}

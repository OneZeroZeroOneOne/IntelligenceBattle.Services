using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class Lang
    {
        public Lang()
        {
            AnswerTranslations = new HashSet<AnswerTranslation>();
            CategoryTranslations = new HashSet<CategoryTranslation>();
            GameTypeTranslations = new HashSet<GameTypeTranslation>();
            QuestionTranslations = new HashSet<QuestionTranslation>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Code { get; set; }

        public virtual ICollection<AnswerTranslation> AnswerTranslations { get; set; }
        public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        public virtual ICollection<GameTypeTranslation> GameTypeTranslations { get; set; }
        public virtual ICollection<QuestionTranslation> QuestionTranslations { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

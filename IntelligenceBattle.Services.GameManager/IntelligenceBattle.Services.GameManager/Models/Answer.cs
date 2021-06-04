using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class Answer
    {
        public Answer()
        {
            AnswerTranslations = new HashSet<AnswerTranslation>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsTrue { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<AnswerTranslation> AnswerTranslations { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            GameQuestions = new HashSet<GameQuestion>();
            QuestionTranslations = new HashSet<QuestionTranslation>();
            SendQuestions = new HashSet<SendQuestion>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public int CategoryId { get; set; }
        public string MediaUrl { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<GameQuestion> GameQuestions { get; set; }
        public virtual ICollection<QuestionTranslation> QuestionTranslations { get; set; }
        public virtual ICollection<SendQuestion> SendQuestions { get; set; }
    }
}

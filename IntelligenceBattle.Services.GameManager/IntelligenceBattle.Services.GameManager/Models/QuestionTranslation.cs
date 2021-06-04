using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class QuestionTranslation
    {
        public int QuestionId { get; set; }
        public int LangId { get; set; }
        public string Title { get; set; }

        public virtual Lang Lang { get; set; }
        public virtual Question Question { get; set; }
    }
}

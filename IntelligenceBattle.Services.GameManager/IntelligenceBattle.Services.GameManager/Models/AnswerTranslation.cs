using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class AnswerTranslation
    {
        public int AnswerId { get; set; }
        public int LangId { get; set; }
        public string Title { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Lang Lang { get; set; }
    }
}

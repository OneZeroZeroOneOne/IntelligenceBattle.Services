using System;
using System.Collections.Generic;

#nullable disable

namespace IntelligenceBattle.Services.GameManager.Models
{
    public partial class CategoryTranslation
    {
        public int CategoryId { get; set; }
        public int LangId { get; set; }
        public string Title { get; set; }

        public virtual Category Category { get; set; }
        public virtual Lang Lang { get; set; }
    }
}

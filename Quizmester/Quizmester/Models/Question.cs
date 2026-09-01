using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmester.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int Points { get; set; }
        public int TimeLimitSeconds { get; set; }
        public bool IsActive { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();

    }
}

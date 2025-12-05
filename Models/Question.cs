using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Models
{
    public class Question
    {
        public int questionID { get; set; }
        public string questionContent { get; set; }
        public List<Answer> answers { get; set; } = new List<Answer>();
        public int difficultyLevel { get; set; }
    }
}

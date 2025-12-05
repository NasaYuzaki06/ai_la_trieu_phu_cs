using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Models
{
    public class Answer
    {
        public int answerID { get; set; }
        public string answerContent { get; set; }
        public bool isCorrect { get; set; }
        public char optionIdentifier { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Models
{
    public class Player
    {
        public int playerID { get; set; }
        public string playerName { get; set; }
        public long currentPrize { get; set; } = 0;
        public int currentQuestionNumber { get; set; } = 1;
        public int currentLevel { get; set; } = 5;
        public DateTime joinDate { get; set; }
    }
}

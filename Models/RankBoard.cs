using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Models
{
    public class RankBoard
    {
        public int rankID { get; set; }
        public int playerID { get; set; }
        public string playerName { get; set; }
        public DateTime playDate { get; set; }
        public int questionNumberReached { get; set; }
        public long prizeAmount { get; set; }
    }
}

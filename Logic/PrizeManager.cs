using ai_la_trieu_phu.Data;
using ai_la_trieu_phu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_la_trieu_phu.Logic
{
    public class PrizeManager
    {
        public List<PrizeLevel> prizeLevels;
        private PrizeRepository _prizeRepository;

        public PrizeManager()
        {
            prizeLevels = new List<PrizeLevel>();
            _prizeRepository = new PrizeRepository();
            LoadPrizeLevels();
        }
        
        private void LoadPrizeLevels()
        {
            prizeLevels = _prizeRepository.getAllPrizeLevel();
        }

        public long getPrizeAmount(int questionNumber)
        {
            var prizeLevel = prizeLevels.ElementAt(questionNumber - 1).prizeAmount;
            return prizeLevel;
        }

        public long getMilestoneAmount(int failedQuestionNumber)
        {
            for (int i = failedQuestionNumber - 1; i >= 0; i--)
            {
                PrizeLevel level = prizeLevels[i];
                if (level.isSafeHaven)
                {
                    return level.prizeAmount;
                }
            }
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ai_la_trieu_phu.Logic
{
    public class SoundManager
    {
        public static SoundPlayer backgroundSound = new SoundPlayer();
        public static SoundPlayer effectSound = new SoundPlayer();
        public static SoundPlayer victorySound = new SoundPlayer();
        public static SoundPlayer inGameSound = new SoundPlayer();

        public static bool isSoundOn = true;
        public static bool isSoundEffectOn = true;

        public static void playBackgroundSound()
        {
            backgroundSound.Stream = Properties.Resources.nhac_nen_gameshow_ai_la_trieu_phu;
            backgroundSound.PlayLooping();
        }

        public static void playCorrectAnswerSound()
        {
            effectSound.Stream = Properties.Resources.Am_thanh_tra_loi_dung_ai_la_trieu_phu;
            effectSound.Play();
        }

        public static void playWrongAnswerSound()
        {
            effectSound.Stream = Properties.Resources.Am_thanh_tra_loi_sai_ai_la_trieu_phu;
            effectSound.Play();
        }

        public static void playVictorySound()
        {
            victorySound.Stream = Properties.Resources.hieu_ung_am_thanh_chien_thang;
            victorySound.Play();
        }

        public static void playInGameSound()
        {
            inGameSound.Stream = Properties.Resources.in_game;
            inGameSound.PlayLooping();
        }

        public static void stopInGameSound()
        {
            inGameSound.Stop();
        }

        public static void stopBackgroundSound()
        {
            backgroundSound.Stop();
        }

        public static void stopEffectSound()
        {
            effectSound.Stop();
        }

        public static void victorySoundStop()
        {
            victorySound.Stop();
        }


    }
}

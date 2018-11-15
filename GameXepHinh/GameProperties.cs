using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameXepHinh
{
    public class GameProperties
    {
        public static string IMAGE_SOURCE="images\\picture2.png";
        public static int GAME_ROW=4;
        public static int GAME_COLUMN=4;
        public static int PANEL_WIDTH = 400;
        public static int PANEL_HEIGHT = 400;
        public static int SPEED_TIMER_REGULAR = 1000;
        public static int SPEED_TIMER_INTERVAL = 1000;
        public static string MOVE_SOUND_PATH = "sounds\\ding.wav";
        public static string WINGAME_SOUND_PATH = "sounds\\win.wav";
        public static string BACKGROUND_MUSIC_PATH = "sounds\\background.wav";
        public static bool AUTO_MODE_A_ALGORITHM = true;
    }
}

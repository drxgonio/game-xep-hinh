using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GameXepHinh
{
    public partial class Form1 : Form
    {

        #region Properties_Sound
         //Add thư viện điều khiển âm thanh và icon volume
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        bool check_volume = true;
        public int keepvaluevolume = 5;
        Image ImgVolumeOn = Image.FromFile("icon\\volume.on.png");
        Image ImgVolumeOff = Image.FromFile("icon\\volume.off.jpg");
        //Add thư viện điều khiển âm thanh và icon volume
        #endregion
       
        #region Properties_Panel
        PictureBoxManager pictureBoxManager;
        GameInfoManager gameInfoManager;
        #endregion

        #region Properties_Solve

        private GameXepHinh.Strategy.PuzzleStrategy mStrategy;
        private GameXepHinh.Strategy.Heuristic mHeuristic;

        private WindowsFormsSynchronizationContext mSyncContext;

        private int[] mInitialState;
        
        private bool mBusy;
        private bool isSolve;
        private bool isSolved;

        System.Threading.Thread threadAutoPlay_Normal;

        #endregion Properties_Solve


        public Form1()
        {
            InitializeComponent();
            // gán mặc định khi khởi động =0
            uint CurrVol = 0;
            //-------------------------
            waveOutGetVolume(IntPtr.Zero, out CurrVol);
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            // gán 1 giá trị tăng lên bằng 1/10 âm lượng
            trackbar_volume.Value = CalcVol / (ushort.MaxValue / 10);
            //-----------------------------------------
            SetupProperties();
            Sound_BackGround();
            pictureBoxManager = new PictureBoxManager(panelPicture);
            gameInfoManager = new GameInfoManager(panelGameInfo, previewImage, lbTimeMinute, lbTimeSecond, tbPictureMoved, cbbSpeed);
            pictureBoxManager.OneMoveEvent += pictureBoxManager_OneMoveEvent;
            pictureBoxManager.Wingame += pictureBoxManager_Wingame;
            //Kiểm trạng thái đầu tiên của âm thanh
            if (trackbar_volume.Value == 0)
            {
                bt_controlvolume.BackgroundImage = ImgVolumeOff;
                pictureBoxManager.ValueVolume=trackbar_volume.Value * 20;
            }
            if (bt_controlvolume.BackgroundImage == ImgVolumeOff)
            {
                pictureBoxManager.Receive = false;
            }
            else
            {
                pictureBoxManager.Receive = true;
                pictureBoxManager.ValueVolume = trackbar_volume.Value * 20;
            }
            //--------------------------------------------------
        }

       
         

        #region Methods

        void pictureBoxManager_Wingame()
        {
            isSolved = true;
            gameInfoManager.StopTimer();
            MessageBox.Show("You are Win");
        }

        void pictureBoxManager_OneMoveEvent()
        {
            gameInfoManager.IncreaseMove();
        }

        void NewGame()
        {
            if (ActionAllowed() || isSolved == true)
            {

                pictureBoxManager.NewGame();
                gameInfoManager.NewGame();
                isSolved = false;
                mBusy = false;
                SetBusy();
                try
                {
                    mStrategy.StopSolve();
                }
                catch { }
            }
        }

        //Cài đặt lại thông số properties
        void SetupProperties()
        {
            var readconfig = File.ReadAllLines("config.config").ToList();
            GameProperties.IMAGE_SOURCE = readconfig[0].ToString();
            GameProperties.GAME_COLUMN = Convert.ToInt32(readconfig[1]);
            GameProperties.GAME_ROW = Convert.ToInt32(readconfig[1]);
        }
      
        void Sound_BackGround()
        {
            System.Media.SoundPlayer SoundBackGround = new System.Media.SoundPlayer(GameProperties.BACKGROUND_MUSIC_PATH);
            SoundBackGround.PlayLooping();
        }

        //Thay đổi file cấu hình khi nhận dữ liệu save
        void ChangeConfig(string imgchange, int sizechange)
        {
            using (FileStream ChangeConfig = new FileStream("config.config", FileMode.Create))
            {
                using (StreamWriter file = new StreamWriter(ChangeConfig))
                {
                    file.WriteLine(imgchange);
                    file.WriteLine(sizechange.ToString());
                }
            }
        }
        

        #endregion Methods

        #region Events

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    pictureBoxManager.ToDown();
                    break;
                case Keys.Up:
                    pictureBoxManager.ToUp();
                    break;
                case Keys.Left:
                    pictureBoxManager.ToLeft();
                    break;
                case Keys.Right:
                    pictureBoxManager.ToRight();
                    break;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAutoPlay_Click(object sender, EventArgs e)
        {
            if (ActionAllowed())
            {
                if (GameProperties.AUTO_MODE_A_ALGORITHM)
                    AutoPlay_A_Algorithm();
                else
                    AutoPlay_Normal();
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem1.Checked = true;
            GameProperties.AUTO_MODE_A_ALGORITHM = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = false;
            toolStripMenuItem2.Checked = true;
            GameProperties.AUTO_MODE_A_ALGORITHM = false;
        }

        private void NoCapture_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            return;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                threadAutoPlay_Normal.Abort();
            }
            catch { }

        }

        //Bắt sự kiện save
        void f_SaveGameProperties_Event(string imageSouce, int gameSize)
        {
            GameProperties.GAME_COLUMN = gameSize;
            GameProperties.GAME_ROW = gameSize;
            GameProperties.IMAGE_SOURCE = imageSouce;
            ChangeConfig(GameProperties.IMAGE_SOURCE, GameProperties.GAME_COLUMN);
            NewGame();
        }
       
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ActionAllowed())
            {
                MessageBox.Show("Puzzle is solving");
                return;
            }
            formOption f = new formOption();
            f.SaveGameProperties_Event += f_SaveGameProperties_Event;
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ActionAllowed() || isSolved == true)
            {

                pictureBoxManager.RandomPictureBox();
                gameInfoManager.NewGame();
            }
        }

        private void cbbSpeed_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;
            KeyValuePair<string, float> item = (KeyValuePair<string, float>)cbb.SelectedItem;
            float speed = item.Value;
            GameProperties.SPEED_TIMER_INTERVAL = (int)(GameProperties.SPEED_TIMER_REGULAR / speed);
        }

        private void btnStopSolve_Click(object sender, EventArgs e)
        {
            if (isSolve)
                return;
            mBusy = false;
            SetBusy();
            try
            {
                mStrategy.StopSolve();
            }
            catch (System.NullReferenceException)
            {

            }
        }

        private void guideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formGuide f = new formGuide();
            f.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAbout f = new formAbout();
            f.ShowDialog();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        //Điều khiển âm lượng và truyền tín hiện âm thanh trò chơi
        private void trackbar_volume_Scroll(object sender, EventArgs e)
        {
            if (bt_controlvolume.BackgroundImage == ImgVolumeOff)
            {
                bt_controlvolume.BackgroundImage = ImgVolumeOn;
                pictureBoxManager.ValueVolume = trackbar_volume.Value * 20;
            }
            if (trackbar_volume.Value == 0)
            {
                bt_controlvolume.BackgroundImage = ImgVolumeOff;
                pictureBoxManager.ValueVolume = trackbar_volume.Value * 20;
            }
            if (bt_controlvolume.BackgroundImage == ImgVolumeOn)
            {
                pictureBoxManager.ValueVolume = trackbar_volume.Value * 20;
            }
            keepvaluevolume = trackbar_volume.Value;
            int NewVolume = ((ushort.MaxValue / 10) * trackbar_volume.Value);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
            if (bt_controlvolume.BackgroundImage == ImgVolumeOff)
            {
                pictureBoxManager.Receive = false;
            }
            else
            {
                pictureBoxManager.Receive = true;
            }
        }

        private void bt_controlvolume_Click(object sender, EventArgs e)
        {
            if (check_volume == true)
            {
                pictureBoxManager.ValueVolume = trackbar_volume.Value * 20;
                bt_controlvolume.BackgroundImage = ImgVolumeOff;
                int NewVolume = (0);
                uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
                waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
                check_volume = false;
            }
            else
            {
                if (trackbar_volume.Value == 0)
                {
                    pictureBoxManager.Receive = false;
                    pictureBoxManager.ValueVolume = trackbar_volume.Value * 20;
                    return;
                }
                pictureBoxManager.ValueVolume = trackbar_volume.Value * 20;
                bt_controlvolume.BackgroundImage = ImgVolumeOn;
                int NewVolume = ((ushort.MaxValue / 10) * keepvaluevolume);
                uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
                waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
                check_volume = true;
            }
            if (bt_controlvolume.BackgroundImage == ImgVolumeOff)
            {
                pictureBoxManager.Receive = false;
            }
            else
            {
                pictureBoxManager.Receive = true;
            }
        }
        
        #endregion Events




        #region AutoPlay

        void AutoPlay_A_Algorithm()
        {
            mSyncContext = SynchronizationContext.Current as WindowsFormsSynchronizationContext;
            Initialize();
        }

        private void Initialize()
        {
            mInitialState = new int[GameProperties.GAME_ROW * GameProperties.GAME_COLUMN];
            int index = 0;
            for (int row = 0; row < GameProperties.GAME_ROW; row++)
            {
                for (int col = 0; col < GameProperties.GAME_COLUMN; col++)
                {
                    mInitialState[index++] = pictureBoxManager.ValueMatrix[row, col];
                }
            }

            mStrategy = new GameXepHinh.Strategy.PuzzleStrategy();
            mHeuristic = GameXepHinh.Strategy.Heuristic.ManhattanDistance;
            mStrategy.OnStateChanged += mStrategy_OnStateChanged;
            mStrategy.OnPuzzleSolved += mStrategy_OnPuzzleSolved;

            if (ActionAllowed())
            {
                StartSolvingPuzzle();
            }
        }

        void mStrategy_OnPuzzleSolved(int steps, int stateExamined)
        {
            Action action = () =>
            {
                this.Cursor = Cursors.Default;
                if (steps > -1)
                {
                    mBusy = true;
                    SetBusy();
                    MessageBox.Show(this, "Solution found! Click on Ok to see the steps..." + stateExamined.ToString());
                }
                else
                {
                    mBusy = false;
                    SetBusy();
                    MessageBox.Show(this, "No solution found!");

                }
            };
            mSyncContext.Send(item => action.Invoke(), null);
        }

        void mStrategy_OnStateChanged(int[] currentState, bool isFinal)
        {
            mSyncContext.Post(item => DisplayState(currentState, isFinal), null);
            Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);
        }

        private void DisplayState(int[] nodes, bool isFinal)
        {
            if (nodes != null)
            {
                ProcessState(nodes, pictureBoxManager.ValueMatrix);
            }

            if (isFinal)
            {
                gameInfoManager.StopTimer();
                MessageBox.Show("Puzzle is solved");
                isSolved = true;
            }
        }

        void ProcessState(int[] nodes, int[,] currentState)
        {

            int curX = 0, curY = 0, X = 0, Y = 0;
            for (int row = 0; row < GameProperties.GAME_ROW; row++)
            {
                for (int col = 0; col < GameProperties.GAME_COLUMN; col++)
                {
                    if (pictureBoxManager.ValueMatrix[row, col] == -1)
                    {
                        curX = col;
                        curY = row;
                    }
                }
            }

            for (int index = 0; index < nodes.Count(); index++)
            {
                if (nodes[index] == -1)
                {
                    X = index % GameProperties.GAME_COLUMN;
                    Y = index / GameProperties.GAME_COLUMN;
                }
            }

            pictureBoxManager.ProcessDirecton(new Point(curX, curY), new Point(X, Y));
        }

        private bool ActionAllowed()
        {
            return !mBusy;
        }

        private void StartSolvingPuzzle()
        {
            mStrategy.Solve(mInitialState, mHeuristic);
            this.Cursor = Cursors.AppStarting;
            mBusy = true;
            SetBusy();
        }

     

        void SetBusy()
        {
            pictureBoxManager.IsBusy = this.mBusy;
        }
    
        void AutoPlay_Normal()
        {
            Normal_AutoPlay();
        }

        private void Normal_AutoPlay()
        {
            mBusy = true;
            isSolve = true;
            SetBusy();
            threadAutoPlay_Normal  = new System.Threading.Thread(new System.Threading.ThreadStart(
                     () =>
                     {
                         for (int row = 0; row < GameProperties.GAME_ROW - 2; row++)
                         {
                             for (int col = 0; col < GameProperties.GAME_COLUMN - 2; col++)
                             {
                                 Point root = new Point(col, row);
                                 Point blank = pictureBoxManager.EmptyPicture;
                                 int rootValue = row * GameProperties.GAME_ROW + col + 1;
                                 Point picture = pictureBoxManager.GetPositionByValue(rootValue);

                                 List<Point> WayMove = new List<Point>();
                                 WayMove.Add(root);
                                 List<Point> blackList = new List<Point>();
                                 int i = 0;
                                 int j = 0;
                                 for (i = 0; i < GameProperties.GAME_ROW; i++)
                                 {
                                     for (j = 0; j < GameProperties.GAME_COLUMN; j++)
                                     {
                                         if (i == row && j == col)
                                             break;
                                         blackList.Add(new Point(j, i));

                                     }
                                     if (j != GameProperties.GAME_COLUMN)
                                         break;
                                 }

                                 GetWay(root.X, root.Y, root, blank, picture, WayMove, blackList);

                                 int ind = WayMove.IndexOf(blank);

                                 // Process(ind, root, rootValue,WayMove);

                                 while (pictureBoxManager.ValueMatrix[root.Y, root.X] != rootValue)
                                 {
                                     pictureBoxManager.ProcessAutoClick(WayMove[ind]);
                                     ind++;
                                     if (ind == WayMove.Count)
                                         ind = 0;
                                     System.Threading.Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);
                                 }

                                 //



                             }
                             //Chuyển ô cuối hàng đến vị trí tiếp theo
                             {
                                 Point root = new Point(GameProperties.GAME_COLUMN - 2, row);
                                 Point blank = pictureBoxManager.EmptyPicture;
                                 int rootValue = row * GameProperties.GAME_ROW + GameProperties.GAME_COLUMN - 2 + 2;
                                 Point picture = pictureBoxManager.GetPositionByValue(rootValue);

                                 List<Point> WayMove = new List<Point>();
                                 WayMove.Add(root);
                                 List<Point> blackList = new List<Point>();
                                 int i = 0;
                                 int j = 0;
                                 for (i = 0; i < GameProperties.GAME_ROW; i++)
                                 {
                                     for (j = 0; j < GameProperties.GAME_COLUMN; j++)
                                     {
                                         if (i == row && j == GameProperties.GAME_COLUMN - 2)
                                             break;
                                         blackList.Add(new Point(j, i));

                                     }
                                     if (j != GameProperties.GAME_COLUMN)
                                         break;
                                 }

                                 GetWay(root.X, root.Y, root, blank, picture, WayMove, blackList);

                                 int ind = WayMove.IndexOf(blank);

                                 // Process(ind, root, rootValue,WayMove);

                                 while (pictureBoxManager.ValueMatrix[root.Y, root.X] != rootValue)
                                 {
                                     pictureBoxManager.ProcessAutoClick(WayMove[ind]);
                                     ind++;
                                     if (ind == WayMove.Count)
                                         ind = 0;
                                     System.Threading.Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);
                                 }
                                 pictureBoxManager.ProcessAutoClick(new Point(GameProperties.GAME_COLUMN - 1, row + 1));
                                 System.Threading.Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);




                             }

                             //Kiểm tra 2 ô cuối có đổi chỗ cho nhau ko, Nếu ko đôi chỗ thì thực thi
                             {
                                 if (pictureBoxManager.ValueMatrix[row, GameProperties.GAME_COLUMN - 1] == row * GameProperties.GAME_ROW + GameProperties.GAME_COLUMN - 2 + 1)
                                 {
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 1, row));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 2, row));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 1, row + 1));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 2, row + 2));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 1, row + 2));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 1, row + 1));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 2, row + 1));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 2, row));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 1, row));
                                     ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 1, row + 1));

                                 }

                                 Point root = new Point(GameProperties.GAME_COLUMN - 2, row + 1);
                                 Point blank = pictureBoxManager.EmptyPicture;
                                 int rootValue = row * GameProperties.GAME_ROW + GameProperties.GAME_COLUMN - 2 + 1;
                                 Point picture = pictureBoxManager.GetPositionByValue(rootValue);

                                 List<Point> WayMove = new List<Point>();
                                 WayMove.Add(root);
                                 List<Point> blackList = new List<Point>();
                                 int i = 0;
                                 int j = 0;
                                 for (i = 0; i < row; i++)
                                 {
                                     for (j = 0; j < GameProperties.GAME_COLUMN; j++)
                                     {
                                         if (i == row && j == GameProperties.GAME_COLUMN - 2)
                                             break;
                                         blackList.Add(new Point(j, i));
                                     }
                                     if (j != GameProperties.GAME_COLUMN)
                                         break;
                                 }
                                 for (j = 0; j < GameProperties.GAME_COLUMN - 1; j++)
                                 {
                                     blackList.Add(new Point(j, i));
                                 }


                                 GetWay(root.X, root.Y, root, blank, picture, WayMove, blackList);

                                 int ind = WayMove.IndexOf(blank);

                                 // Process(ind, root, rootValue,WayMove);

                                 while (pictureBoxManager.ValueMatrix[root.Y, root.X] != rootValue)
                                 {
                                     pictureBoxManager.ProcessAutoClick(WayMove[ind]);
                                     ind++;
                                     if (ind == WayMove.Count)
                                         ind = 0;
                                     System.Threading.Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);
                                 }
                                 ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 1, row));
                                 ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 2, row));
                                 ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 2, row + 1));

                             }
                         }

                         //Xử lý 2 hàng cuối

                         for (int col = 0; col < GameProperties.GAME_COLUMN - 2; col++)
                         {
                             //Lấy ô cuối để ở vị trí ô áp cuối hàng 
                             {
                                 Point root = new Point(col, GameProperties.GAME_ROW - 2);
                                 Point blank = pictureBoxManager.EmptyPicture;
                                 int rootValue = GetPointValue(root.X, root.Y + 1);
                                 Point picture = pictureBoxManager.GetPositionByValue(rootValue);

                                 List<Point> WayMove = new List<Point>();
                                 WayMove.Add(root);
                                 List<Point> blackList = new List<Point>();
                                 int i = 0;
                                 int j = 0;
                                 for (i = 0; i < root.Y; i++)
                                 {
                                     for (j = 0; j < GameProperties.GAME_COLUMN; j++)
                                     {

                                         blackList.Add(new Point(j, i));
                                     }
                                 }
                                 for (j = 0; j < root.X; j++)
                                 {
                                     for (i = root.Y; i < GameProperties.GAME_ROW; i++)
                                     {
                                         blackList.Add(new Point(j, i));
                                     }
                                 }

                                 GetWay(root.X, root.Y, root, blank, picture, WayMove, blackList);

                                 int ind = WayMove.IndexOf(blank);

                                 // Process(ind, root, rootValue,WayMove);

                                 while (pictureBoxManager.ValueMatrix[root.Y, root.X] != rootValue)
                                 {
                                     pictureBoxManager.ProcessAutoClick(WayMove[ind]);
                                     ind++;
                                     if (ind == WayMove.Count)
                                         ind = 0;
                                     System.Threading.Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);
                                 }
                             }
                             //Đưa ô cuối về vị trí sau ô áp chót
                             {
                                 //Kiểm tra ô áp cuối và ô cuối có đổi chỗ cho nhau ko
                                 if (pictureBoxManager.ValueMatrix[GameProperties.GAME_ROW - 1, col] == GetPointValue(col, GameProperties.GAME_ROW - 2))
                                 {
                                     ClickOnPoint(new Point(col + 1, GameProperties.GAME_ROW - 1));
                                     ClickOnPoint(new Point(col, GameProperties.GAME_ROW - 1));
                                     ClickOnPoint(new Point(col, GameProperties.GAME_ROW - 2));
                                     ClickOnPoint(new Point(col + 1, GameProperties.GAME_ROW - 2));
                                     ClickOnPoint(new Point(col + 2, GameProperties.GAME_ROW - 2));
                                     ClickOnPoint(new Point(col + 2, GameProperties.GAME_ROW - 1));
                                     ClickOnPoint(new Point(col + 1, GameProperties.GAME_ROW - 1));
                                     ClickOnPoint(new Point(col + 1, GameProperties.GAME_ROW - 2));
                                     ClickOnPoint(new Point(col, GameProperties.GAME_ROW - 2));
                                     ClickOnPoint(new Point(col, GameProperties.GAME_ROW - 1));
                                     ClickOnPoint(new Point(col + 1, GameProperties.GAME_ROW - 1));
                                 }
                                 Point root = new Point(col + 1, GameProperties.GAME_ROW - 2);
                                 Point blank = pictureBoxManager.EmptyPicture;
                                 int rootValue = GetPointValue(root.X - 1, root.Y);
                                 Point picture = pictureBoxManager.GetPositionByValue(rootValue);

                                 List<Point> WayMove = new List<Point>();
                                 WayMove.Add(root);
                                 List<Point> blackList = new List<Point>();
                                 int i = 0;
                                 int j = 0;
                                 for (i = 0; i < root.Y; i++)
                                 {
                                     for (j = 0; j < GameProperties.GAME_COLUMN; j++)
                                     {

                                         blackList.Add(new Point(j, i));
                                     }
                                 }
                                 for (j = 0; j < root.X; j++)
                                 {
                                     for (i = root.Y; i < GameProperties.GAME_ROW; i++)
                                     {
                                         blackList.Add(new Point(j, i));
                                     }
                                 }

                                 GetWay(root.X, root.Y, root, blank, picture, WayMove, blackList);

                                 int ind = WayMove.IndexOf(blank);

                                 // Process(ind, root, rootValue,WayMove);

                                 while (pictureBoxManager.ValueMatrix[root.Y, root.X] != rootValue)
                                 {
                                     pictureBoxManager.ProcessAutoClick(WayMove[ind]);
                                     ind++;
                                     if (ind == WayMove.Count)
                                         ind = 0;
                                     System.Threading.Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);
                                 }

                                 for (j = GameProperties.GAME_COLUMN - 1; j >= col; j--)
                                 {
                                     ClickOnPoint(new Point(j, GameProperties.GAME_ROW - 1));
                                 }
                                 ClickOnPoint(new Point(col, GameProperties.GAME_ROW - 2));
                                 ClickOnPoint(new Point(col + 1, GameProperties.GAME_ROW - 2));
                             }




                         }

                         //Xử lý 3 ô cuối
                         {
                             Point root = new Point(GameProperties.GAME_COLUMN - 2, GameProperties.GAME_ROW - 2);
                             Point blank = pictureBoxManager.EmptyPicture;
                             int rootValue = GetPointValue(root.X, root.Y);
                             Point picture = pictureBoxManager.GetPositionByValue(rootValue);

                             List<Point> WayMove = new List<Point>();
                             WayMove.Add(root);
                             List<Point> blackList = new List<Point>();
                             int i = 0;
                             int j = 0;

                             for (i = 0; i < root.Y; i++)
                             {
                                 for (j = 0; j < GameProperties.GAME_COLUMN; j++)
                                 {

                                     blackList.Add(new Point(j, i));
                                 }
                             }
                             for (j = 0; j < root.X; j++)
                             {
                                 for (i = root.Y; i < GameProperties.GAME_ROW; i++)
                                 {
                                     blackList.Add(new Point(j, i));
                                 }
                             }

                             GetWay(root.X, root.Y, root, blank, picture, WayMove, blackList);

                             int ind = WayMove.IndexOf(blank);

                             // Process(ind, root, rootValue,WayMove);

                             while (pictureBoxManager.ValueMatrix[root.Y, root.X] != rootValue)
                             {
                                 pictureBoxManager.ProcessAutoClick(WayMove[ind]);
                                 ind++;
                                 if (ind == WayMove.Count)
                                     ind = 0;
                                 System.Threading.Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);
                             }

                             ClickOnPoint(new Point(GameProperties.GAME_COLUMN - 1, GameProperties.GAME_ROW - 1));
                             //CLickOnPoint(new Point(col + 1, GameProperties.GAME_ROW - 2));
                         }
                         
                         isSolve = false;
                         
                     }));

            threadAutoPlay_Normal.Start();

        }

        void ClickOnPoint(Point point)
        {
            pictureBoxManager.ProcessAutoClick(point);
            System.Threading.Thread.Sleep(GameProperties.SPEED_TIMER_INTERVAL);
        }

        int GetPointValue(int x, int y)
        {
            return y * GameProperties.GAME_COLUMN + x + 1;
        }

        int GetWay(int x, int y, Point root, Point blank, Point picture, List<Point> WayMove, List<Point> blackList)
        {

            Point next;
            next = new Point(x, y - 1); //Kiểm tra ô ở trên
            if (y - 1 >= 0 && !blackList.Contains(next))
            {
                if (next == root)
                {
                    if (WayMove.Contains(blank) && WayMove.Contains(picture))
                    {
                        return 1;
                    }
                }
                else
                {
                    WayMove.Add(next);
                    blackList.Add(next);
                    if (GetWay(x, y - 1, root, blank, picture, WayMove, blackList) == 1)
                    {
                        return 1;
                    }
                    WayMove.Remove(next);
                    blackList.Remove(next);

                }

            }
            next = new Point(x + 1, y); //Kiểm tra ô bên phải
            if (x + 1 < GameProperties.GAME_COLUMN && !blackList.Contains(next))
            {
                if (next == root)
                {
                    if (WayMove.Contains(blank) && WayMove.Contains(picture))
                    {
                        return 1;
                    }
                }
                else
                {
                    WayMove.Add(next);
                    blackList.Add(next);
                    if (GetWay(x + 1, y, root, blank, picture, WayMove, blackList) == 1)
                    {
                        return 1;
                    }
                    WayMove.Remove(next);
                    blackList.Remove(next);
                }

            }

            next = new Point(x, y + 1); //Kiểm tra ô bên dưới
            if (y + 1 < GameProperties.GAME_ROW && !blackList.Contains(next))
            {
                if (next == root)
                {
                    if (WayMove.Contains(blank) && WayMove.Contains(picture))
                    {
                        return 1;
                    }
                }
                else
                {
                    WayMove.Add(next);
                    blackList.Add(next);
                    if (GetWay(x, y + 1, root, blank, picture, WayMove, blackList) == 1)
                    {
                        return 1;
                    }
                    WayMove.Remove(next);
                    blackList.Remove(next);

                }

            }

            next = new Point(x - 1, y); //Kiểm tra ô bên trái
            if (x - 1 >= 0 && !blackList.Contains(next))
            {
                if (next == root)
                {
                    if (WayMove.Contains(blank) && WayMove.Contains(picture))
                    {
                        return 1;
                    }
                }
                else
                {
                    WayMove.Add(next);
                    blackList.Add(next);
                    if (GetWay(x - 1, y, root, blank, picture, WayMove, blackList) == 1)
                    {
                        return 1;
                    }
                    WayMove.Remove(next);
                    blackList.Remove(next);
                }

            }
            return 0;
        }

        #endregion AutoPlay
    }
}

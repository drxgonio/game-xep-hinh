using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXepHinh
{

    public class PictureBoxManager
    {
        public delegate void Puzzle();
        public event Puzzle OneMoveEvent;
        public event Puzzle Wingame;


        #region Properties

        private bool receive;
        public bool Receive
        {
            get { return receive; }
            set { receive = value; }
        }

        private int valueVolume;
        public int ValueVolume
        {
            get { return valueVolume; }
            set { valueVolume = value; }
        }

        int[,] valueMatrix;
        public int[,] ValueMatrix
        {
            get { return valueMatrix; }
            set { valueMatrix = value; }
        }

        List<List<PictureBox>> listPicture = new List<List<PictureBox>>();
        public List<List<PictureBox>> ListPicture
        {
            get { return listPicture; }
            set { listPicture = value; }
        }

        Point emptyPicture;
        public Point EmptyPicture
        {
            get { return emptyPicture; }
            set { emptyPicture = value; }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }


        Panel panelPicture;
        System.Media.SoundPlayer SoundClick;
        Random rand = new Random();

        #endregion


        //Constructor
        public PictureBoxManager(Panel panelPicture)
        {
            this.panelPicture = panelPicture;
            NewGame();
            SoundClick = new SoundPlayer(GameProperties.MOVE_SOUND_PATH);
        }

        #region Methods

        public void NewGame()
        {
            emptyPicture = new Point(GameProperties.GAME_ROW - 1, GameProperties.GAME_COLUMN - 1);
            listPicture.Clear();
            LoadPictureBox();
            RandomPictureBox();
        }

        //Load PictureBox vào panel
        public void LoadPictureBox()
        {
            panelPicture.Controls.Clear();
            valueMatrix = new int[GameProperties.GAME_ROW, GameProperties.GAME_COLUMN];
            List<Image> listImage = ExtensionMethods.SplitPicture();
            int index = 0;

            for (int row = 0; row < GameProperties.GAME_ROW; row++)
            {
                List<PictureBox> tempList = new List<PictureBox>();
                for (int col = 0; col < GameProperties.GAME_COLUMN; col++)
                {
                    PictureBox picture = new PictureBox();
                    picture.Size = new Size(400 / GameProperties.GAME_COLUMN, 400 / GameProperties.GAME_ROW);
                    picture.Location = new Point((int)(col * GameProperties.PANEL_WIDTH / GameProperties.GAME_COLUMN), (int)(row * GameProperties.PANEL_HEIGHT / GameProperties.GAME_ROW));
                    if (!(col == GameProperties.GAME_COLUMN - 1 && row == GameProperties.GAME_ROW - 1))
                    {
                        picture.Image = listImage[index++];
                        valueMatrix[row, col] = index;
                    }
                    else
                    {
                        valueMatrix[row, col] = -1;
                    }
                    picture.Tag = new Point(col, row);
                    picture.Click += picture_Click;
                    picture.BorderStyle = BorderStyle.Fixed3D;
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;
                    tempList.Add(picture);
                    panelPicture.Controls.Add(picture);
                }
                listPicture.Add(tempList);
            }
        }

        public void RandomPictureBox(int times = 200)
        {
            for (int i = 0; i < times; i++)
            {
                int diretion = rand.Next(4);
                int numberPicture = rand.Next(1, GameProperties.GAME_COLUMN);
                switch (diretion)
                {
                    case 0:
                        for (int j = 0; j < numberPicture; j++)
                        {
                            ToDown(true);
                        }
                        break;
                    case 1:
                        for (int j = 0; j < numberPicture; j++)
                        {
                            ToUp(true);
                        }
                        break;
                    case 2:
                        for (int j = 0; j < numberPicture; j++)
                        {
                            ToLeft(true);
                        }
                        break;
                    case 3: for (int j = 0; j < numberPicture; j++)
                        {
                            ToRight(true);
                        }
                        break;
                }

            }
        }


        public Point GetPositionByValue(int value)
        {
            for (int row = 0; row < GameProperties.GAME_ROW; row++)
            {
                for (int col = 0; col < GameProperties.GAME_COLUMN; col++)
                {
                    if (valueMatrix[row, col] == value)
                        return new Point(col, row);
                }
            }
            return new Point(-1, -1);
        }

        bool isFinalState()
        {
            int index = 1;
            for (int row = 0; row < GameProperties.GAME_ROW; row++)
            {
                for (int col = 0; col < GameProperties.GAME_COLUMN; col++)
                {
                    if (valueMatrix[row, col] != index++)
                    {
                        if (row == GameProperties.GAME_ROW - 1 && col == GameProperties.GAME_COLUMN - 1 && valueMatrix[row, col] == -1)
                            return true;
                        return false;
                    }
                }
            }
            return true;
        }

        void WinNotify()
        {
            if (this.Wingame != null)
            {
                if (receive == true)
                {
                    Sound_Win();
                }
            }
            this.Wingame();
        }

        public void ProcessAutoClick(Point point)
        {
            if ((point.X == emptyPicture.X && point.Y == emptyPicture.Y) || (point.X != emptyPicture.X && point.Y != emptyPicture.Y))
                return;
            ProcessClickDirecton(ref emptyPicture, point);

        }

        public void ProcessClickDirecton(ref Point emptyPoint, Point node)
        {
            if (node.Y == emptyPoint.Y)
            {
                while (node.X < emptyPoint.X)
                {
                    ToRight();
                }
                while (node.X > emptyPoint.X)
                {
                    ToLeft();
                }
            }
            else
            {
                while (node.Y < emptyPoint.Y)
                {
                    ToDown();
                }
                while (node.Y > emptyPoint.Y)
                {
                    ToUp();
                }
            }
        }

        void ProcessAfterMove(bool isRandom, bool isAuto)
        {
            if (isRandom)
                return;
            if (this.OneMoveEvent != null)
                this.OneMoveEvent();
            if (isAuto)
                return;
            if (isFinalState())
            {
                WinNotify();
            }
        }

        public void ProcessDirecton(Point currentPoint, Point node)
        {
            if (node.Y == currentPoint.Y)
            {
                if (node.X < currentPoint.X)
                {
                    ToRight(false, true);
                }
                if (node.X > currentPoint.X)
                {
                    ToLeft(false, true);
                }
            }
            else
            {
                if (node.Y < currentPoint.Y)
                {
                    ToDown(false, true);
                }
                if (node.Y > currentPoint.Y)
                {
                    ToUp(false, true);
                }
            }
        }

        public void ToDown(bool isRandom = false, bool isAuto = false)
        {
            if (emptyPicture.Y <= 0)
                return;
            listPicture[emptyPicture.Y][emptyPicture.X].Image = listPicture[emptyPicture.Y - 1][emptyPicture.X].Image;
            valueMatrix[emptyPicture.Y, emptyPicture.X] = valueMatrix[emptyPicture.Y - 1, emptyPicture.X];
            listPicture[emptyPicture.Y - 1][emptyPicture.X].Image = null;
            valueMatrix[emptyPicture.Y - 1, emptyPicture.X] = -1;
            emptyPicture.Y--;
            ProcessAfterMove(isRandom, isAuto);
        }

        public void ToUp(bool isRandom = false, bool isAuto = false)
        {
            if (emptyPicture.Y >= GameProperties.GAME_ROW - 1)
                return;
            listPicture[emptyPicture.Y][emptyPicture.X].Image = listPicture[emptyPicture.Y + 1][emptyPicture.X].Image;
            valueMatrix[emptyPicture.Y, emptyPicture.X] = valueMatrix[emptyPicture.Y + 1, emptyPicture.X];
            listPicture[emptyPicture.Y + 1][emptyPicture.X].Image = null;
            valueMatrix[emptyPicture.Y + 1, emptyPicture.X] = -1;
            emptyPicture.Y++;
            ProcessAfterMove(isRandom, isAuto);
        }

        public void ToLeft(bool isRandom = false, bool isAuto = false)
        {
            if (emptyPicture.X >= GameProperties.GAME_COLUMN - 1)
                return;
            listPicture[emptyPicture.Y][emptyPicture.X].Image = listPicture[emptyPicture.Y][emptyPicture.X + 1].Image;
            valueMatrix[emptyPicture.Y, emptyPicture.X] = valueMatrix[emptyPicture.Y, emptyPicture.X + 1];
            listPicture[emptyPicture.Y][emptyPicture.X + 1].Image = null;
            valueMatrix[emptyPicture.Y, emptyPicture.X + 1] = -1;
            emptyPicture.X++;
            ProcessAfterMove(isRandom, isAuto);
        }

        public void ToRight(bool isRandom = false, bool isAuto = false)
        {
            if (emptyPicture.X <= 0)
                return;
            listPicture[emptyPicture.Y][emptyPicture.X].Image = listPicture[emptyPicture.Y][emptyPicture.X - 1].Image;
            valueMatrix[emptyPicture.Y, emptyPicture.X] = valueMatrix[emptyPicture.Y, emptyPicture.X - 1];
            listPicture[emptyPicture.Y][emptyPicture.X - 1].Image = null;
            valueMatrix[emptyPicture.Y, emptyPicture.X - 1] = -1;
            emptyPicture.X--;
            ProcessAfterMove(isRandom, isAuto);
        }

        //Âm thanh win
        public void Sound_Win()
        {
            WMPLib.WindowsMediaPlayer SoundWin = new WMPLib.WindowsMediaPlayer();
            SoundWin.URL = GameProperties.WINGAME_SOUND_PATH;
            SoundWin.settings.volume = ValueVolume;
        }

        //Âm thanh khi click chuột
        public void Sound_Click()
        {
            WMPLib.WindowsMediaPlayer SoundClick = new WMPLib.WindowsMediaPlayer();
            SoundClick.URL = GameProperties.MOVE_SOUND_PATH;
            SoundClick.settings.volume = ValueVolume;
        }

        #endregion 

        #region Events

        //Sự kiện click vào cách ảnh nhỏ
        void picture_Click(object sender, EventArgs e)
        {
            if (receive == true)
            {
                Sound_Click();
            }
            if (IsBusy)
                return;
            PictureBox picture = sender as PictureBox;
            Point point = (Point)picture.Tag;
            if ((point.X == emptyPicture.X && point.Y == emptyPicture.Y) || (point.X != emptyPicture.X && point.Y != emptyPicture.Y))
                return;
            ProcessClickDirecton(ref emptyPicture, point);

        }

        #endregion




        

       
    }

}

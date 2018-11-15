using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXepHinh
{
    public class GameInfoManager
    {
        #region Controls

        Panel panelGameInfo;
        PictureBox previewImage;
        Label lbTimeMinute;
        Label lbTimeSecond;
        Timer timer;
        TextBox tbPictureMoved;
        ComboBox cbbSpeed;

        #endregion

        #region Properties

        int pictureMoved;

        #endregion


        //Constructor
        public GameInfoManager(Panel panelGameInfo, PictureBox previewImage, Label lbTimeMinute, Label lbTimeSecond, TextBox tbPictureMoved, ComboBox cbbSpeed)
        {
            this.panelGameInfo = panelGameInfo;
            this.previewImage = previewImage;
            this.lbTimeMinute = lbTimeMinute;
            this.lbTimeSecond = lbTimeSecond;
            this.tbPictureMoved = tbPictureMoved;
            this.cbbSpeed = cbbSpeed;
            this.pictureMoved = 0;
            tbPictureMoved.Text = pictureMoved.ToString();
            LoadPreviewImage();
            AddTimer();
            AddValueToComboBox();
        }

        #region Methods


        public void NewGame()
        {
            ResetTimer();
            SetMoveToZero();
            LoadPreviewImage();
            StartTimer();
        }

        public void StartTimer()
        {
            timer.Start();
        }

        public void StopTimer()
        {
            timer.Stop();
        }

        void AddValueToComboBox()
        {
            Dictionary<string, float> speed = new Dictionary<string, float>();
            speed.Add("x 0.5", 0.5f);
            speed.Add("x 1", 1);
            speed.Add("x 2", 2);
            speed.Add("x 5", 5);
            speed.Add("x 10", 10);
            speed.Add("x 50", 50);
            speed.Add("x 200", 200);
        
            cbbSpeed.DataSource = speed.ToList();
            cbbSpeed.DisplayMember = "Key";
            //cbbSpeed.ValueMember = "Value";
            cbbSpeed.SelectedIndex = 1;
        }

        public void LoadPreviewImage()
        {
            Image img = ExtensionMethods.GetImageFromFile(GameProperties.IMAGE_SOURCE);
            previewImage.Image = img;
        }

        void AddTimer()
        {
            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            int second = Convert.ToInt32(lbTimeSecond.Text) + 1;
            if (second == 60)
            {
                int minute = Convert.ToInt32(lbTimeMinute.Text) + 1;
                lbTimeMinute.Text = minute.ToString("D2");
                second = 0;
            }
            lbTimeSecond.Text = second.ToString("D2");

        }

        public void IncreaseMove()
        {
            pictureMoved++;
            tbPictureMoved.Invoke((MethodInvoker)(() =>
            {
                tbPictureMoved.Text = pictureMoved.ToString();
            }));
            
        }

        public void SetMoveToZero()
        {
            pictureMoved = 0;
            tbPictureMoved.Text = "0";
        }

        void ResetTimer()
        {
            lbTimeMinute.Text = "00";
            lbTimeSecond.Text = "00";
        }

        #endregion
    }
}

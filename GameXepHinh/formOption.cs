using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXepHinh
{
    public partial class formOption : Form
    {
        //truyền Properties cho form1
        public delegate void SaveGameProperties(string imageSouce, int gameSize);
        public event SaveGameProperties SaveGameProperties_Event;
        //-------------------------------------

        int sizeSelected;
        string lineSelected;
        PictureBox picboxSelected;

        List<PictureBox> listPictureBox = new List<PictureBox>();
        public formOption()
        {
            sizeSelected = GameProperties.GAME_COLUMN;
            lineSelected = GameProperties.IMAGE_SOURCE;
            InitializeComponent();
            LoadSelectPicture();//Show hình ảnh lên để chọn
            LoadSelectedRadioButton();//Show kích thước để chọn
        }
        //Show kích thước để chọn
        void LoadSelectedRadioButton()
        {

            switch (sizeSelected)
            {
                case 3:

                    radiosize3.Checked = true;
                    break;
                case 4:

                    radiosize4.Checked = true;
                    break;
                case 5:

                    radiosize5.Checked = true;
                    break;
            }
        }
        //-------------------------

        //Show hình lên
        void LoadSelectPicture()
        {
            panelListImage.Controls.Clear();//Xóa hết các hình trong panel
            listPictureBox.Clear();//Xóa hết các hình trong list
            //Đọc folder nếu chưa có thì tạo mới
            if (!File.Exists("picture.dat"))
            {
                using (File.Create("picture.dat"))
                {
                    return;
                }
            }
            //------------------------------------

            //Đọc file chứa các đường link hình ảnh
            var read = File.ReadAllLines("picture.dat");
            foreach (string line in read)
            {
                
                Image img = ExtensionMethods.GetImageFromFile(line);
                PictureBox PicBox = new PictureBox();
                PicBox.Size = new Size(100, 100);
                PicBox.Image = img;
                PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PicBox.Padding = new System.Windows.Forms.Padding(5);
                PicBox.BackColor = Color.Transparent;
                PicBox.Click += PicBox_Click;
                PicBox.Tag = line;

                if (lineSelected == line)
                {
                    picboxSelected = PicBox;
                    PicBox.BackColor = Color.Red;
                }
                panelListImage.Controls.Add(PicBox);
                listPictureBox.Add(PicBox);
            }
            //--------------------------------------------
        }
        //-----------------------------
        

        void PicBox_Click(object sender, EventArgs e)
        {
            try
            {
                picboxSelected.BackColor = Color.Transparent;
            }
            catch{}
            PictureBox picbox = sender as PictureBox;
            picbox.BackColor = Color.Red;
            picboxSelected = picbox;
            lineSelected = (string)picbox.Tag;
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog addlog = new OpenFileDialog();//Mở dialag lên
            addlog.Title = "Search image";
            addlog.Filter = "Image(*.jpg;*.jpeg;*.bmp;*.png)|*.jpg;*.jpeg;*.bmp;*.png|All file types(*.*)|*.*";
            //Lấy link của hình
            if (addlog.ShowDialog() == DialogResult.OK)
            {
                CopyFileToImages(addlog.FileName);//Coppy hình vào picture.dat
                LoadSelectPicture();//Load lại khung lựa chọn hình
            }
        }

        void CopyFileToImages(string sourceFile, string num = "")
        {
            string strNum = "";
            if (num != "")
                strNum = "(" + num + ")";//Nhận từ hàm đệ qui để cộng thêm vào tên
            try
            {

                File.Copy(sourceFile, "images\\" + Path.GetFileNameWithoutExtension(sourceFile) + strNum + Path.GetExtension(sourceFile));//coppy hình vào file sourse
                //Ghi link hình mới add vào file picture.dat
                using (StreamWriter addfile = new StreamWriter("picture.dat", true))
                {
                    addfile.WriteLine("images\\" + Path.GetFileNameWithoutExtension(sourceFile) + strNum + Path.GetExtension(sourceFile));
                }
                //--------------------------------------------

            }
            catch (IOException)//bị lỗi trùng tên
            {
                int n;
                if (num == "")//trùng lần thứ nhất khi đệ qui
                    n = 1;
                else
                    n = Convert.ToInt32(num);
                CopyFileToImages(sourceFile, (n + 1).ToString());//trùng tên thì cộng thêm số ở đuôi rồi đệ quy để kiểm tra và lưu lại tên hình
            }

        }

        private void BtSaveChange_Click(object sender, EventArgs e)
        {
            if (picboxSelected == null)//lỡ xóa hình đang chọn và picboxSelected không có thì bắt người ta chọn hình
            {
                MessageBox.Show("Please select an image!");
                return;
            }
            this.Close();
            if (this.SaveGameProperties_Event != null)
                this.SaveGameProperties_Event(lineSelected, sizeSelected);//truyền size và dòng của link hình trong file picture.dat cho form1

        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            List<string> read = File.ReadAllLines("picture.dat").ToList();//truyền hết các dòng cho 1 list
            if (read.Count <= 1)//Nếu còn có 1 hình thì không được xóa
            {
                MessageBox.Show("Cannot delete this image!");
                return;
            }
            read.Remove(lineSelected);//Xóa cái dòng đang muốn xóa trong list
            //Đọc lại link vào file bằng cách tạo file mới cùng tên đè lên
            using (FileStream addfile = new FileStream("picture.dat", FileMode.Create))
            {
                using (StreamWriter file = new StreamWriter(addfile))
                {
                    foreach (string item in read)
                    {
                        file.WriteLine(item);//ghi lại từng dòng của list vào file sau khi list đã xóa dòng cần xóa
                    }
                }
            }
            //-----------------------------------------------------------
            LoadSelectPicture();
            File.Delete(lineSelected);
            lineSelected = null;
            picboxSelected = null;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            if (this.SaveGameProperties_Event != null)
                if(lineSelected==null)//khi người ta bấm cancel hình lúc này không được chọn bất kì cái nào
                {
                    this.SaveGameProperties_Event("images\\picture2.png", sizeSelected);
                }
            this.Close();
        }

        private void radio_size3x3_CheckedChanged(object sender, EventArgs e)
        {
            sizeSelected = 3;
        }

        private void radiosize_4x4_CheckedChanged(object sender, EventArgs e)
        {
            sizeSelected = 4;
        }

        private void radiosize_5x5_CheckedChanged(object sender, EventArgs e)
        {
            sizeSelected = 5;
        }
    }
}

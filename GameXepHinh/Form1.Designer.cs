namespace GameXepHinh
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.panelGameInfo = new System.Windows.Forms.Panel();
            this.bt_controlvolume = new System.Windows.Forms.Button();
            this.trackbar_volume = new System.Windows.Forms.TrackBar();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnStopSolve = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPictureMoved = new System.Windows.Forms.TextBox();
            this.cbbSpeed = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTimeSecond = new System.Windows.Forms.Label();
            this.lbTimeMinute = new System.Windows.Forms.Label();
            this.btnAutoPlay = new System.Windows.Forms.Button();
            this.previewImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panelGameInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_volume)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(620, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.optionToolStripMenuItem.Text = "Option";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem1.Text = "A* Algorithm";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem2.Text = "Normal ";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.guideToolStripMenuItem.Text = "Guide";
            this.guideToolStripMenuItem.Click += new System.EventHandler(this.guideToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelPicture
            // 
            this.panelPicture.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPicture.Location = new System.Drawing.Point(8, 27);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(401, 401);
            this.panelPicture.TabIndex = 1;
            // 
            // panelGameInfo
            // 
            this.panelGameInfo.Controls.Add(this.bt_controlvolume);
            this.panelGameInfo.Controls.Add(this.trackbar_volume);
            this.panelGameInfo.Controls.Add(this.btnNewGame);
            this.panelGameInfo.Controls.Add(this.btnStopSolve);
            this.panelGameInfo.Controls.Add(this.button1);
            this.panelGameInfo.Controls.Add(this.label3);
            this.panelGameInfo.Controls.Add(this.tbPictureMoved);
            this.panelGameInfo.Controls.Add(this.cbbSpeed);
            this.panelGameInfo.Controls.Add(this.label2);
            this.panelGameInfo.Controls.Add(this.panel1);
            this.panelGameInfo.Controls.Add(this.btnAutoPlay);
            this.panelGameInfo.Controls.Add(this.previewImage);
            this.panelGameInfo.Location = new System.Drawing.Point(418, 27);
            this.panelGameInfo.Name = "panelGameInfo";
            this.panelGameInfo.Size = new System.Drawing.Size(198, 400);
            this.panelGameInfo.TabIndex = 2;
            // 
            // bt_controlvolume
            // 
            this.bt_controlvolume.BackColor = System.Drawing.Color.Transparent;
            this.bt_controlvolume.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_controlvolume.BackgroundImage")));
            this.bt_controlvolume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_controlvolume.Location = new System.Drawing.Point(172, 374);
            this.bt_controlvolume.Name = "bt_controlvolume";
            this.bt_controlvolume.Size = new System.Drawing.Size(23, 23);
            this.bt_controlvolume.TabIndex = 17;
            this.bt_controlvolume.UseVisualStyleBackColor = false;
            this.bt_controlvolume.Click += new System.EventHandler(this.bt_controlvolume_Click);
            this.bt_controlvolume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoCapture_KeyDown);
            // 
            // trackbar_volume
            // 
            this.trackbar_volume.AutoSize = false;
            this.trackbar_volume.Location = new System.Drawing.Point(89, 374);
            this.trackbar_volume.Name = "trackbar_volume";
            this.trackbar_volume.Size = new System.Drawing.Size(86, 23);
            this.trackbar_volume.TabIndex = 16;
            this.trackbar_volume.Scroll += new System.EventHandler(this.trackbar_volume_Scroll);
            this.trackbar_volume.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoCapture_KeyDown);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(14, 294);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 14;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            this.btnNewGame.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoCapture_KeyDown);
            // 
            // btnStopSolve
            // 
            this.btnStopSolve.Location = new System.Drawing.Point(3, 374);
            this.btnStopSolve.Name = "btnStopSolve";
            this.btnStopSolve.Size = new System.Drawing.Size(80, 23);
            this.btnStopSolve.TabIndex = 13;
            this.btnStopSolve.Text = "Abort";
            this.btnStopSolve.UseVisualStyleBackColor = true;
            this.btnStopSolve.Click += new System.EventHandler(this.btnStopSolve_Click);
            this.btnStopSolve.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoCapture_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Shuffle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoCapture_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Pictures Moved:";
            // 
            // tbPictureMoved
            // 
            this.tbPictureMoved.Location = new System.Drawing.Point(107, 252);
            this.tbPictureMoved.Name = "tbPictureMoved";
            this.tbPictureMoved.ReadOnly = true;
            this.tbPictureMoved.Size = new System.Drawing.Size(88, 20);
            this.tbPictureMoved.TabIndex = 8;
            this.tbPictureMoved.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPictureMoved.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoCapture_KeyDown);
            // 
            // cbbSpeed
            // 
            this.cbbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSpeed.FormattingEnabled = true;
            this.cbbSpeed.Location = new System.Drawing.Point(132, 347);
            this.cbbSpeed.Name = "cbbSpeed";
            this.cbbSpeed.Size = new System.Drawing.Size(63, 21);
            this.cbbSpeed.TabIndex = 7;
            this.cbbSpeed.SelectedValueChanged += new System.EventHandler(this.cbbSpeed_SelectedValueChanged);
            this.cbbSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoCapture_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Speed";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbTimeSecond);
            this.panel1.Controls.Add(this.lbTimeMinute);
            this.panel1.Location = new System.Drawing.Point(3, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 45);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = ":";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTimeSecond
            // 
            this.lbTimeSecond.AutoSize = true;
            this.lbTimeSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeSecond.Location = new System.Drawing.Point(100, 12);
            this.lbTimeSecond.Margin = new System.Windows.Forms.Padding(0);
            this.lbTimeSecond.Name = "lbTimeSecond";
            this.lbTimeSecond.Size = new System.Drawing.Size(30, 24);
            this.lbTimeSecond.TabIndex = 0;
            this.lbTimeSecond.Text = "00";
            this.lbTimeSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTimeMinute
            // 
            this.lbTimeMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeMinute.Location = new System.Drawing.Point(43, 12);
            this.lbTimeMinute.Margin = new System.Windows.Forms.Padding(0);
            this.lbTimeMinute.Name = "lbTimeMinute";
            this.lbTimeMinute.Size = new System.Drawing.Size(50, 24);
            this.lbTimeMinute.TabIndex = 0;
            this.lbTimeMinute.Text = "00";
            this.lbTimeMinute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAutoPlay
            // 
            this.btnAutoPlay.Location = new System.Drawing.Point(3, 345);
            this.btnAutoPlay.Name = "btnAutoPlay";
            this.btnAutoPlay.Size = new System.Drawing.Size(80, 23);
            this.btnAutoPlay.TabIndex = 3;
            this.btnAutoPlay.Text = "Auto Play";
            this.btnAutoPlay.UseVisualStyleBackColor = true;
            this.btnAutoPlay.Click += new System.EventHandler(this.btnAutoPlay_Click);
            this.btnAutoPlay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NoCapture_KeyDown);
            // 
            // previewImage
            // 
            this.previewImage.Location = new System.Drawing.Point(3, 3);
            this.previewImage.Name = "previewImage";
            this.previewImage.Size = new System.Drawing.Size(192, 192);
            this.previewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewImage.TabIndex = 1;
            this.previewImage.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(620, 440);
            this.Controls.Add(this.panelGameInfo);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Picture Puzzle Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelGameInfo.ResumeLayout(false);
            this.panelGameInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_volume)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.Panel panelGameInfo;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTimeSecond;
        private System.Windows.Forms.Label lbTimeMinute;
        private System.Windows.Forms.Button btnAutoPlay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPictureMoved;
        private System.Windows.Forms.ComboBox cbbSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStopSolve;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button bt_controlvolume;
        public System.Windows.Forms.TrackBar trackbar_volume;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}


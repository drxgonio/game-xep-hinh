namespace GameXepHinh
{
    partial class formOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formOption));
            this.PanelSize = new System.Windows.Forms.Panel();
            this.radiosize5 = new System.Windows.Forms.RadioButton();
            this.radiosize4 = new System.Windows.Forms.RadioButton();
            this.radiosize3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BtSaveChange = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.BtDelete = new System.Windows.Forms.Button();
            this.BtAdd = new System.Windows.Forms.Button();
            this.panelListImage = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSize
            // 
            this.PanelSize.Controls.Add(this.radiosize5);
            this.PanelSize.Controls.Add(this.radiosize4);
            this.PanelSize.Controls.Add(this.radiosize3);
            this.PanelSize.Location = new System.Drawing.Point(411, 70);
            this.PanelSize.Name = "PanelSize";
            this.PanelSize.Size = new System.Drawing.Size(145, 151);
            this.PanelSize.TabIndex = 0;
            // 
            // radiosize5
            // 
            this.radiosize5.AutoSize = true;
            this.radiosize5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiosize5.Location = new System.Drawing.Point(15, 108);
            this.radiosize5.Name = "radiosize5";
            this.radiosize5.Size = new System.Drawing.Size(105, 24);
            this.radiosize5.TabIndex = 2;
            this.radiosize5.Tag = "5";
            this.radiosize5.Text = "Size 5 x 5";
            this.radiosize5.UseVisualStyleBackColor = true;
            this.radiosize5.CheckedChanged += new System.EventHandler(this.radiosize_5x5_CheckedChanged);
            // 
            // radiosize4
            // 
            this.radiosize4.AutoSize = true;
            this.radiosize4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiosize4.Location = new System.Drawing.Point(15, 64);
            this.radiosize4.Name = "radiosize4";
            this.radiosize4.Size = new System.Drawing.Size(105, 24);
            this.radiosize4.TabIndex = 1;
            this.radiosize4.Tag = "4";
            this.radiosize4.Text = "Size 4 x 4";
            this.radiosize4.UseVisualStyleBackColor = true;
            this.radiosize4.CheckedChanged += new System.EventHandler(this.radiosize_4x4_CheckedChanged);
            // 
            // radiosize3
            // 
            this.radiosize3.AutoSize = true;
            this.radiosize3.Checked = true;
            this.radiosize3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radiosize3.Location = new System.Drawing.Point(15, 20);
            this.radiosize3.Name = "radiosize3";
            this.radiosize3.Size = new System.Drawing.Size(105, 24);
            this.radiosize3.TabIndex = 0;
            this.radiosize3.TabStop = true;
            this.radiosize3.Tag = "3";
            this.radiosize3.Text = "Size 3 x 3";
            this.radiosize3.UseVisualStyleBackColor = true;
            this.radiosize3.CheckedChanged += new System.EventHandler(this.radio_size3x3_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(422, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Size";
            // 
            // BtSaveChange
            // 
            this.BtSaveChange.BackColor = System.Drawing.Color.Blue;
            this.BtSaveChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtSaveChange.ForeColor = System.Drawing.Color.White;
            this.BtSaveChange.Location = new System.Drawing.Point(369, 294);
            this.BtSaveChange.Name = "BtSaveChange";
            this.BtSaveChange.Size = new System.Drawing.Size(102, 30);
            this.BtSaveChange.TabIndex = 8;
            this.BtSaveChange.Text = "SAVE";
            this.BtSaveChange.UseVisualStyleBackColor = false;
            this.BtSaveChange.Click += new System.EventHandler(this.BtSaveChange_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.BackColor = System.Drawing.Color.Blue;
            this.BtCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCancel.ForeColor = System.Drawing.Color.White;
            this.BtCancel.Location = new System.Drawing.Point(477, 294);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(102, 30);
            this.BtCancel.TabIndex = 7;
            this.BtCancel.Text = "CANCEL";
            this.BtCancel.UseVisualStyleBackColor = false;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // BtDelete
            // 
            this.BtDelete.BackColor = System.Drawing.Color.Blue;
            this.BtDelete.ForeColor = System.Drawing.Color.White;
            this.BtDelete.Location = new System.Drawing.Point(187, 267);
            this.BtDelete.Name = "BtDelete";
            this.BtDelete.Size = new System.Drawing.Size(75, 23);
            this.BtDelete.TabIndex = 0;
            this.BtDelete.Text = "Delete";
            this.BtDelete.UseVisualStyleBackColor = false;
            this.BtDelete.Click += new System.EventHandler(this.BtDelete_Click);
            // 
            // BtAdd
            // 
            this.BtAdd.BackColor = System.Drawing.Color.Blue;
            this.BtAdd.ForeColor = System.Drawing.Color.White;
            this.BtAdd.Location = new System.Drawing.Point(71, 267);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(75, 23);
            this.BtAdd.TabIndex = 10;
            this.BtAdd.Text = "Add Picture";
            this.BtAdd.UseVisualStyleBackColor = false;
            this.BtAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // panelListImage
            // 
            this.panelListImage.AutoScroll = true;
            this.panelListImage.BackColor = System.Drawing.Color.White;
            this.panelListImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelListImage.Location = new System.Drawing.Point(12, 12);
            this.panelListImage.Name = "panelListImage";
            this.panelListImage.Size = new System.Drawing.Size(320, 249);
            this.panelListImage.TabIndex = 11;
            // 
            // formOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(610, 353);
            this.Controls.Add(this.panelListImage);
            this.Controls.Add(this.BtAdd);
            this.Controls.Add(this.BtDelete);
            this.Controls.Add(this.BtSaveChange);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanelSize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formOption";
            this.Text = "Option";
            this.PanelSize.ResumeLayout(false);
            this.PanelSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelSize;
        private System.Windows.Forms.RadioButton radiosize5;
        private System.Windows.Forms.RadioButton radiosize4;
        private System.Windows.Forms.RadioButton radiosize3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtSaveChange;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Button BtDelete;
        private System.Windows.Forms.Button BtAdd;
        private System.Windows.Forms.FlowLayoutPanel panelListImage;
    }
}
namespace Crystok
{
    partial class yardim
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tel = new System.Windows.Forms.TextBox();
            this.isim = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dadi = new System.Windows.Forms.ComboBox();
            this.sorun = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lisans = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Crystok.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(32, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 63);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox1.Controls.Add(this.tel);
            this.groupBox1.Controls.Add(this.isim);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dadi);
            this.groupBox1.Controls.Add(this.sorun);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Font = new System.Drawing.Font("Sitka Banner", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 250);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destek Talebi";
            // 
            // tel
            // 
            this.tel.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.tel.Location = new System.Drawing.Point(150, 99);
            this.tel.Multiline = true;
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(121, 25);
            this.tel.TabIndex = 54;
            // 
            // isim
            // 
            this.isim.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.isim.Location = new System.Drawing.Point(150, 71);
            this.isim.Multiline = true;
            this.isim.Name = "isim";
            this.isim.Size = new System.Drawing.Size(121, 25);
            this.isim.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(16, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = "TEL:";
            // 
            // dadi
            // 
            this.dadi.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.dadi.FormattingEnabled = true;
            this.dadi.Items.AddRange(new object[] {
            "Program Hata",
            "Veri Kaybı",
            "Teknik Destek",
            "Yardım",
            "Arıza Kaydı",
            "Lisans",
            "Şifre Unutum",
            "Donanımsal Problem",
            "Taşıma"});
            this.dadi.Location = new System.Drawing.Point(150, 39);
            this.dadi.Name = "dadi";
            this.dadi.Size = new System.Drawing.Size(121, 27);
            this.dadi.TabIndex = 1;
            this.dadi.Text = "Seçin.";
            // 
            // sorun
            // 
            this.sorun.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.sorun.Location = new System.Drawing.Point(150, 129);
            this.sorun.Multiline = true;
            this.sorun.Name = "sorun";
            this.sorun.Size = new System.Drawing.Size(469, 81);
            this.sorun.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "İSMİNİZ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(17, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "SORUNUZU YAZINIZ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "DESTEK TALEBİ:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.button3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.button3.Location = new System.Drawing.Point(498, 215);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 30);
            this.button3.TabIndex = 5;
            this.button3.Text = "Talebi Gönder";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Banner", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(67, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 65;
            this.label4.Text = "0501 330 19 17";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(38, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 20);
            this.label6.TabIndex = 66;
            this.label6.Text = "TEL";
            // 
            // lisans
            // 
            this.lisans.AutoSize = true;
            this.lisans.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.lisans.ForeColor = System.Drawing.Color.Teal;
            this.lisans.Location = new System.Drawing.Point(297, 89);
            this.lisans.Name = "lisans";
            this.lisans.Size = new System.Drawing.Size(42, 20);
            this.lisans.TabIndex = 55;
            this.lisans.Text = "Lisans";
            // 
            // yardim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(650, 367);
            this.Controls.Add(this.lisans);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "yardim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRY Yardım Bölümü";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tel;
        private System.Windows.Forms.TextBox isim;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox dadi;
        private System.Windows.Forms.TextBox sorun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lisans;
    }
}
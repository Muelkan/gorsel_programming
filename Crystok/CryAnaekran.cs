using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace Crystok
{
    public partial class CryAnaekran : Form
    {
        int a=0;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ClassStyle |= 0x20000;

                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }
        double bb;
        string starih = DateTime.Now.Day+"-"+DateTime.Now.Month + "-" + DateTime.Now.Year;
        public string kim="admin";
        CryCikis cc = new CryCikis();
        Veritabani vt = new Veritabani();
        public string isim, yetki;
        public CryAnaekran()
        {
            kimisorgula();
            InitializeComponent();
            yukleme();
            this.TransparencyKey = Color.WhiteSmoke;
            this.BackColor = Color.WhiteSmoke;
              
        }
        void stkdurum()
        {
            pencere.Controls.Clear();
            SabitStokdurum f1 = new SabitStokdurum();
            f1.TopLevel = false;
            pencere.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }
        public void detay()
        {
            vt.bag.Open();
            MySqlCommand say = new MySqlCommand("select  count(*) from stok where adet>0", vt.bag);
            yaziStok.Text = say.ExecuteScalar().ToString() + " Ürün";
            vt.bag.Close();
        }
      public  void yukleme()
        {
            ListBox lit = new ListBox();
            lit.Items.Clear();
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis where aytarih='"+starih+"' ", vt.bag);  
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                bb = 0;
                lit.Items.Add(oku["fiyat"].ToString());
                double sonuc = 0;
                for (int i = 0; i < lit.Items.Count; i++)
                {
                    sonuc += Convert.ToDouble(lit.Items[i]);
                }
                bb += sonuc;
                fiyati.Text = bb.ToString() + " TL";
            }
            vt.bag.Close();
        }
        private void CryAnaekran_Load(object sender, EventArgs e)
        {
            
            stkdurum();   
            detay();
            yaziYetkili.Text = kim.ToString();
        }

        public void kimisorgula()
        {
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from kullanici where kullanici='" + kim + "'", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                isim = oku["isim"].ToString();
                yetki = oku["yetki"].ToString();
            }
            vt.bag.Close();

        }
        private void btnYenistok_Click(object sender, EventArgs e)
        {
            if (a != 1)
            {
                pencere.Controls.Clear();
                SabitStokdurum f1 = new SabitStokdurum();
                f1.TopLevel = false;
                pencere.Controls.Add(f1);
                f1.Show();
                f1.Dock = DockStyle.Fill;
                f1.BringToFront();
            }
            a = 1;
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {      if (a != 2)
            {
            pencere.Controls.Clear();
            SabitYenistok f1 = new SabitYenistok();
            f1.TopLevel = false;
            pencere.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
            }
        a = 2;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            CryGiris cg = new CryGiris();
            cg.kod.Text = "Seçiniz...";
            cg.ShowDialog();
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {

            cc.yukle();
            cc.kod.Text = "Seçiniz...";
            cc.ShowDialog();
        }
        private void btnRapor_Click(object sender, EventArgs e)
        {
               if (a != 4)
            {
            pencere.Controls.Clear();
            SabitRapolama f1 = new SabitRapolama();
            f1.TopLevel = false;
            pencere.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
            }
               a = 4;
        }
        private void btnYenidepo_Click(object sender, EventArgs e)
        {
            if (a != 3)
            {
                pencere.Controls.Clear();
                SabitSatis f1 = new SabitSatis();
                f1.TopLevel = false;
                pencere.Controls.Add(f1);
                f1.Show();
                f1.Dock = DockStyle.Fill;
                f1.BringToFront();
            }
            a = 3;
            
        }
        private void pencere_Paint(object sender, PaintEventArgs e)
        {
        
        }

        private void btnAra_Click_1(object sender, EventArgs e)
        {
            CryDetay st = new CryDetay();
            st.guc.Visible = true;
            st.guc.Text = "Satış Yap";
            st.kilitle();
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Çıkış Yapmak İstediğinizden Eminmisiniz?","DURUM",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (sor == DialogResult.Yes)
            {
                giris gr = new giris();
                gr.Show();
                this.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ayarlar ar = new ayarlar();
            ar.Show();
        }

        private void btnYenistok_MouseLeave(object sender, EventArgs e)
        {

            btnYenistok.Image = Properties.Resources.stokdurumu;
        }

        private void btnYenistok_MouseMove(object sender, MouseEventArgs e)
        {
            btnYenistok.Image = Properties.Resources.stokdurumup;
        }

        private void btnSatis_MouseMove(object sender, MouseEventArgs e)
        {
            btnSatis.Image = Properties.Resources._1p;
        }

        private void btnSatis_MouseLeave(object sender, EventArgs e)
        {
            btnSatis.Image = Properties.Resources._1;
        }

        private void btnYenidepo_MouseMove(object sender, MouseEventArgs e)
        {
            btnYenidepo.Image = Properties.Resources._6p;
        }

        private void btnYenidepo_MouseLeave(object sender, EventArgs e)
        {
            btnYenidepo.Image = Properties.Resources._6;
        }

        private void btnRapor_MouseMove(object sender, MouseEventArgs e)
        {
            btnRapor.Image = Properties.Resources._3p;
        }

        private void btnRapor_MouseLeave(object sender, EventArgs e)
        {
            btnRapor.Image = Properties.Resources._3;
        }

        private void btnCikis_MouseMove(object sender, MouseEventArgs e)
        {
            btnCikis.Image = Properties.Resources._5p;
        }

        private void btnCikis_MouseLeave(object sender, EventArgs e)
        {
            btnCikis.Image = Properties.Resources._5;
        }

        private void btnGiris_MouseMove(object sender, MouseEventArgs e)
        {
            btnGiris.Image = Properties.Resources._4p;
        }

        private void btnGiris_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.Image = Properties.Resources._4;
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox6.Image = Properties.Resources.yardimp;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.yardim;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.ayarlarp;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.ayarlar;

        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.Image = Properties.Resources.cikisp;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.cikis;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void edAra_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            yardim yr = new yardim();
            yr.Show();
        }

        private void yaziYetkili_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

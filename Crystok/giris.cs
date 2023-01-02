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

namespace Crystok
{
    public partial class giris : Form
    {
        string hava = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

        int a = 0;
        public giris()
        {
            InitializeComponent();
        }
        void girisim()
        {
            label1.Visible = true;

            Veritabani vr = new Veritabani();
            vr.bag.Open();
            MySqlCommand co = new MySqlCommand("select * from kullanici where kullanici='" + etKullanici.Text.ToString() + "'and sifre='" + etSifre.Text.ToString() + "' ", vr.bag);


            MySqlDataReader dr = co.ExecuteReader();

            if (dr.Read())
            {

                CryAnaekran ae = new CryAnaekran();

                ae.kim = etKullanici.Text.ToString();
                ae.Show();
                this.Hide();
            }
            else
            {
                label1.Visible = false;

                MessageBox.Show("Kullanici adı veya şifre yanıştir.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            vr.bag.Close();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            girisim();
            CryAnaekran ae = new CryAnaekran();
            ae.kim = etKullanici.Text;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void etKullanici_MouseClick(object sender, MouseEventArgs e)
        {
            etKullanici.Clear();
        }

        private void etSifre_MouseClick(object sender, MouseEventArgs e)
        {
            etSifre.Clear();
            
        }

        private void etSifre_TextChanged(object sender, EventArgs e)
        {
            etSifre.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            girisim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Çıkış Yapılsınmı ?","Dikkat!",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(sor==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnCikis_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGiris_MouseMove(object sender, MouseEventArgs e)
        {
            btnGiris.Image = Properties.Resources._4p;
        }

        private void btnGiris_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.Image = Properties.Resources._4;
        }

        private void btnCikis_MouseMove(object sender, MouseEventArgs e)
        {
            btnCikis.Image = Properties.Resources._5p;
        }

        private void btnCikis_MouseLeave(object sender, EventArgs e)
        {
            btnCikis.Image = Properties.Resources._5;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void giris_Load(object sender, EventArgs e)
        {
            if (Settings1.Default.k != "0") radioButton1.Checked = true;
            etKullanici.Text = Settings1.Default.kullanici;
            etSifre.Text = Settings1.Default.sifre;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

            if (a==0)
            {
                radioButton1.Checked = true;
                Settings1.Default.kullanici = etKullanici.Text;
                Settings1.Default.sifre = etSifre.Text;
                Settings1.Default.k = "1";
                Settings1.Default.Save();
                a = 1;
            }
            else  if (a==1)
            {
                radioButton1.Checked = false;
                Settings1.Default.kullanici = "Kullanıcı Adı";
                Settings1.Default.sifre = "Şifre";
                Settings1.Default.k = "0";
                Settings1.Default.Save();
                a = 0;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            havadrm hava = new havadrm();
            hava.Show();
            this.Hide();
        }
    }

    }


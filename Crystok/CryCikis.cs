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
    public partial class CryCikis : Form
    {
        Veritabani vt = new Veritabani();
      
        public CryCikis()
        {
            InitializeComponent();
            yukle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int at=Convert.ToInt32(adet.Text);
            int mstok = Convert.ToInt32(mevcutstok.Text);
            if (mstok < at) { MessageBox.Show("Mevcut stoktan fazla satamasınız.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop); adet.Text = ""; }
            else
            {
                CryAnaekran cr = (CryAnaekran)Application.OpenForms["CryAnaekran"];
                vt.cikisstokguncelle(Convert.ToInt32(adet.Text), kod.Text.ToString());
                int a = Convert.ToInt32(adet.Text);
                vt.yenicikis(kod.Text.ToString(), a, tarih.Text.ToString(), neden.Text.ToString());
                adet.Text = "0";
                neden.Text = "";
                detay();
                cr.pencere.Controls.Clear();
                SabitStokdurum f1 = new SabitStokdurum();
                f1.TopLevel = false;
                cr.pencere.Controls.Add(f1);
                f1.Show();
                f1.Dock = DockStyle.Fill;
                f1.BringToFront();
                yukle();
            }
            at = 0; mstok = 0;
        }
        public void yukle()
        {
            kod.Items.Clear();
            vt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from stok where adet>0", vt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                kod.Items.Add(oku["ukodu"].ToString());
            }
            vt.bag.Close();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            vt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from stok where ukodu='"+kod.Text+"'", vt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                adet.Text = oku["adet"].ToString();
                adet.Enabled = false;
            }
            vt.bag.Close();
        
        }

        public void detay()
        {
            vt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from stok where ukodu='" + kod.Text + "'", vt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                mevcutstok.Text = oku["adet"].ToString();
            }
            vt.bag.Close();
        }
        private void kod_SelectedIndexChanged(object sender, EventArgs e)
        {
            detay();
        }

        private void CryCikis_Load(object sender, EventArgs e)
        {
         
        }

        private void adet_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void mevcutstok_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}

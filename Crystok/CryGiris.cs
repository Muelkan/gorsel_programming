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
    public partial class CryGiris : Form
    {
        Veritabani vt=new Veritabani();
        public CryGiris()
        {
            InitializeComponent();
            yukle();
        }
         void yukle()
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
     public    void detay()
        {
            vt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from stok where ukodu='"+kod.Text+"'", vt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                mevcutstok.Text=oku["adet"].ToString();
            }
            vt.bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CryAnaekran cr = (CryAnaekran)Application.OpenForms["CryAnaekran"];
            vt.yeniadet(kod.Text.ToString(),tarih.Text.ToString(),adet.Text.ToString());
            vt.girisadetekle(Convert.ToInt32(adet.Text),kod.Text.ToString());
            detay();
            adet.Text = "0";
            cr.pencere.Controls.Clear();
            SabitStokdurum f1 = new SabitStokdurum();
            f1.TopLevel = false;
            cr.pencere.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            kod.Text = "Seçiniz...";
            if(checkBox1.Checked==true){
                kod.Items.Clear();
                vt.bag.Open();
                MySqlCommand liste = new MySqlCommand("select * from stok where adet<=0", vt.bag);
                MySqlDataReader oku = liste.ExecuteReader();
                while (oku.Read())
                {
                    kod.Items.Add(oku["ukodu"].ToString());
                }
                vt.bag.Close();
            }
            else{
                mevcutstok.Text = "";
                yukle();
            }
           
        }

        private void kod_SelectedIndexChanged(object sender, EventArgs e)
        {
            detay();
        }

        private void CryGiris_Load(object sender, EventArgs e)
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

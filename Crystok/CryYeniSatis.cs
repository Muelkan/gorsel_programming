using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Crystok
{
   
    public partial class CryYeniSatis : Form
    {
        string starih = DateTime.Now.Day+"-"+DateTime.Now.Month + "-" + DateTime.Now.Year;
        string starihim = DateTime.Now.Month + "-" + DateTime.Now.Year;
        Veritabani vtt = new Veritabani();
        CryAnaekran cr = (CryAnaekran)Application.OpenForms["CryAnaekran"];
        CryAnaekran ae = new CryAnaekran();
        double fiyati;
        public CryYeniSatis()
        {
            InitializeComponent();
            System.Globalization.CultureInfo yenikultur = new System.Globalization.CultureInfo("tr-TR");
            yenikultur.NumberFormat.CurrencyDecimalSeparator = ".";
            yenikultur.NumberFormat.CurrencyGroupSeparator = ".";
            yenikultur.NumberFormat.NumberDecimalSeparator = ".";
            yenikultur.NumberFormat.NumberGroupSeparator = ".";
            yenikultur.NumberFormat.PercentDecimalSeparator = ".";
            yenikultur.NumberFormat.PercentGroupSeparator = ".";
            Application.CurrentCulture = yenikultur; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int at=Convert.ToInt32(adet.Text);
            int mstok = Convert.ToInt32(mevcutstok.Text);
            if (mstok < at) { MessageBox.Show("Mevcut stoktan fazla satamasınız.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop); adet.Text = ""; }
            else
            {
                int a = Convert.ToInt32(adet.Text);

                double b = Convert.ToDouble(fiyat.Text);
                double kd = Convert.ToDouble(kdv.Text);
                double iso = Convert.ToDouble(isko1.Text); 
                double afi = Convert.ToDouble(fiyati);
                vtt.yenisatis(kod.Text.ToString(), sad.Text.ToString(), a, b, tarih.Text.ToString(), starih, starihim,iso,kd,vergi.Text,dateTimePicker1.Text,afi,dateTimePicker2.Text,textBox1.Text);
                vtt.cikisstokguncelle(Convert.ToInt32(adet.Text), kod.Text.ToString());
                cr.yukleme();
            
                cr.pencere.Controls.Clear();
                SabitStokdurum f1 = new SabitStokdurum();
                f1.TopLevel = false;
                cr.pencere.Controls.Add(f1);
                f1.Show();
                f1.Dock = DockStyle.Fill;
                f1.BringToFront();
                this.Close();
            }
            at = 0; mstok = 0;
        }

        private void CryYeniSatis_Load(object sender, EventArgs e)
        {
            yukle();

        }

        private void kod_SelectedIndexChanged(object sender, EventArgs e)
        {
            yuklebilgi();
        }
          
        public void yuklebilgi()
        {
            vtt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from stok where ukodu='" + kod.Text + "'", vtt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                fiyat.Text = oku["sfiyat"].ToString();
                fiyati =Convert.ToDouble(oku["sfiyat"]);
                kdv.Text = oku["kdv"].ToString();
                Birim.Text = oku["pbirim"].ToString();
                mevcutstok.Text = oku["adet"].ToString();
                Birim.Visible = true;
            }
            vtt.bag.Close();
        }
     
        public void yukle()
        {
            vtt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from stok where adet>0", vtt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                kod.Items.Add(oku["ukodu"].ToString());
            }
            vtt.bag.Close();
        }

        private void adet_TextChanged(object sender, EventArgs e)
        {

            if (adet.Text != "")
            {
                double ac = Convert.ToDouble(adet.Text);
                double b = Convert.ToDouble(kdv.Text);
                double c = ac * b / 100;
                double da = ac + c;
                
                fiyat.Text = da.ToString();
            }
            else
            {
                yuklebilgi();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vtt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from stok where ukodu='" + kod.Text + "'", vtt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            if (oku.Read())
            {
                fiyat.Text = oku["sfiyat"].ToString();
                Birim.Text = oku["pbirim"].ToString();
                mevcutstok.Text = oku["adet"].ToString();
                Birim.Visible = true;
            }
            else
            {
                MessageBox.Show("Böyle Bir Ürün Bulunmamaktadır.","DURUM",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                fiyat.Text = "";
                Birim.Text = "";
                mevcutstok.Text = "";
            }
            vtt.bag.Close();
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

        private void fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

        }

        private void fiyat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

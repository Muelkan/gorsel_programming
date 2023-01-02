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

namespace Crystok
{
    public partial class SabitYenistok : Form
    {
        CryAnaekran cr = (CryAnaekran)Application.OpenForms["CryAnaekran"];
        Veritabani vtt = new Veritabani();
       
        double s,k;

        public SabitYenistok()
        {

            InitializeComponent();
            kontrolum();
            System.Globalization.CultureInfo yenikultur = new System.Globalization.CultureInfo("tr-TR");
            yenikultur.NumberFormat.CurrencyDecimalSeparator = ".";
            yenikultur.NumberFormat.CurrencyGroupSeparator = ".";
            yenikultur.NumberFormat.NumberDecimalSeparator = ".";
            yenikultur.NumberFormat.NumberGroupSeparator = ".";
            yenikultur.NumberFormat.PercentDecimalSeparator = ".";
            yenikultur.NumberFormat.PercentGroupSeparator = ".";
            Application.CurrentCulture = yenikultur; 
        }
            public void yukle()
        {
            dadi.Items.Clear();
            vtt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from depo", vtt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                dadi.Items.Add(oku["dadi"].ToString());
                dadi.Text = oku["dadi"].ToString();


            }
            vtt.bag.Close();
        }
       public void depoadi()
        {
            dadi.Items.Clear();
            vtt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from depo", vtt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                dadi.Items.Add(oku["dadi"].ToString());
                dadi.Text = oku["dadi"].ToString();

            }
            vtt.bag.Close();
        }
       public void kategori()
        {
            gurup.Items.Clear();
            vtt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from kategori", vtt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                gurup.Items.Add(oku["kadi"].ToString());
                gurup.Text = oku["kadi"].ToString();


            }
            vtt.bag.Close();
        }

       void kontrolum()
       {
           vtt.bag.Open();
           MySqlCommand liste = new MySqlCommand("select * from stok ", vtt.bag);
           MySqlDataReader oku = liste.ExecuteReader();
           while (oku.Read())
           {

               listBox1.Items.Add(oku["ukodu"].ToString());
           }
           vtt.bag.Close();

       }
       void kaydet()
       {
           CryAnaekran cr = (CryAnaekran)Application.OpenForms["CryAnaekran"];
           if (listBox1.Items.Contains(ukodu.Text) == false)
           {
               if (kdv.Text != "0")
               {
                   s = Convert.ToDouble(kdvm.Text);
               }
               else
               {
                   s = Convert.ToDouble(sfiyat.Text);
               }
               double a = Convert.ToDouble(afiyat.Text);
               if (kdv.Text != "")
               {
                   k = Convert.ToDouble(kdv.Text.ToString());
               }
               int b = Convert.ToInt32(adet.Text.ToString());
               Veritabani vt = new Veritabani();
               vt.ekle(ukodu.Text.ToString(), ad.Text.ToString(), b, model.Text.ToString(), a, s, k, tarih.Text.ToString(), gurup.Text.ToString(), dadi.Text.ToString(), aciklama.Text.ToString(), birim.Text.ToString(), yetkili.Text.ToString(), goz.Text.ToString(), raf.Text.ToString(), fadi.Text.ToString());
               kontrolum();
               cr.detay();
               cr.pencere.Controls.Clear();
               SabitStokdurum f1 = new SabitStokdurum();
               f1.TopLevel = false;
               cr.pencere.Controls.Add(f1);
               f1.Show();
               f1.Dock = DockStyle.Fill;
               f1.BringToFront();
           }
           else
           {
               MessageBox.Show("Bu Ürün Zaten Bulunmaktadır.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }
        private void button3_Click(object sender, EventArgs e)
       {
           if (afiyat.Text == "" || sfiyat.Text == "")
           {
               MessageBox.Show("Fiyatlarınızı Boş Girmeyin","DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
           }
           else
           {
               double af = Convert.ToDouble(afiyat.Text);
               double sf = Convert.ToDouble(sfiyat.Text);
               if (ad.Text == "") MessageBox.Show("Ürün Kodunu Boş Bıraktını.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (ukodu.Text == "") MessageBox.Show("Ürün Adını Boş Bıraktınız.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (adet.Text == "" || adet.Text == "0") MessageBox.Show("Ürün Adetini Kontrol Edin.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (afiyat.Text == "" || afiyat.Text == "0") MessageBox.Show("Geliş Fiyatını Kontrol Edin.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (sfiyat.Text == "" || sfiyat.Text == "0") MessageBox.Show("Satış Fiyatını Kontrol Edin.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (gurup.Text == "") MessageBox.Show("Lütfen Bir Kategori Seçin.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (dadi.Text == "") MessageBox.Show("Lütfen Bir Depo Seçin", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (kdv.Text == "") MessageBox.Show("Lütfen Kdv Oranını Kontrol Edin.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (birim.Text == "") MessageBox.Show("Lütfen Para Biriminizi Seçin.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else if (sf <= af) MessageBox.Show("Satış Fiyatını Alış Fiyatından Yüksek Olmalıdır.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               else kaydet();
           }
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Crydepo dp = new Crydepo();
            dp.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                       CryKategori kt = new CryKategori();
            kt.ShowDialog();
        }

        private void SabitYenistok_Load(object sender, EventArgs e)
        {

            yetkili.Text = cr.kim; 
            depoadi();
            kategori();
        }

        private void SabitYenistok_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void kdv_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(kdv.Text) > 100)
                {
                    MessageBox.Show("Kdv Tutatı 100'den Büyük Veya Boş Girilemez");
                    kdv.Text = "0";
                }
                else
                {
                    if (kdv.Text != "")
                    {

                        double a = Convert.ToDouble(sfiyat.Text);

                        double b = Convert.ToDouble(kdv.Text);
                        double c = a * b / 100;
                        double d = a + c;
                        kdvm.Text = d.ToString();
                    }
                    else
                    {
                        kdv.Text = "";
                        kdvm.Text = "0";
                    }
                }
            }
            catch {}
        }

        private void adet_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void afiyat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sfiyat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void kdv_KeyPress(object sender, KeyPressEventArgs e)
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

        private void afiyat_TextChanged(object sender, EventArgs e)
        {

        }
        private void sfiyat_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

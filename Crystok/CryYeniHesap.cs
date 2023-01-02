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
    public partial class CryYeniHesap : Form
    {
        Veritabani vt = new Veritabani();


        public CryYeniHesap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ayarlar ay = (ayarlar)Application.OpenForms["ayarlar"];
            if (button1.Text == "Yeni Kullanıcı")
            {
                vt.bag.Open();
                MySqlCommand liste = new MySqlCommand("select * from kullanici where kullanici='"+kullanici.Text+"'", vt.bag);
                MySqlDataReader oku = liste.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Böyle Bir Kullanıcı Bulunmaktadır.","DURUM",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
                else
                {
                    vt.bag.Close();
                    string deger;
                    if (yetki.Text == "Yönetici") deger = "0";
                    else deger = "1";
                    vt.yenikullanici(kullanici.Text, isim.Text, soyisim.Text, sifre.Text, tel.Text, deger);
                    this.Hide();
                    ay.yukleisim();
                }
                vt.bag.Close();
            }
            else
            {
                string deger;
                if (yetki.Text == "Yönetici") deger = "0";
                else deger = "1";
                vt.kullaniciguncelle(kullanici.Text, isim.Text, soyisim.Text, sifre.Text, tel.Text, deger);
                this.Hide();
                ay.yukleisim();
            }
        }
        public void yukle(string kadi)
        {
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from kullanici where kullanici='" + kadi + "'", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kullanici.Text = oku["kullanici"].ToString();
                kullanici.Enabled = false;
                isim.Text = oku["isim"].ToString();
                soyisim.Text = oku["soyisim"].ToString();
                sifre.Text = oku["sifre"].ToString();
                tel.Text = oku["tel"].ToString();
                string yt;
                yt = oku["yetki"].ToString();
                if (yt == "0")
                {
                    yetki.Text = "Yönetici";

                }
                else
                {
                    yetki.Text = "Kullanici";
                }



            }
            vt.bag.Close();
        
        }
    }
}

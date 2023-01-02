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
    public partial class ayarlar : Form
    {
        CryAnaekran anaform = (CryAnaekran)Application.OpenForms["CryAnaekran"];
        Veritabani vt = new Veritabani();
        CryYeniHesap yhesap = new CryYeniHesap();
        string gyetki, kuladi;
        public ayarlar()
        {
            InitializeComponent();
            yukle();
            yukleprofil();
            kontrol();
        }
        public void yukle()
        {
           vt.bag.Open();

            MySqlCommand komut = new MySqlCommand("select * from ayar ", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                isim.Text = oku["isimsoyisim"].ToString();
                tel.Text = oku["tel"].ToString();
                fadi.Text = oku["fadi"].ToString();
                tarih.Text = oku["ktrih"].ToString();
                paket.Text = oku["lisansp"].ToString();
                string gelen=oku["stokdurum"].ToString();
                ////Gelen veriri Seçmesi
                //if(gelen=="0") rd1.Checked = true;
                //else if (gelen == "1") rd2.Checked = true;
                //else rd3.Checked = true;
                ////Gelen veriri Seçmesi
           
                

            }
            vt.bag.Close();
        }
        public void yukleprofil()
        {
            vt.bag.Open();

            MySqlCommand komut = new MySqlCommand("select * from kullanici  where kullanici='" + anaform.kim + "'", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kuladi = oku["kullanici"].ToString();
                kadi.Text =  oku["kullanici"].ToString();
                telefon.Text = oku["tel"].ToString();
                isimsoy.Text = oku["isim"].ToString() + " " + oku["soyisim"].ToString();
                gyetki = oku["yetki"].ToString();
                if (gyetki == "0")
                {
                    yetkim.Text = "Yönetici";
                    yeniHesap.Visible = true;
                 
                }
                else
                {
                    yetkim.Text = "Kullanici";
                }
            
                
            }
            vt.bag.Close();
            yukleisim();
        }

        public void yukleisim()
        {
            listBox1.Items.Clear();
            vt.bag.Open();

            MySqlCommand komut = new MySqlCommand("select * from kullanici ", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                listBox1.Items.Add(oku["kullanici"].ToString());
                listBox1.Items.Remove(kuladi);

            }
            vt.bag.Close();
        }

        private void yeniHesap_Click(object sender, EventArgs e)
        {
            yhesap.Text = "Yeni Hesap";
            yhesap.button1.Text = "Yeni Kullanıcı";
            yhesap.kullanici.Enabled = true;
            yhesap.kullanici.Text = "";
            yhesap.isim.Text = "";
            yhesap.soyisim.Text = "";
            yhesap.sifre.Text = "";
            yhesap.tel.Text = "";
            yhesap.ShowDialog();
        }

        private void tumHesap_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void kontrol()
        {
            if (gyetki == "0")
            {
                listBox1.ContextMenuStrip = contextMenuStrip1;
            }
        }
        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem !=null)
            {
                yhesap.yukle(listBox1.SelectedItem.ToString());
                yhesap.Text = "Düzenle";
                yhesap.button1.Text="Güncelle";
                yhesap.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Seçin", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                if (gyetki != "3")
                {
                   
                    vt.kullanicisil(listBox1.SelectedItem.ToString());
                    yukleisim();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Seçin", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            yhesap.yukle(kuladi);
            yhesap.Text = "Düzenle";
            yhesap.button1.Text = "Güncelle";
            yhesap.ShowDialog();
        }
        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
        vt.yenistokdurum("1"); cagir();        
        }
        private void rd3_CheckedChanged(object sender, EventArgs e)
        {
        vt.yenistokdurum("2"); cagir();
        }
        private void rd1_CheckedChanged(object sender, EventArgs e)
        {
        vt.yenistokdurum("0"); cagir();
        }
        void cagir()
        {
            CryAnaekran cr = (CryAnaekran)Application.OpenForms["CryAnaekran"];
            SabitStokdurum f1 = new SabitStokdurum();
            f1.TopLevel = false;
            cr.pencere.Controls.Add(f1);
            f1.Show();
            f1.Dock = DockStyle.Fill;
            f1.BringToFront();
        }
    }
}
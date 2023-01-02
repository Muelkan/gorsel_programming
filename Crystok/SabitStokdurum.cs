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
    public partial class SabitStokdurum : Form
    {
        string yetki;
        int resim;
        Veritabani vt = new Veritabani();
        CryGiris cg = new CryGiris();
        CryCikis ck = new CryCikis();
        CryAnaekran anaform = (CryAnaekran)Application.OpenForms["CryAnaekran"];
        CryDetay detayim = (CryDetay)Application.OpenForms["CryDetay"];
        public SabitStokdurum()
        {
            InitializeComponent();
            yukleayar();
            listele();
        }
        public void yukleayar()
        {
            vt.bag.Open();

            MySqlCommand komut = new MySqlCommand("select * from ayar ", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                resim = Convert.ToInt32(oku["stokdurum"]);
            }
            vt.bag.Close();
        }
        public void listele()
        {
            listView1.Clear();
            vt.bag.Open();

            MySqlCommand komut = new MySqlCommand("select * from stok where adet>0", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                listView1.Items.Add(new ListViewItem { ImageIndex = resim, Text = oku["ukodu"].ToString() });

            }
            vt.bag.Close();
        }
        public void a(string ukodu)
        {
            listView1.Clear();
            vt.bag.Open();

            MySqlCommand komut = new MySqlCommand("select * from stok where adet>0 and ukodu='" + ukodu + "'", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                listView1.Items.Add(new ListViewItem { ImageIndex = resim, Text = oku["ukodu"].ToString() });

            }
            vt.bag.Close();
        }
        public void kimisorgula()
        {
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from kullanici where kullanici='" + anaform.kim + "'", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                yetki = oku["yetki"].ToString();

            }
            vt.bag.Close();

        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }
            }
            catch
            {

            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            CryYeniSatis st = new CryYeniSatis();
            st.kod.Enabled = false;
            st.kod.Text = listView1.SelectedItems[0].Text;
            st.yuklebilgi();
            st.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CryDetay dt = new CryDetay();
            dt.kilitle();
            dt.yukle(listView1.SelectedItems[0].Text);
            dt.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ck.kod.Text = listView1.SelectedItems[0].Text;
            ck.detay();
            ck.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            cg.kod.Text = listView1.SelectedItems[0].Text;
            cg.detay();
            cg.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CryDetay dt = new CryDetay();
            dt.yukle(listView1.SelectedItems[0].Text);
            dt.guc.Visible = true;
            dt.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            kimisorgula();
            if (yetki == "0")
            {
                DialogResult sor = MessageBox.Show(listView1.SelectedItems[0].Text + "'Seçilen ürünü stoktan silmek istediğinize eminmisiniz?", "DURUM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sor == DialogResult.Yes)
                {
                    vt.stoktansil(listView1.SelectedItems[0].Text);
                    anaform.detay();
                    listele();
                }
            }
            else MessageBox.Show("Yetkiniz sınırlıdır lütfen Yetkili giriş yapın.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
  

        }

        private void SabitStokdurum_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                CryDetay dt = new CryDetay();
                dt.kilitle();
                dt.guc.Visible = true;
                dt.guc.Text = "Satış Yap";
                dt.yukle(listView1.SelectedItems[0].Text);
                dt.ShowDialog();
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            vt.bag.Open();

            MySqlCommand komut = new MySqlCommand("select * from stok where ad like '%" + edAra.Text + "%'", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                listView1.Items.Add(new ListViewItem { ImageIndex = resim, Text = oku["ukodu"].ToString() });

            }
            vt.bag.Close();
        }

        private void edAra_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edAra.Text = "";
        }
    }
}

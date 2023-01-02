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
    public partial class SabitRapolama : Form
    {
        public string ssatisim,gytyetki;
        double bb;
        string starih = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        string aytarih =DateTime.Now.Month + "-" + DateTime.Now.Year;
        Veritabani vt = new Veritabani();
        CryAnaekran ystok = (CryAnaekran)Application.OpenForms["CryAnaekran"];
        
        public SabitRapolama()
        {
            InitializeComponent();
            listele();
          
        }
        void listele()
        {
            vt.bag.Open();
            MySqlDataAdapter st = new MySqlDataAdapter("select * from stok where adet>0", vt.bag);
            DataSet DS = new DataSet();
            st.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            vt.bag.Close();
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Ürün Kodu";
            dataGridView1.Columns[3].HeaderText = "Türü";
            dataGridView1.Columns[4].HeaderText = "Alış";
            dataGridView1.Columns[5].HeaderText = "Satış";
            dataGridView1.Columns[6].HeaderText = "Kdv";
            dataGridView1.Columns[7].HeaderText = "Kayıt Tarihi";
            dataGridView1.Columns[8].HeaderText = "Kategori";
            dataGridView1.Columns[9].HeaderText = "Depo Adı";
            dataGridView1.Columns[10].HeaderText = "Açıklama";
            dataGridView1.Columns[11].HeaderText = "Birim";
            dataGridView1.Columns[12].HeaderText = "Yetkili";
            dataGridView1.Columns[13].HeaderText = "Göz";
            dataGridView1.Columns[14].HeaderText = "Raf";
            dataGridView1.Columns[15].HeaderText = "Firma";
            dataGridView1.Columns[16].HeaderText = "Stokta";
        }

        private void SabitRapolama_Load(object sender, EventArgs e)
        {
         
            dataGridView1.Columns[0].Visible = false;
            paratarih.Text = starih;
            paralistele();
            yukleme();
            stoksayisi();
            aygelirim();
            tstok();
            bitmisstok();
            satilanu();
            sonst();
            tyukle();
            yukleprofilim();
            tlkactum();
            paratarih.Text = starih;
        }
        void paralistele()
        {

            paratarih.Items.Clear();
            vt.bag.Open();
            MySqlCommand liste = new MySqlCommand("SELECT distinct aytarih from satis", vt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                paratarih.Items.Add(oku["aytarih"].ToString());
            }
            vt.bag.Close();
        }
        private void SabitRapolama_MouseClick(object sender, MouseEventArgs e)
        {
         
        }
        public void yukleme()
        {
            ListBox lit = new ListBox();
            lit.Items.Clear();
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis where aytarih='" + paratarih.Text + "' ", vt.bag);
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
                label4.Text = bb.ToString() + " TL";
            }
            vt.bag.Close();
        }

       public void tlkactum()
        {

                ListBox lit = new ListBox();
                lit.Items.Clear();
                vt.bag.Open();
                MySqlCommand komut = new MySqlCommand("select * from satis  ", vt.bag);
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
                    label11.Text = bb.ToString() + " TL";
                }
                vt.bag.Close();          
        }
        public void tlkac()
        {
            if (comboBox3.Text != "Tüm Satışlar")
            {
                ListBox lit = new ListBox();
                lit.Items.Clear();
                vt.bag.Open();
                MySqlCommand komut = new MySqlCommand("select * from satis where starih='" + comboBox3.Text + "' ", vt.bag);
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
                    label11.Text = bb.ToString() + " TL";
                }
                vt.bag.Close();
            }
            else  tlkactum();
        }
        private void paratarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            yukleme();
        }
        public void stoksayisi()
        {
            vt.bag.Open();
            MySqlCommand say = new MySqlCommand("select  count(*) from stok where adet>0", vt.bag);
            yaziStok.Text = say.ExecuteScalar().ToString() + " Ürün";
            vt.bag.Close();
        }
        public void bitmisstok()
        {
            vt.bag.Open();
            MySqlCommand say = new MySqlCommand("select  count(*) from stok where adet=0", vt.bag);
            bstok.Text = say.ExecuteScalar().ToString() + " Adet";
            vt.bag.Close();
        }
        public void aygelirim()
        {
            ListBox lit = new ListBox();
            lit.Items.Clear();
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis where starih='" + aytarih + "' ", vt.bag);
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
                aygelir.Text = bb.ToString() + " TL";
            }
            vt.bag.Close();
        }

        public void tstok()
        {
            ListBox lit = new ListBox();
            lit.Items.Clear();
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from stok ", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                bb = 0;
                lit.Items.Add(oku["adet"].ToString());
                double sonuc = 0;
                for (int i = 0; i < lit.Items.Count; i++)
                {
                    sonuc += Convert.ToDouble(lit.Items[i]);
                }
                bb += sonuc;
                toplamstok.Text = bb.ToString() + " Adet";
            }
            vt.bag.Close();
        }

        public void satilanu()
        {
            ListBox lit = new ListBox();
            lit.Items.Clear();
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis ", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                bb = 0;
                lit.Items.Add(oku["adet"].ToString());
                double sonuc = 0;
                for (int i = 0; i < lit.Items.Count; i++)
                {
                    sonuc += Convert.ToDouble(lit.Items[i]);
                }
                bb += sonuc;
                satilanurun.Text = bb.ToString() + " Adet";
            }
            vt.bag.Close();
        }
        public void sonst()
        {
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand(" SELECT * FROM satis ORDER BY id DESC LIMIT 1", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                sonsatis.Text = oku["ad"].ToString();
            }
            vt.bag.Close();
        }
        void tyukle()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.Add("Tüm Satışlar");
            vt.bag.Open();
            MySqlCommand liste = new MySqlCommand("SELECT distinct starih from satis", vt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                comboBox3.Items.Add(oku["starih"].ToString());
            }
            vt.bag.Close();
        }
        void satislerim()
        {
            vt.bag.Open();
            MySqlDataAdapter st = new MySqlDataAdapter("select * from satis where starih='"+comboBox3.Text+"'", vt.bag);
            DataSet DS = new DataSet();
            st.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            vt.bag.Close();
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Alıcı Adı";
            dataGridView1.Columns[3].HeaderText = "Adet";
            dataGridView1.Columns[4].HeaderText = "Fiyat";
            dataGridView1.Columns[5].HeaderText = "Tarih";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }
        void tumsatis()
        {
            vt.bag.Open();
            MySqlDataAdapter st = new MySqlDataAdapter("select * from satis", vt.bag);
            DataSet DS = new DataSet();
            st.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            vt.bag.Close();
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Alıcı Adı";
            dataGridView1.Columns[3].HeaderText = "Adet";
            dataGridView1.Columns[4].HeaderText = "Fiyat";
            dataGridView1.Columns[5].HeaderText = "Tarih";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }
        void tumgiris()
        {
            vt.bag.Open();
            MySqlDataAdapter st = new MySqlDataAdapter("select * from girisadet", vt.bag);
            DataSet DS = new DataSet();
            st.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            vt.bag.Close();
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Tarih";
        }
        void tumcikis()
        {
            vt.bag.Open();
            MySqlDataAdapter st = new MySqlDataAdapter("select * from cikis", vt.bag);
            DataSet DS = new DataSet();
            st.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            vt.bag.Close();
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Adet";
            dataGridView1.Columns[3].HeaderText = "Tarih";
            dataGridView1.Columns[4].HeaderText = "Neden";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Satışlarım")
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                paneltarih.Visible = true;
                tumsatis();
            }
            else if (comboBox1.Text == "Toplam Stok")
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                paneltarih.Visible = false;
                listele();
            }
            else if (comboBox1.Text == "Girişler")
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                paneltarih.Visible = false;
                tumgiris();
         
            }
            else if (comboBox1.Text == "Çıkışlar")
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                paneltarih.Visible = false;
                tumcikis();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Tüm Satışlar") { tumsatis(); tlkactum(); }
            else { satislerim(); tlkac(); }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Tümünü Sil")
            {
                if (gytyetki != "0") MessageBox.Show("Lütfen Yetkili Giriş Yapınız.","DURUM",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                else
                {
                    if (dataGridView1.RowCount != 0)
                    {
                        DialogResult sor = MessageBox.Show("Tüm  Verileriniz Silinecektir.Bunu Yapmak İstediğinizden Eminmisiniz?", "SEÇİM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (sor == DialogResult.Yes)
                        {
                            if (comboBox1.Text == "Toplam Stok") { vt.tumunusilme("stok"); listele(); }
                            else if (comboBox1.Text == "Satışlarım") { vt.tumunusilme("satis"); tumsatis(); }
                            else if (comboBox1.Text == "Girişler") { vt.tumunusilme("girisadet"); tumgiris(); }
                            else if (comboBox1.Text == "Çıkışlar") { vt.tumunusilme("cikis"); tumcikis(); }
                        }
                    }
                }
       
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Selected == true)
                    {
                        if (comboBox1.Text == "Toplam Stok") { vt.stoktansil(dataGridView1.CurrentRow.Cells[1].Value.ToString()); listele(); }
                        else if (comboBox1.Text == "Satışlarım") { vt.satistansil(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)); if (comboBox2.Text != "Tüm Satışlar")satislerim(); else tumsatis(); }
                        else if (comboBox1.Text == "Girişler") { vt.giriscikissil("girisadet", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)); tumgiris(); }
                        else if (comboBox1.Text == "Çıkışlar") { vt.giriscikissil("cikis", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)); tumcikis(); }
                        return;
                    }

                    else { MessageBox.Show("Lütfen Silmek İstediğiniz Satırı Seçiniz.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
                }
                
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }
        public void yukleprofilim()
        {
            vt.bag.Open();

            MySqlCommand komut = new MySqlCommand("select * from kullanici  where kullanici='" + ystok.kim + "'", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                gytyetki = oku["yetki"].ToString();
            }
            vt.bag.Close();
          
        }
        private void paratarih_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            yukleme();
        }

        private void paratarih_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

    }
}

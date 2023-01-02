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
    public partial class SabitSatis : Form
    {
        int id;
        string firma,ft,vergi,adi,tarih,saat,fiili;
        string adet, isko, afiyat, kdv,vergid;


        string onbinler, binler, yuzler, onlar, birler;
        int sayı, basamak4, basamak3, basamak2, basamak1, basamak5;

        CryAnaekran cr = (CryAnaekran)Application.OpenForms["CryAnaekran"];
        CryYeniSatis st = new CryYeniSatis();
        Veritabani vtt = new Veritabani();
        public SabitSatis()
        {
            InitializeComponent();
            listele();

            
            yukleme();
        }

        public void yukleme()
        {
            paratarih.Items.Clear();
            vtt.bag.Open();
            paratarih.Items.Add("Tüm Satışlar");
            MySqlCommand liste = new MySqlCommand("SELECT distinct tarih from satis", vtt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                paratarih.Items.Add(oku["tarih"].ToString());
            }
            vtt.bag.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (liste.SelectedItems.Count == 0)
            {
                MessageBox.Show("Yazdırmak İstediğiniz Faturanın No'sunu Seçin!", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    printDocument1.Print();
       
               
            }

        }
        public void listele()
        {
      
            liste.Items.Clear();
            vtt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis", vtt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku["id"].ToString());
                item.SubItems.Add(oku["ad"].ToString());
                item.SubItems.Add(oku["sad"].ToString());
                item.SubItems.Add(oku["adet"].ToString());
                double st =Convert.ToDouble(oku["fiyat"].ToString());
                item.SubItems.Add(st.ToString());
                item.SubItems.Add(oku["tarih"].ToString());
    
                liste.Items.Add(item);

            }
            vtt.bag.Close();
        }
        public void arama(string adi)
        {
          
            liste.Items.Clear();
            vtt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis where ad='"+adi+"'", vtt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku["id"].ToString());
                item.SubItems.Add(oku["ad"].ToString());
                item.SubItems.Add(oku["sad"].ToString());
                item.SubItems.Add(oku["adet"].ToString());
                double st = Convert.ToDouble(oku["fiyat"].ToString());
                item.SubItems.Add(st.ToString());
                item.SubItems.Add(oku["tarih"].ToString());
                item.SubItems.Add(oku["fiili"].ToString());
                item.SubItems.Add(oku["isko"].ToString());
                item.SubItems.Add(oku["vergi"].ToString());
                item.SubItems.Add(oku["kdv"].ToString());
                liste.Items.Add(item);



            } vtt.bag.Close();

        }
        void idsec()
        {
            vtt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis where ad='" + liste.SelectedItems[0].Text + "'", vtt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                id = Convert.ToInt32(oku["id"].ToString());

            }

            vtt.bag.Close();
        }
        public void aramatarih(string tarih)
        {
            liste.Items.Clear();
            vtt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis where tarih='" +tarih + "'", vtt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                ListViewItem item = new ListViewItem(oku["id"].ToString());
                item.SubItems.Add(oku["ad"].ToString());
                item.SubItems.Add(oku["sad"].ToString());
                item.SubItems.Add(oku["adet"].ToString());
                double st = Convert.ToDouble(oku["fiyat"].ToString());
                item.SubItems.Add(st.ToString());
                item.SubItems.Add(oku["tarih"].ToString());
                item.SubItems.Add(oku["fiili"].ToString());
                item.SubItems.Add(oku["isko"].ToString());
                item.SubItems.Add(oku["vergi"].ToString());
                item.SubItems.Add(oku["kdv"].ToString());
                liste.Items.Add(item);


                liste.Items.Add(item);
            }
                else {
                vtt.bag.Close();
                listele();
                MessageBox.Show("Bu Tarihte Ürün Satışı Bulunmamaktadır.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            vtt.bag.Close();
            
        }
        void sil()
        {
            if (liste.SelectedItems.Count == 0)
            {
                MessageBox.Show("Silmek İstediğiniz Ürünü Kodunu Seçin", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                idsec();
                vtt.satistansil(id);
                listele();
                cr.yukleme();
            }
        }
        void guncelle()
        {
            if (liste.SelectedItems.Count == 0)
            {
                MessageBox.Show("Güncellemek İstediğiniz Ürünü Kodunu Seçin", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                st.ShowDialog();
                listele();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sil();
    
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            guncelle();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            arama(ad.Text.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ad.Text = "";
            paratarih.Text = "Tüm Satışlar";
            listele();
        }

        private void sATIŞISİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sil();
        }

        private void sATIŞIGÜNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guncelle();
        }

        private void tarih_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void SabitSatis_Load(object sender, EventArgs e)
        {
            paratarih.Text = "Tüm Satışlar";
        }

        private void paratarih_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsLetterOrDigit(e.KeyChar) || Char.IsSymbol(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsWhiteSpace(e.KeyChar) || Char.IsControl(e.KeyChar) || Char.IsNumber(e.KeyChar);
        }

        private void paratarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paratarih.Text == "Tüm Satışlar") listele();
            else  aramatarih(paratarih.Text.ToString());
        }

       
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            printDocument1.Print();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string a = "11";
            vtt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from satis where id='" + liste.SelectedItems[0].Text + "'", vtt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {

                firma = oku["sad"].ToString();
                vergi = oku["vergi"].ToString();
                adi = oku["ad"].ToString();
                tarih = oku["tarih"].ToString();
                saat = oku["saat"].ToString();
                fiili = oku["fiili"].ToString();
                adet = oku["adet"].ToString();
                isko = oku["isko"].ToString();
                afiyat = oku["afiyat"].ToString();
                kdv = oku["kdv"].ToString();
                ft = oku["fiyat"].ToString();
                vergid = oku["vergid"].ToString();


            }

            vtt.bag.Close();
            Image i = pictureBox2.Image;

            e.Graphics.DrawImage(i, 0, 0, 830, 1180);
            string sad = firma;
            string ver = vergi;
            string adii = adi;
            string trh = tarih;
            string st = saat;
            string fil = fiili;
            string adt = adet;
            string isk = isko;
            string af = afiyat;
            string kv = kdv;
            string vrdi = vergid;

            if (sad.ToString().Length > 45)
            {
                //   string abb = sad.ToString().Substring(0, 49);
                // string ccd = sad.ToString().Substring(49, sad.Length - 1);
                e.Graphics.DrawString(sad.ToString().Remove(45), new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(40, 170));
                e.Graphics.DrawString(sad.ToString().Substring(45), new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(40, 190));

            }

            else
            {
                e.Graphics.DrawString(sad, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(40, 170));
            }

            e.Graphics.DrawString(adii, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(50, 490));
            e.Graphics.DrawString(ver, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(180, 380));
            e.Graphics.DrawString(vrdi, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(180, 345));

            //sag

            e.Graphics.DrawString(tarih, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(650, 355));
            e.Graphics.DrawString(fil, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(650, 385));
            e.Graphics.DrawString(saat, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(650, 415));



            e.Graphics.DrawString(adt, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(480, 490));
            e.Graphics.DrawString("%" + isk, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(560, 490));
            e.Graphics.DrawString("0", new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(595, 490));
            e.Graphics.DrawString("0", new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(630, 490));
            e.Graphics.DrawString(af, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(665, 490));
            e.Graphics.DrawString("%" + kv, new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(530, 490));
            int aaa = Convert.ToInt32(adt);
            int bbb = Convert.ToInt32(af);
            int ca = aaa * bbb;

                        double ac = Convert.ToDouble(af);
                        double b = Convert.ToDouble(kdv);
                        double c = ac * b / 100;
                        double da = ac + c;
                        double asa = da + ca;
             e.Graphics.DrawString(ca.ToString()+ "TL", new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(720, 490));
            //ft
            e.Graphics.DrawString("=============================================", new Font(a, 9, FontStyle.Bold), Brushes.Black, new PointF(525, 640));
            e.Graphics.DrawString("ARA TOPLAM          "+"  "+ca.ToString()+" TL", new Font(a, 10, FontStyle.Bold), Brushes.Black, new PointF(585, 660));
            e.Graphics.DrawString("iSKONTO             "+"       "+" 0,00 TL", new Font(a, 10, FontStyle.Bold), Brushes.Black, new PointF(585, 680));
            e.Graphics.DrawString("NET TOPLAM          "+"  "+ca.ToString()+" TL", new Font(a, 10, FontStyle.Bold), Brushes.Black, new PointF(585, 700));
            e.Graphics.DrawString("KDV TUTARI          "+"    "+da.ToString(), new Font(a, 10, FontStyle.Bold), Brushes.Black, new PointF(585, 720));
            e.Graphics.DrawString("GENEL TOPLAM        "+asa.ToString() + " TL", new Font(a, 10, FontStyle.Bold), Brushes.Black, new PointF(585, 740));






            sayı = Convert.ToInt32(9999);
            basamak5 = sayı / 10000;
            sayı = sayı % 10000;
            switch (basamak5)
            {
                case 1: onbinler = "on"; break;
                case 2: onbinler = "yirmi"; break;
                case 3: onbinler = "otuz"; break;
                case 4: onbinler = "kırk"; break;
                case 5: onbinler = "elli"; break;
                case 6: onbinler = "atmış"; break;
                case 7: onbinler = "yetmiş"; break;
                case 8: onbinler = "seksen"; break;
                case 9: onbinler = "doksan"; break;
            }

            basamak4 = sayı / 1000;
            sayı = sayı % 1000;
            switch (basamak4)
            {
                case 1: binler = "bin"; break;
                case 2: binler = "ikibin"; break;
                case 3: binler = "üçbin"; break;
                case 4: binler = "dörtbin"; break;
                case 5: binler = "beşbin"; break;
                case 6: binler = "altıbin"; break;
                case 7: binler = "yedibin"; break;
                case 8: binler = "sekizbin"; break;
                case 9: binler = "dokuzbin"; break;
            }
            basamak3 = sayı / 100;
            sayı = sayı % 100;
            switch (basamak3)
            {
                case 1: yuzler = "yüz"; break;
                case 2: yuzler = "ikiyüz"; break;
                case 3: yuzler = "üçyüz"; break;
                case 4: yuzler = "dörtyüz"; break;
                case 5: yuzler = "beşyüz"; break;
                case 6: yuzler = "altıyüz"; break;
                case 7: yuzler = "yediyüz"; break;
                case 8: yuzler = "sekizyüz"; break;
                case 9: yuzler = "dokuzyüz"; break;
            }
            basamak2 = sayı / 10;
            sayı = sayı % 10;
            switch (basamak2)
            {
                case 1: onlar = "on"; break;
                case 2: onlar = "yirmi"; break;
                case 3: onlar = "otuz"; break;
                case 4: onlar = "kırk"; break;
                case 5: onlar = "elli"; break;
                case 6: onlar = "atmış"; break;
                case 7: onlar = "yetmiş"; break;
                case 8: onlar = "seksen"; break;
                case 9: onlar = "doksan"; break;
            }
            basamak1 = sayı / 1;
            sayı = sayı % 1;
            switch (basamak1)
            {
                case 1: birler = "bir"; break;
                case 2: birler = "iki"; break;
                case 3: birler = "üç"; break;
                case 4: birler = "dört"; break;
                case 5: birler = "beş"; break;
                case 6: birler = "altı"; break;
                case 7: birler = "yedi"; break;
                case 8: birler = "sekiz"; break;
                case 9: birler = "dokuz"; break;
            }
 
  e.Graphics.DrawString("# " + onbinler + " " + binler + " " + yuzler + " " + onlar + " " + birler + " TL #", new Font(a, 13, FontStyle.Underline), Brushes.Black, new PointF(120, 740));
        }

    }
}

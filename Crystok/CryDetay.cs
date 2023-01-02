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
    public partial class CryDetay : Form
    {
        Veritabani vt = new Veritabani();
        public CryDetay()
        {
            InitializeComponent();
            depoadi();
            kategori();
            System.Globalization.CultureInfo yenikultur = new System.Globalization.CultureInfo("tr-TR");
            yenikultur.NumberFormat.CurrencyDecimalSeparator = ".";
            yenikultur.NumberFormat.CurrencyGroupSeparator = ".";
            yenikultur.NumberFormat.NumberDecimalSeparator = ".";
            yenikultur.NumberFormat.NumberGroupSeparator = ".";
            yenikultur.NumberFormat.PercentDecimalSeparator = ".";
            yenikultur.NumberFormat.PercentGroupSeparator = ".";
            Application.CurrentCulture = yenikultur; 
          
        }
      public  void kilitle()
        {
         adet.Enabled=false;
         ukodu.Enabled = false;
         gurup.Enabled=false;
         kdv.Enabled=false;
         birim.Enabled=false;
         sfiyat.Enabled=false;
         afiyat.Enabled=false;
         aciklama.Enabled=false;
         goz.Enabled=false;
         raf.Enabled=false;
         yetkili.Enabled=false;
         tarih.Enabled=false;
         model.Enabled=false;
         fadi.Enabled=false;
         dadi.Enabled=false;
         ad.Enabled=false;
        }
      public void yukle(string ukodum) //ayrıntılar
      {

          vt.bag.Open();
          MySqlCommand komut = new MySqlCommand("select * from stok where ukodu='" + ukodum + "'", vt.bag);
          MySqlDataReader oku = komut.ExecuteReader();
          if (oku.Read())
          {
              adet.Text = oku["adet"].ToString();
              ukodu.Text = oku["ukodu"].ToString();
              gurup.Text = oku["gurup"].ToString();
              kdv.Text = oku["kdv"].ToString();
              birim.Text = oku["pbirim"].ToString();
              sfiyat.Text = oku["sfiyat"].ToString();
              afiyat.Text = oku["afiyat"].ToString();
              aciklama.Text = oku["aciklama"].ToString();
              goz.Text = oku["goz"].ToString();
              raf.Text = oku["raf"].ToString();
              yetkili.Text = oku["yetkili"].ToString();
            //  tarih.Text = oku["tarih"].ToString();
              model.Text = oku["tur"].ToString();
              fadi.Text = oku["fadi"].ToString();
              dadi.Text = oku["dadi"].ToString();
              ad.Text = oku["ad"].ToString();
              double a = Convert.ToDouble(sfiyat.Text);
              double b = Convert.ToDouble(kdv.Text);
              double c = a * b / 100;
              double d = a + c;
              kdvm.Text = d.ToString();

          }
          else
          {
              MessageBox.Show(ukodum+"' Ürün stoklarda bulunamadı lütfen kontrol edin.","DURUM",MessageBoxButtons.OK,MessageBoxIcon.Error);
          }
          vt.bag.Close();

      }

      public void yukleme(string ukodum)
      {
          vt.bag.Open();
          MySqlCommand komut = new MySqlCommand("select * from stok where ukodu='" + ukodum + "'", vt.bag);
          MySqlDataReader oku = komut.ExecuteReader();
          if (oku.Read())
          {
              adet.Text = oku["adet"].ToString();
              ukodu.Text = oku["ukodu"].ToString();
              gurup.Text = oku["gurup"].ToString();
              kdv.Text = oku["kdv"].ToString();
              birim.Text = oku["pbirim"].ToString();
              sfiyat.Text = oku["sfiyat"].ToString();
              afiyat.Text = oku["afiyat"].ToString();
              aciklama.Text = oku["aciklama"].ToString();
              goz.Text = oku["goz"].ToString();
              raf.Text = oku["raf"].ToString();
              yetkili.Text = oku["yetkili"].ToString();
              tarih.Text = oku["tarih"].ToString();
              model.Text = oku["tur"].ToString();
              fadi.Text = oku["fadi"].ToString();
              dadi.Text = oku["dadi"].ToString();
              ad.Text = oku["ad"].ToString();
              this.ShowDialog();

          }
          else
          {
              MessageBox.Show(ukodum + "' Ürün stoklarda bulunamadı lütfen kontrol edin.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          vt.bag.Close();
      }
      public void depoadi()
      {
          dadi.Items.Clear();
          vt.bag.Open();
          MySqlCommand liste = new MySqlCommand("select * from depo", vt.bag);
          MySqlDataReader oku = liste.ExecuteReader();
          while (oku.Read())
          {
              dadi.Items.Add(oku["dadi"].ToString());
              dadi.Text = oku["dadi"].ToString();

          }
          vt.bag.Close();
      }
      public void kategori()
      {
          gurup.Items.Clear();
          vt.bag.Open();
          MySqlCommand liste = new MySqlCommand("select * from kategori", vt.bag);
          MySqlDataReader oku = liste.ExecuteReader();
          while (oku.Read())
          {
              gurup.Items.Add(oku["kadi"].ToString());
              gurup.Text = oku["kadi"].ToString();


          }
          vt.bag.Close();
      }
      private void guc_Click(object sender, EventArgs e)
      {
          if (guc.Text == "Kaydı Güncelle")
          {
              if (afiyat.Text == "" || sfiyat.Text == "")
              {
                  MessageBox.Show("Fiyatlarınızı Boş Girmeyin", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                  else guncelleme();
              }
          }
          else
          {
              CryYeniSatis yt = new CryYeniSatis();
              yt.kod.Text = ukodu.Text;
              yt.yuklebilgi();
              yt.kod.Enabled = false;
              yt.ShowDialog();
          }
          
      }
      void guncelleme()
      {
          try
          {
              int a = Convert.ToInt32(adet.Text.ToString());

              double b = Convert.ToDouble(kdv.Text.ToString());
              double c = Convert.ToDouble(sfiyat.Text.ToString());
              double d = Convert.ToDouble(afiyat.Text.ToString());

              vt.guncellestok(a, ukodu.Text.ToString(), gurup.Text.ToString(), b, birim.Text.ToString(), c, d, aciklama.Text.ToString(), goz.Text.ToString(), raf.Text.ToString(), yetkili.Text.ToString(), tarih.Text.ToString(), model.Text.ToString(), fadi.Text.ToString(), dadi.Text.ToString(), ad.Text.ToString());
              this.Hide();
          }
          catch (Exception ex)
          {
              MessageBox.Show("Hata: " + ex);
          }
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
          catch { }
      }

      private void CryDetay_Load(object sender, EventArgs e)
      {

      }
    }
}

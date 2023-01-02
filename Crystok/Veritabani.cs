using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;




namespace Crystok
{

    class Veritabani
    {
 

 
        public MySqlConnection bag = new MySqlConnection("Server=localhost;Database=odev_gorsel;Uid=root;Pwd='';");
        //public MySqlConnection bag = new MySqlConnection("Server=;Database=cry;Uid=root;Pwd='123456789';");

        public string depoadi;
        public void guncellestok(int adet, string ukodu, string gurup, double kdv, string birim, double sfiyat, double afiyat, string aciklama, string goz, string raf, string yetkili, string tarih, string model, string fadi, string dadi, string ad)
        {
           
            
            bag.Open();
            MySqlCommand gun = new MySqlCommand("update stok set adet='" + adet + "',ukodu='" + ukodu + "',gurup='" + gurup + "',kdv='" + kdv + "',pbirim='" + birim + "',sfiyat='" + sfiyat + "',afiyat='" + afiyat + "',aciklama='" + aciklama + "',goz='" + goz + "',raf='" + raf + "',yetkili='" + yetkili + "',tarih='" + tarih + "',tur='" + model + "',fadi='" + fadi + "',dadi='" + dadi + "',ad='" + ad + "' where ukodu='" + ukodu + "'", bag);
            gun.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarıyla Güncellenmiştir.","DURUM",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            bag.Close();
        }
        public void ekle(string ukodu, string ad, int adet, string tur, double afiyat, double sfiyat, double kdv, string tarih, string gurup, string dadi, string aciklama, string pbirim, string yetkili, string goz, string raf, string fadi)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("insert into stok(ukodu,ad,adet,tur,afiyat,sfiyat,kdv,tarih,gurup,dadi,aciklama,pbirim,yetkili,goz,raf,fadi)values('" + ukodu + "', '" + ad + "','" + adet + "','" + tur + "', '" + afiyat + "','" + sfiyat + "','" + kdv + "','" + tarih + "','" + gurup + "','" + dadi + "','" + aciklama + "','" + pbirim + "','" + yetkili + "','" + goz + "','" + raf + "','" + fadi + "')", bag);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Yeni Ürün Başarıyla eklenmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bag.Close();

        }
        public void yenidepoekle(string tarih ,string dadi ,string sahip,string yetkili,string adres)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("insert into depo(tarih,dadi,sahip,yetkili,adres)values('"+tarih+"','"+dadi+"','"+sahip+"','"+yetkili+"','"+adres+"')",bag);
            MessageBox.Show("Yeni Deponuz Kaydedilmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ekle.ExecuteNonQuery();
            bag.Close();

        }
        public void yenikullanici(string kullanici, string isim, string soyisim, string sifre, string tel,string yetki)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("insert into kullanici(kullanici,isim,soyisim,sifre,tel,yetki)values('" + kullanici + "','" + isim + "','" + soyisim + "','" + sifre + "','" + tel + "','"+yetki+"')", bag);
            MessageBox.Show("Yeni Hesap Başarıyla Eklenmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ekle.ExecuteNonQuery();
            bag.Close();

        }
        public void yenicikis(string kod, int adet, string tarih, string neden)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("insert into cikis(kod,adet,tarih,neden)values('" + kod + "','" + adet + "','" + tarih + "','" + neden + "')", bag);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Çıkış Başarılı.");
            bag.Close();

        }
        public void cikisstokguncelle(int ab, string veri)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("update stok  set adet=adet-'" + ab + "'where ukodu='"+veri+"'",bag);
            ekle.ExecuteNonQuery();
            bag.Close();
        }

        public void girisadetekle(int adet,string ukodu)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("update stok set adet=adet+'" + adet + "'where ukodu='"+ukodu+"'", bag);
            ekle.ExecuteNonQuery();
            bag.Close();

        }
        public void kullaniciguncelle(string kullanici, string isim, string soyisim, string sifre, string tel, string yetki)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("update kullanici set kullanici='" + kullanici + "',isim='" + isim + "',soyisim='" + soyisim + "',sifre='" + sifre + "',tel='" + tel + "',yetki='" + yetki + "' where kullanici='" + kullanici + "'", bag);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Hesap Başarıyla Güncellenmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bag.Close();

        }
        public void yeniadet(string ukodu, string tarih, string adet)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("insert into girisadet(ukodu,tarih,adet)values('" + ukodu + "','" + tarih + "','" + adet + "')", bag);
            ekle.ExecuteNonQuery();
            MessageBox.Show("Stoğa Yeni adet Eklenmiştir.");
            bag.Close();

        }
        public void yenistokdurum(string durum)
        {
            try
            {
                bag.Open();
                MySqlCommand gun = new MySqlCommand("update ayar set stokdurum='" + durum + "'", bag);
                MySqlDataReader oku = gun.ExecuteReader();
                bag.Close();
            }
            catch { }
        }
        public void yenisatis(string ad, string sad, int adet, double fiyat, string tarih,string aytarih, string starih,double isko1,double kdv,string vergi,string fiili,double afiyat,string saat,string vergid)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("insert into satis(ad,sad,adet,fiyat,tarih,aytarih,starih,kdv)values('" + ad + "','" + sad + "','" + adet + "','" + fiyat + "','" + tarih + "','" + aytarih + "','" + starih  + "','" + kdv + "')", bag);
            MessageBox.Show("Yeni Satışınız Eklenmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ekle.ExecuteNonQuery();
            bag.Close();

        }
        public void yenikategori(string kad)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("insert into kategori(kadi)values('" + kad + "')", bag);
            MessageBox.Show("Yeni Kategoriniz Eklenmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ekle.ExecuteNonQuery();
            bag.Close();

        }

        public void gun(string tarih ,string dadi,string sahip,string yetkili,string adres){
            Crydepo dp = new Crydepo();
            bag.Open();
            MySqlCommand gun = new MySqlCommand("update depo set tarih='"+tarih+"',dadi='"+dadi+"',sahip='"+sahip+"',yetkili='"+yetkili+"',adres='"+adres+"' where dadi='"+depoadi+"'",bag);
            MySqlDataReader oku = gun.ExecuteReader();
            MessageBox.Show("Güncelleme Başarılı");
            bag.Close();
        }
        public void stoktansil(string ukodu)
        {
            bag.Open();
            MySqlCommand sil = new MySqlCommand("delete from stok where ukodu='"+ukodu+"'",bag);
            sil.ExecuteNonQuery();
            MessageBox.Show("Stok kayıtlarından başarıyla silinmitir.","DURUM",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            bag.Close();
            
        }
        public void satistansil(int id)
        { DialogResult sor = MessageBox.Show("Satış Kayıtlarından Silmek İstediğinizden Eminmisiniz?", "DURUM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (sor == DialogResult.Yes)
        {
            bag.Open();
            MySqlCommand sil = new MySqlCommand("delete from satis where id='" + id + "'", bag);
            sil.ExecuteNonQuery();
            MessageBox.Show("Satış kayıtlarından başarıyla silinmitir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bag.Close();
        }
        }
        public void depoyusil(string dadi)
        {
            bag.Open();
            MySqlCommand sil = new MySqlCommand("delete from depo where dadi='" + dadi + "'", bag);
            sil.ExecuteNonQuery();
            MessageBox.Show("Seçili Depo Silinmitir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bag.Close();

        }
        public void kategorisil(string kadi)
        {
            bag.Open();
            MySqlCommand sil = new MySqlCommand("delete from kategori where kadi='" + kadi + "'", bag);
            sil.ExecuteNonQuery();
            MessageBox.Show("Kategoriniz başarıyla silinmitir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bag.Close();

        }
        public void kullanicisil(string kullanici)
        {
            DialogResult sor = MessageBox.Show(kullanici+" Hesabını Silmek İstediğinizden Eminmisiniz?", "DURUM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sor == DialogResult.Yes)
            {
                bag.Open();
                MySqlCommand sil = new MySqlCommand("delete from kullanici where kullanici='" + kullanici + "'", bag);
                sil.ExecuteNonQuery();
                MessageBox.Show("Hesap Başarıyla Silinmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                bag.Close();
            }
        }
        public void tumunusilme(string secim)
        {
            bag.Open();
            MySqlCommand sil = new MySqlCommand("delete from "+secim+"", bag);
            sil.ExecuteNonQuery();
            MessageBox.Show("Tüm Kayıtlarınız Başarıyla Silinmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bag.Close();
        }
        public void giriscikissil(string sec,int id)
        {
            bag.Open();
            MySqlCommand sil = new MySqlCommand("delete from "+sec+" where id='" + id + "'", bag);
            sil.ExecuteNonQuery();
            MessageBox.Show("Seçili Kayıt Başarıyla Silinmiştir.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            bag.Close();

        }

        public void yardim(string dadi,string isim, string tel,string sorun,string lisans)
        {
            bag.Open();
            MySqlCommand ekle = new MySqlCommand("insert into yardim(dadi,isim,tel,sorun,lisans)values('" + dadi + "','" + isim + "','" + tel + "','" + sorun + "','" + lisans + "')", bag);
            MessageBox.Show("Destek Talebiniz Alınmıştır.En Kısa Sürede İlgilenilecektir.Dilerseniz Bizi Arıyabilir Detaylı Bilgi Alabilirsiniz.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ekle.ExecuteNonQuery();
            bag.Close();

        }




    }
}

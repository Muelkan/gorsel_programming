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
    public partial class Crydepo : Form
    {
        //
        CryAnaekran cr = new CryAnaekran();
        SabitYenistok ystok = (SabitYenistok)Application.OpenForms["SabitYenistok"];
        //
        string kontrol;
        public Crydepo()
        {
            InitializeComponent();
          
            yetkili.Text = cr.kim;
            yukle();
            
        }
    
        Veritabani vtt = new Veritabani();
       void yukle(){
           dadi.Items.Clear();
            vtt.bag.Open();
               MySqlCommand liste = new MySqlCommand("select * from depo", vtt.bag);
               MySqlDataReader oku = liste.ExecuteReader();
          while(oku.Read())
          {
              kontrol = oku["dadi"].ToString();
              dadi.Items.Add(oku["dadi"].ToString());
              dadi.Text = oku["dadi"].ToString();


          }
          vtt.bag.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SabitYenistok ystok = (SabitYenistok)Application.OpenForms["SabitYenistok"];
            if (button3.Text != "Güncelle")
            {
                if (dadi.Items.Contains(fadi.Text) == false)
                {
                    vtt.yenidepoekle(tarih.Text.ToString(), fadi.Text.ToString(), model.Text.ToString(), yetkili.Text.ToString(), aciklama.Text.ToString());
                    ystok.depoadi();
                    yukle();
                }
                else
                {
                    MessageBox.Show("Bu DepoZaten Kayıtlıdır.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
         
                vtt.gun(tarih.Text.ToString(), fadi.Text.ToString(), model.Text.ToString(), yetkili.Text.ToString(), aciklama.Text.ToString());
                ystok.depoadi();
                yukle();
                this.Hide();
          

            }
        }

        private void Crydepo_Load(object sender, EventArgs e)
        {
        
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Text = "Güncelle";
            vtt.depoadi = dadi.Text;
            vtt.bag.Open();
            MySqlCommand listele = new MySqlCommand("select * from depo where dadi='" + dadi.Text.ToString() + "'", vtt.bag);
            MySqlDataReader oku = listele.ExecuteReader();
            while (oku.Read())
            {
                tarih.Text = oku["tarih"].ToString();
                fadi.Text = oku["dadi"].ToString();
                model.Text = oku["sahip"].ToString();
                yetkili.Text = oku["yetkili"].ToString();
                aciklama.Text = oku["adres"].ToString();
            }
            vtt.bag.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vtt.depoyusil(dadi.Text);
            ystok.depoadi();
            yukle();
        }
    }
}

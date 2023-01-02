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
    public partial class yardim : Form
    {    Veritabani vt=new Veritabani();

        public yardim()
        {
            InitializeComponent();
            yukleprofil();
        }
        public void yukleprofil()
        {
            vt.bag.Open();
            MySqlCommand komut = new MySqlCommand("select * from ayar ", vt.bag);
            MySqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                isim.Text = oku["isimsoyisim"].ToString();
                tel.Text = oku["tel"].ToString();
                lisans.Text = oku["lisans"].ToString();
            }
            vt.bag.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Destek Talebiniz İletilmiştir Bizi Arıyabilirsiniz.");
        }
    }
}

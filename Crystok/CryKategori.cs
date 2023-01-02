using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Crystok
{
    
    public partial class CryKategori : Form
    {
        SabitYenistok ystok = (SabitYenistok)Application.OpenForms["SabitYenistok"];
        Veritabani vt = new Veritabani();
        string kotrol;
        public CryKategori()
        {
            InitializeComponent();
            kategori();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SabitYenistok ystok = (SabitYenistok)Application.OpenForms["SabitYenistok"];

            if (dadi.Items.Contains(fadi.Text) == false)
            {
               
                vt.yenikategori(fadi.Text);
                kategori();
                ystok.kategori();
                fadi.Text = "";
            }
            else
            {
                     MessageBox.Show("Bu Kategori Bulunmaktadır.", "DURUM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
        void kategori()
        {
            dadi.Items.Clear();
            vt.bag.Open();
            MySqlCommand liste = new MySqlCommand("select * from kategori", vt.bag);
            MySqlDataReader oku = liste.ExecuteReader();
            while (oku.Read())
            {
                dadi.Items.Add(oku["kadi"].ToString());
                kotrol = oku["kadi"].ToString();
                dadi.Text = oku["kadi"].ToString();


            }
            vt.bag.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vt.kategorisil(dadi.Text);
            ystok.kategori();
            kategori();
        }

        private void fadi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Crystok
{
    public partial class havadrm : Form
    {
        string hava = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";


        public havadrm()
        {
            InitializeComponent();
        }

        private void havadrm_Load(object sender, EventArgs e)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(hava);
            XmlElement root = doc1.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("sehirler");
            foreach (XmlNode node in nodes)
            {
                string ili = node["ili"].InnerText;
                string durum = node["Durum"].InnerText;
                string max_scaklk = node["Mak"].InnerText;

                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = ili;
                row.Cells[1].Value = durum;
                row.Cells[2].Value = max_scaklk;
                dataGridView1.Rows.Add(row);


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris grs = new giris();

            grs.Show();
            this.Hide();
        }
    }
}

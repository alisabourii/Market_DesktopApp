using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using System.Data.SqlClient;

namespace MarketApplication
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ExportHelper().Export(dataGridView1);
        }

        private void son1AyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=marketapp_database; uid=root; pwd=Ali@2006");

                tunel.Open();
                MySqlCommand cmd = new MySqlCommand("Delete from scap",tunel);
                cmd.ExecuteNonQuery();
                tunel.Close();
            }
            catch (Exception ex) { }
        }

        private void listele()
        {
            MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=marketapp_database; uid=root; pwd=Ali@2006");
            try
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("select * from scap", tunel);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                tunel.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

public class Product
{
    public string ID { get; set; }
    public string Tarih { get; set; }
    public string Icecek { get; set; }
    public string Yemek { get; set; }
    public decimal ToplamFiyat { get; set; }
}
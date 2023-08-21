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

namespace MarketApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text =  Convert.ToString(FiyatBulma.icecekler(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, numericUpDown1,numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9, numericUpDown10, numericUpDown11, numericUpDown12)) +"TL";
            
            List<CheckBox> list = new List<CheckBox>() { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12 };
            for(int i = 0; i < 11; i++) {
                list[i].Checked = false;
            }
            List<NumericUpDown> listNum = new List<NumericUpDown>() { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9, numericUpDown10, numericUpDown11, numericUpDown12 };
            for (int i = 0; i < 11; i++)
            {
                listNum[i].Value = 0;
            }
        }

        private void showPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
class FiyatBulma
{
    public static decimal icecekler(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6, CheckBox cb7, CheckBox cb8, CheckBox cb9, CheckBox cb10, CheckBox cb11, CheckBox cb12, NumericUpDown nu1, NumericUpDown nu2, NumericUpDown nu3, NumericUpDown nu4, NumericUpDown nu5, NumericUpDown nu6, NumericUpDown nu7, NumericUpDown nu8, NumericUpDown nu9, NumericUpDown nu10, NumericUpDown nu11, NumericUpDown nu12)
    {

        //---------------İçecekler Fiayti Testi----------- 
        int TKahveF = 30;
        int SpersoF = 45;
        int LatteF = 55;
        int CapichoF = 50;
        int MochaF = 40;
        int CayF = 10;
        int AmericanoF = 40;
        int SMochaF = 40;
        int PortakalSuyuF = 30;
        int KolaF = 5;
        int AyranF = 5;
        int GazozF = 5;

        decimal toplamFiyat = 0;
        String urunuler = "";

        if (cb1.Checked) { toplamFiyat += (nu1.Value) * TKahveF; urunuler += "Türk.K"; }
        if (cb2.Checked) { toplamFiyat += (nu2.Value) * SpersoF; urunuler += "sperso"; }
        if (cb3.Checked) { toplamFiyat += (nu3.Value) * LatteF; urunuler += "Latte"; }
        if (cb4.Checked) { toplamFiyat += (nu4.Value) * CapichoF; urunuler += "Capicho"; }
        if (cb5.Checked) { toplamFiyat += (nu5.Value) * MochaF; urunuler += "Mocha"; }
        if (cb6.Checked) { toplamFiyat += (nu6.Value) * CayF; urunuler += "Çay"; }
        if (cb7.Checked) { toplamFiyat += (nu7.Value) * AmericanoF; urunuler += "Americano"; }
        if (cb8.Checked) { toplamFiyat += (nu8.Value) * SMochaF; urunuler += "Soğuk Mocha"; }
        if (cb9.Checked) { toplamFiyat += (nu9.Value) * PortakalSuyuF; urunuler += "Portakal.S"; }
        if (cb10.Checked) { toplamFiyat += (nu10.Value) * KolaF; urunuler += "Kola"; }
        if (cb11.Checked) { toplamFiyat += (nu11.Value) * AyranF; urunuler += "Ayyran"; }
        if (cb12.Checked) { toplamFiyat += (nu12.Value) * GazozF; urunuler += "Gazoz"; }

        //sqlCommandLar sc = new sqlCommandLar();
       // sc.ekleme($"{}");
        return toplamFiyat;
    }
    public static string nowTime()
    {
        DateTime currentDateTime = DateTime.Now;
        int currentYear = currentDateTime.Year;
        int currentMonth = currentDateTime.Month;
        int currentDay = currentDateTime.Day;
        String date = $"{currentYear.ToString()}/{currentMonth.ToString()}/{currentDay.ToString()}";
        return date;
    }
    public static string id()
    {
        string date = nowTime();
        string trg = date.Replace("/", "");
        return trg;
    }
}


class sqlCommandLar
{
    MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=marketapp_database; uid=root; pwd=Ali@2006");
    public void ekleme(String txt)
    {
        try
        {
            tunel.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO marketapp(id,tarih,icecek,yemek) VALUES("+txt+");",
                                                tunel);
        }
        catch(Exception e) 
        {
            MessageBox.Show(e.Message); 
        }
    }
    public void goster()
    {
        try
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from scap",tunel);
            DataTable dt = new DataTable();
            adp.Fill(dt);

        }
        catch (Exception e) {MessageBox.Show(e.Message); }
    }
}
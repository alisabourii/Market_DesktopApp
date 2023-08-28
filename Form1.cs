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
            string txt = Convert.ToString(FiyatBulma.fiyatBul(checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12,checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19, numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9, numericUpDown10, numericUpDown11, numericUpDown12,numericUpDown13, numericUpDown14, numericUpDown15, numericUpDown16, numericUpDown17, numericUpDown18, numericUpDown19));
            
            label3.Text = txt + "TL";
            
            List<CheckBox> list = new List<CheckBox>() { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10, checkBox11, checkBox12, checkBox13, checkBox14, checkBox15, checkBox16, checkBox17, checkBox18, checkBox19 };
            for(int i = 0; i < 19; i++) {
                list[i].Checked = false;
            }
            List<NumericUpDown> listNum = new List<NumericUpDown>() { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9, numericUpDown10, numericUpDown11, numericUpDown12, numericUpDown13, numericUpDown14, numericUpDown15, numericUpDown16, numericUpDown17, numericUpDown18, numericUpDown19 };
            for (int i = 0; i < 19; i++)
            {
                listNum[i].Value = 0;
            }
        }

        private void showPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown1.Value != 0) { checkBox1.Checked = true; } else { checkBox1.Checked = false; } }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown2.Value != 0) { checkBox2.Checked = true; } else { checkBox2.Checked = false; }}
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown3.Value != 0) { checkBox3.Checked = true; } else { checkBox3.Checked = false; } }
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown4.Value != 0) { checkBox4.Checked = true; } else { checkBox4.Checked = false; }}
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown5.Value != 0) { checkBox5.Checked = true; } else { checkBox5.Checked = false; }}
        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        { if (numericUpDown6.Value != 0) { checkBox6.Checked = true; } else { checkBox6.Checked = false; } }
        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown7.Value != 0) { checkBox7.Checked = true; } else { checkBox7.Checked = false; }}
        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown8.Value != 0) { checkBox8.Checked = true; } else { checkBox8.Checked = false; }}
        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {if(numericUpDown10.Value != 0) { checkBox10.Checked = true; } else { checkBox10.Checked = false; }}
        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown11.Value != 0) { checkBox11.Checked = true; } else { checkBox11.Checked = false; }}
        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown12.Value != 0) { checkBox12.Checked = true; } else { checkBox12.Checked = false; }}
        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {if(numericUpDown9.Value != 0) { checkBox9.Checked = true; } else { checkBox9.Checked = false; } }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown13.Value != 0) { checkBox13.Checked = true; } else { checkBox13.Checked = false; }}

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown14.Value != 0) { checkBox14.Checked = true; } else { checkBox14.Checked = false; }}

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown15.Value != 0) { checkBox15.Checked = true; } else { checkBox15.Checked = false; }}

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        { if (numericUpDown16.Value != 0) { checkBox16.Checked = true; } else { checkBox16.Checked = false; }}

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        { if (numericUpDown17.Value != 0) { checkBox17.Checked = true; } else { checkBox17.Checked = false; }}

        private void databasExelÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //sqlCommandLar.exelCikar();
            Form3 CloseApp = new Form3();
            this.Close();
            CloseApp.Show();
            CloseApp.Close();
        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown18.Value != 0) { checkBox18.Checked = true; } else { checkBox18.Checked = false; } }

        private void numericUpDown19_ValueChanged(object sender, EventArgs e)
        {if (numericUpDown19.Value != 0) { checkBox19.Checked = true; } else { checkBox19.Checked = false; }}

    }
}
class FiyatBulma
{
    public String urn = "";
    public static decimal fiyatBul(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6, CheckBox cb7, CheckBox cb8, CheckBox cb9, CheckBox cb10, CheckBox cb11, CheckBox cb12, CheckBox cb13, CheckBox cb14, CheckBox cb15, CheckBox cb16, CheckBox cb17, CheckBox cb18, CheckBox cb19, NumericUpDown nu1, NumericUpDown nu2, NumericUpDown nu3, NumericUpDown nu4, NumericUpDown nu5, NumericUpDown nu6, NumericUpDown nu7, NumericUpDown nu8, NumericUpDown nu9, NumericUpDown nu10, NumericUpDown nu11, NumericUpDown nu12, NumericUpDown nu13, NumericUpDown nu14, NumericUpDown nu15, NumericUpDown nu16, NumericUpDown nu17, NumericUpDown nu18, NumericUpDown nu19)
    {
        decimal toplamFiyat = 0;

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
        
        String icecekUrunleri = "";
       

        if (cb1.Checked) { toplamFiyat += (nu1.Value) * TKahveF; icecekUrunleri += $"/Turk.K:{nu1.Value}"; }
        if (cb2.Checked) { toplamFiyat += (nu2.Value) * SpersoF; icecekUrunleri += $"/sperso:{nu2.Value}"; }
        if (cb3.Checked) { toplamFiyat += (nu3.Value) * LatteF; icecekUrunleri += $"/Latte:{nu3.Value}"; }
        if (cb4.Checked) { toplamFiyat += (nu4.Value) * CapichoF; icecekUrunleri += $"/Capicho:{nu4.Value}"; }
        if (cb5.Checked) { toplamFiyat += (nu5.Value) * MochaF; icecekUrunleri += $"/Mocha:{nu5.Value}"; }
        if (cb6.Checked) { toplamFiyat += (nu6.Value) * CayF; icecekUrunleri += $"/Cay:{nu6.Value}"; }
        if (cb7.Checked) { toplamFiyat += (nu7.Value) * AmericanoF; icecekUrunleri += $"/Americano:{nu7.Value}"; }
        if (cb8.Checked) { toplamFiyat += (nu8.Value) * SMochaF; icecekUrunleri += $"/Soguk Mocha:{nu8.Value}"; }
        if (cb9.Checked) { toplamFiyat += (nu9.Value) * PortakalSuyuF; icecekUrunleri += $"/Portakal.S:{nu9.Value}"; }
        if (cb10.Checked) { toplamFiyat += (nu10.Value) * KolaF; icecekUrunleri += $"/Kola:{nu10.Value}"; }
        if (cb11.Checked) { toplamFiyat += (nu11.Value) * AyranF; icecekUrunleri += $"/Ayyran:{nu11.Value}"; }
        if (cb12.Checked) { toplamFiyat += (nu12.Value) * GazozF; icecekUrunleri += $"/Gazoz:{nu12.Value}"; }

        //---------------Yemeklerin Fiayti Testi----------- 
        int tostF = 30;
        int humburgerF = 70;
        int nagetF = 35;
        int donerF = 40;
        int digerF = 25;
        int sufleF = 25;
        int baklavaF  = 40;

        String yemkeUrunleri = "";

        if (cb13.Checked) { toplamFiyat += (nu13.Value) * tostF; yemkeUrunleri += $"/Tost:{nu13.Value}"; }
        if (cb14.Checked) { toplamFiyat += (nu14.Value) * humburgerF; yemkeUrunleri += $"/Humburger:{nu14.Value}"; }
        if (cb15.Checked) { toplamFiyat += (nu15.Value) * nagetF; yemkeUrunleri += $"/Naget:{nu15.Value}"; }
        if (cb16.Checked) { toplamFiyat += (nu16.Value) * donerF; yemkeUrunleri += $"/Döner:{nu16.Value}"; }
        if (cb17.Checked) { toplamFiyat += (nu17.Value) * digerF; yemkeUrunleri += $"/Diger:{nu17.Value}"; }
        if (cb18.Checked) { toplamFiyat += (nu18.Value) * sufleF; yemkeUrunleri += $"/Sufle:{nu18.Value}"; }
        if (cb19.Checked) { toplamFiyat += (nu19.Value) * baklavaF; yemkeUrunleri += $"/Diger:{nu19.Value}"; }

        sqlCommandLar.ekleme(icecekUrunleri,yemkeUrunleri,toplamFiyat);

        return toplamFiyat;

    }
}

class TimeClues 
{
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
    public string icecek;
    public string yemek;
    public int toplamFiyat;
    public static void ekleme(String icecek, String yemek,decimal ToplamFiyat)
    {
        MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=marketapp_database; uid=root; pwd=Ali@2006");
        try
        {
            tunel.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO scap (Tarih, Icecek, Yemek, ToplamFiyat)"+
                                                "VALUES('"+ TimeClues.nowTime()+"', '"+icecek+"','"+yemek+"','"+ToplamFiyat+"') ",
                                                     tunel);
            cmd.ExecuteNonQuery();
            tunel.Close();

        }
        catch(Exception e) 
        {
            MessageBox.Show(e.Message); 
        }
    }
    public static void goster(String txt)
    {
        MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=marketapp_database; uid=root; pwd=Ali@2006");
        try
        {
            MySqlDataAdapter adp = new MySqlDataAdapter(txt,tunel);
            DataTable dt = new DataTable();
            adp.Fill(dt);

        }
        catch (Exception e) {MessageBox.Show(e.Message); }
    }

    public static void exelCikar()
    {
         Microsoft.Office.Interop.Excel.Application exelApp = new Microsoft.Office.Interop.Excel.Application();
    }


    
}

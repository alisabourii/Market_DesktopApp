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
    }
}
class FiyatBulma
{
    public static decimal icecekler(CheckBox cb1, CheckBox cb2, CheckBox cb3, CheckBox cb4, CheckBox cb5, CheckBox cb6, CheckBox cb7, CheckBox cb8, CheckBox cb9, CheckBox cb10, CheckBox cb11, CheckBox cb12, NumericUpDown nu1, NumericUpDown nu2, NumericUpDown nu3, NumericUpDown nu4, NumericUpDown nu5, NumericUpDown nu6, NumericUpDown nu7, NumericUpDown nu8, NumericUpDown nu9, NumericUpDown nu10, NumericUpDown nu11, NumericUpDown nu12)
    {

        //---------------İçecekler Fiayti----------- 
        int TKahveF = 30;
        int SpersoF = 45;
        int LatteF = 55;
        int CapichoF = 50;
        int MochaF = 40;
        int CayF = 10;
        int AmericanoF = 40;
        int SMochaF = 40;
        int PortakalSuyuF = 30;
        int digerf1 = 5;
        int figerf2 = 5;
        int digerf3 = 5;

        decimal toplamFiyat = 0;

        if (cb1.Checked) { toplamFiyat += (nu1.Value) * TKahveF; }
        if (cb2.Checked) { toplamFiyat += (nu2.Value) * SpersoF; }
        if (cb3.Checked) { toplamFiyat += (nu3.Value) * LatteF; }
        if (cb4.Checked) { toplamFiyat += (nu4.Value) * CapichoF; }
        if (cb5.Checked) { toplamFiyat += (nu5.Value) * MochaF; }
        if (cb6.Checked) { toplamFiyat += (nu6.Value) * CayF; }
        if (cb7.Checked) { toplamFiyat += (nu7.Value) * AmericanoF; }
        if (cb8.Checked) { toplamFiyat += (nu8.Value) * SMochaF; }
        if (cb9.Checked) { toplamFiyat += (nu9.Value) * PortakalSuyuF; }
        if (cb10.Checked) { toplamFiyat += (nu10.Value) * digerf1; }
        if (cb11.Checked) { toplamFiyat += (nu11.Value) * figerf2; }
        if (cb12.Checked) { toplamFiyat += (nu12.Value) * digerf3; }

        return toplamFiyat;
    }
}


class sqlCommandLar
{
    MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=platform_database; uid=root; pwd=Ali@2006");
    public void ekleme(String txt)
    {

    }
    public void Show()
    {

    }
}
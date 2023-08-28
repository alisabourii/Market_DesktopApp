using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Authentication.ExtendedProtection;

namespace SCAP
{
    public class ExportHelper
    {
        public bool Export(DataGridView dgv)
        {
            bool exported = false;

            List<String> lines = new List<String>();
            //Header
            DataGridViewColumnCollection header = dgv.Columns;
            bool firstDone = false;
            StringBuilder headeLine = new StringBuilder();

            int controller = 0;
            bool firstId = false;
            bool brk1 = false;
            bool brk2 = false;
        

            //-----For Get COL. COL is = (ID,Tarih,İçecek,Yemek,ToplamFiyat)
            foreach (DataGridViewColumn col in header)
            {
                if(brk2==true) { break; }
                if (!firstDone)
                {
                    headeLine.Append(col.DataPropertyName);
                    firstDone = true;
                }
                else { headeLine.Append(" | " + col); }
                lines.Add(headeLine.ToString());
                //Data Lines


                // Lengh in evry data.  (For example now is 12)
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (brk1 == true) { brk2 = true; break; }
                    {
                        
                    }
                    //MessageBox.Show(row.ToString());
                    StringBuilder dateLine = new StringBuilder();
                    firstDone = false;

                    string  cl = "";
                    foreach (DataGridViewCell cell1 in row.Cells)
                    {
                        cl = Convert.ToString(cell1.Value);
                        if (!firstDone)
                        {
                            dateLine.Append(cell1.Value);
                            firstDone = true;
                            //MessageBox.Show(cell1.Value.ToString());                            
                        }
                        else
                        {
                            dateLine.Append(" | " + cell1.Value);
                        }
                    }
                    lines.Add(dateLine.ToString());
                    
                    if(cl  == Convert.ToString(FoundID())) { break; brk1 = true; }
                }
            }

            string File = @"C:\Users\alisa\OneDrive\Desktop\somefile.csv";
            System.IO.File.WriteAllLines(File, lines.ToArray());
            System.Diagnostics.Process.Start(File);

            return exported;
        }

        public int FoundID()
        {
            int MaxId = 0;
            MySqlConnection tunel = new MySqlConnection("Server=localhost; Database=marketapp_database; uid=root; pwd=Ali@2006");
            try
            {
                tunel.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT MAX(ID) from scap",
                                                         tunel);
                //cmd.ExecuteNonQuery();
                object respoce = cmd.ExecuteScalar();
                MaxId = Convert.ToInt32(respoce);
                tunel.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return MaxId;
}
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace MarketApplication
{
    public class ExportHelper
    {
        public bool Export(DataGridView dgv)
        {
            bool exported  = false;

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
                if (brk2 == true) { break; }
                if (!firstDone)
                {
                    headeLine.Append(col.DataPropertyName);
                    firstDone = true;
                }
                else { headeLine.Append(" | "+col); }
                lines.Add(headeLine.ToString());
                //Data Lines

                
                // Lengh in evry data.  (For example now is 12)
                foreach(DataGridViewRow row in dgv.Rows)
                { 
                    if (brk1 == true) { break; brk2 = true; }
                    //MessageBox.Show(row.ToString());
                    StringBuilder dateLine = new StringBuilder();
                    firstDone = false;
                    
                    if (firstId == true)
                    {
                        break;
                        brk1 = true;
                    }
                    foreach (DataGridViewCell cell1 in row.Cells)
                    {
                        if (!firstDone)
                        {
                            dateLine.Append(cell1.Value);
                            firstDone = true;
                            //MessageBox.Show(cell1.Value.ToString());
                            controller++;
                        }
                        else
                        {
                            dateLine.Append(" | " + cell1.Value);
                        }
                        if (cell1.Value.ToString() == "1" && controller>1)
                            firstId = true;
                    }
                    lines.Add(dateLine.ToString());
                    
                }
            }
            string File = @"C:\Users\alisa\OneDrive\Desktop\somefile.csv";
            System.IO.File.WriteAllLines(File, lines.ToArray());
            System.Diagnostics.Process.Start(File);

            return exported;
        }
    }
}

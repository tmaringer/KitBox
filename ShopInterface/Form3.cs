using projectCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopInterface
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dataGridView1.DataSource = DBUtils.RefreshDBPartial("kitbox", "Code, PrixFourn1, DelaiFourn1, PrixFourn2, DelaiFourn2");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            progressBar1.Value = 10;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                if (row.Cells["PrixFourn1"].Value != null)
                {
                    double Prix1 = double.Parse(row.Cells["PrixFourn1"].Value.ToString().Replace(",", "."));
                    double Prix2 = double.Parse(row.Cells["PrixFourn2"].Value.ToString().Replace(",", "."));
                    if (Prix1 < Prix2)
                    {
                        DBUtils.UpdateDBV("suppliersprices", "SupplierNumber", "Code =\"" + row.Cells["Code"].Value + "\"", "1");
                        DBUtils.UpdateDBV("suppliersprices", "PrixFourn", "Code =\"" + row.Cells["Code"].Value + "\"", Prix1.ToString());
                        DBUtils.UpdateDBV("suppliersprices", "DelaiFourn", "Code =\"" + row.Cells["Code"].Value + "\"", Convert.ToInt32(row.Cells["DelaiFourn1"].Value).ToString());
                    }
                    else if (Prix1 > Prix2)
                    {
                        DBUtils.UpdateDBV("suppliersprices", "SupplierNumber", "Code =\"" + row.Cells["Code"].Value + "\"", "2");
                        DBUtils.UpdateDBV("suppliersprices", "PrixFourn", "Code =\"" + row.Cells["Code"].Value + "\"", Prix2.ToString());
                        DBUtils.UpdateDBV("suppliersprices", "DelaiFourn", "Code =\"" + row.Cells["Code"].Value + "\"", Convert.ToInt32(row.Cells["DelaiFourn2"].Value).ToString());
                    }
                    else
                    {
                        if (Convert.ToInt32(row.Cells["DelaiFourn1"].Value) < Convert.ToInt32(row.Cells["DelaiFourn2"].Value))
                        {
                            DBUtils.UpdateDBV("suppliersprices", "SupplierNumber", "Code =\"" + row.Cells["Code"].Value + "\"", "1");
                            DBUtils.UpdateDBV("suppliersprices", "DelaiFourn", "Code =\"" + row.Cells["Code"].Value + "\"", Convert.ToInt32(row.Cells["DelaiFourn1"].Value).ToString());
                            DBUtils.UpdateDBV("suppliersprices", "PrixFourn", "Code =\"" + row.Cells["Code"].Value + "\"", Prix1.ToString());
                        }
                        else
                        {
                            DBUtils.UpdateDBV("suppliersprices", "SupplierNumber", "Code =\"" + row.Cells["Code"].Value + "\"", "2");
                            DBUtils.UpdateDBV("suppliersprices", "DelaiFourn", "Code =\"" + row.Cells["Code"].Value + "\"", Convert.ToInt32(row.Cells["DelaiFourn2"].Value).ToString());
                            DBUtils.UpdateDBV("suppliersprices", "PrixFourn", "Code =\"" + row.Cells["Code"].Value + "\"", Prix2.ToString());
                        }
                    }
                }
                progressBar1.PerformStep();
            }
            button1.Enabled = true;
            progressBar1.Value = 10;
            dataGridView2.DataSource = DBUtils.RefreshDB("suppliersprices");
        }
    }
}

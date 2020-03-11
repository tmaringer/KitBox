using projectCS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopInterface
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            dataGridView1.DataSource = DBUtils.RefreshDB("suppliersprices");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToDouble(row.Cells["PrixFourn1"].Value) < Convert.ToDouble(row.Cells["PrixFourn2"].Value))
                {
                    //prixfourn1
                }
                else if (Convert.ToDouble(row.Cells["PrixFourn1"].Value) > Convert.ToDouble(row.Cells["PrixFourn2"].Value))
                {
                    //prixfourn2
                }
                else
                {
                    if (Convert.ToInt32(row.Cells["DelaiFourn1"].Value) < Convert.ToInt32(row.Cells["DelaiFourn2"].Value))
                    {
                        //prixfourn1
                    }
                    else
                    {
                        //prixfourn2
                    }
                }
            }
        }
    }
}

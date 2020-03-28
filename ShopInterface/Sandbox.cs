using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using projectCS;
using Color = System.Drawing.Color;
namespace ShopInterface
{
    class Sandbox
    {
        public static void SandBox(string OrderId)
        {
            DBUtils.DeleteRow("listsitems", "OrderId = \"" + OrderId + "\"");
            foreach (string i in DBUtils.RefList("CupboardId", "cupboards where OrderId = \""+ OrderId +"\""))
            {
                foreach (string j in DBUtils.RefList("BoxId", "boxes where CupboardId = \"" + i + "\""))
                {
                    foreach (string k in DBUtils.RefList("Code", "doors where BoxId= \"" + j + "\""))
                    {
                        Test(OrderId, k);
                        if (DBUtils.RefList("Code", "listsitems where OrderId = \"" + OrderId + "\" and Code = \"Cup\"").Count == 0)
                        {
                            DBUtils.InsertDB("listsitems","OrderId,Code,Quantity", "\"" + OrderId + "\", \"" + "Cup" + "\", \"" + "1" + "\"");
                        }
                        else
                        {
                            string quantity = DBUtils.RefList("Quantity", "listsitems where OrderId = \"" + OrderId + "\" and Code = \"Cup\"")[0];
                            int new_quantity = Convert.ToInt32(quantity) + 1;
                            DBUtils.UpdateDB("listsitems", "Quantity", "OrderId = \"" + OrderId + "\" and Code = \"Cup\"", new_quantity.ToString());
                        }
                    }
                    foreach (string k in DBUtils.RefList("Code", "crossbars where BoxId= \"" + j + "\""))
                    {
                        Test(OrderId, k);
                    }
                    foreach (string k in DBUtils.RefList("Code", "panels where BoxId= \"" + j + "\""))
                    {
                        Test(OrderId, k);
                    }
                    foreach (string k in DBUtils.RefList("Code", "cleats where BoxId= \"" + j + "\""))
                    {
                        Test(OrderId, k);
                    }
                    
                }
                foreach (string j in DBUtils.RefList("Code", "angles where CupboardId= \"" + i + "\""))
                {
                    Test(OrderId, j);
                }
            }
            Console.ReadLine();
        }

        public static void Test(string OrderId, string k)
        {
            if (DBUtils.RefList("Code", "listsitems where OrderId = \"" + OrderId + "\" and Code = \"" + k + "\"").Count == 0)
            {
                DBUtils.InsertDB("listsitems", "OrderId,Code,Quantity", "\"" + OrderId + "\", \"" + k + "\", \"" + "1" + "\"");
            }
            else
            {
                string quantity = DBUtils.RefList("Quantity", "listsitems where OrderId = \"" + OrderId + "\" and Code = \"" + k + "\"")[0];
                int new_quantity = Convert.ToInt32(quantity) + 1;
                DBUtils.UpdateDB("listsitems", "Quantity", "OrderId = \"" + OrderId + "\" and Code = \"" + k + "\"", new_quantity.ToString());
            }
        }

        public static void Depth(string CupboardId, int depth)
        {
            foreach (string i in DBUtils.RefList("BoxId", "boxes where CupboardId = \"" + CupboardId + "\""))
            {
                foreach (string j in DBUtils.RefList("Position", "crossbars where BoxId= \"" + i + "\""))
                {
                    // LL = LOW LEFT, HL = HIGH LEFT, LR = LOW RIGHT, HR = HIGH RIGHT
                    if (j == "LL" || j == "HL" || j == "LR" || j == "HR")
                    {
                        string code = DBUtils.RefList("Code", "crossbars where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string new_code = code.Substring(0, 3) + depth.ToString();
                        DBUtils.UpdateDB("crossbars", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", new_code);
                    }
                }
                foreach (string j in DBUtils.RefList("Position", "panels where BoxId= \"" + i + "\""))
                {
                    if (j == "H" || j == "L")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string width = DBUtils.RefList("Width", "kitbox where Code = \"" + code + "\"")[0];
                        string new_code = code.Substring(0, 3) + depth.ToString() + width.ToString() + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDB("panels", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", new_code);
                    }
                    else if (j == "RS" || j == "LS")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string height = DBUtils.RefList("Height", "kitbox where Code = \"" + code + "\"")[0];
                        string new_code = code.Substring(0, 3) + height.ToString() + depth.ToString() + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDB("panels", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", new_code);
                    }
                }
            }
            DBUtils.UpdateDB("cupboards", "Depth", "CupboardId= \"" + CupboardId + "\"", depth.ToString());
        }

        public static void Width(string CupboardId, int width)
        {
            foreach (string i in DBUtils.RefList("BoxId", "boxes where CupboardId = \"" + CupboardId + "\""))
            {
                if (Convert.ToInt32(DBUtils.RefList("Width", "cupboards where CupboardId = \"" + CupboardId + "\"")[0]) > 60)
                {
                    foreach (string j in DBUtils.RefList("DoorId", "doors where BoxId= \"" + i + "\""))
                    {
                        string new_code;
                        if (width == 62)
                        {
                            string code = DBUtils.RefList("Code", "doors where DoorId = \"" + j + "\"")[0];
                            new_code = code.Substring(0, 5) + "62" + code.Substring(7, 2);
                        }
                        else
                        {
                            string code = DBUtils.RefList("Code", "doors where DoorId = \"" + j + "\"")[0];
                            int new_largeur = (Convert.ToInt32(width) / 2) + 2;
                            new_code = code.Substring(0, 5) + new_largeur.ToString() + code.Substring(7, 2);
                        }
                        DBUtils.UpdateDB("doors", "Code", "DoorId = \"" + j + "\"", new_code);
                    }
                }
                foreach (string j in DBUtils.RefList("Position", "crossbars where BoxId= \"" + i + "\""))
                {
                    if (j == "HB" || j == "HF" || j == "LF" || j == "LB")
                    {
                        string code = DBUtils.RefList("Code", "crossbars where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string new_code = code.Substring(0, 3) + width.ToString();
                        DBUtils.UpdateDB("crossbars", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", new_code);
                    }
                }
                foreach (string j in DBUtils.RefList("Position", "panels where BoxId= \"" + i + "\""))
                {
                    if (j == "H" || j == "L" || j == "B")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string new_code = code.Substring(0, 5) + width.ToString() + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDB("panels", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", new_code);
                    }
                }
                
            }
            DBUtils.UpdateDB("cupboards", "Width", "CupboardId= \"" + CupboardId + "\"", width.ToString());
        }

        public static void Height(string BoxId, int height)
        {
            int specialheight = height - 4;
            string cupboardid = DBUtils.RefList("CupboardId", "boxes where BoxId= \"" + BoxId + "\"")[0];
            string backupheight = DBUtils.RefList("Height", "boxes where BoxId= \"" + BoxId + "\"")[0];
            int heightCupboard = 0;
            DBUtils.UpdateDB("boxes", "Height", "BoxId= \"" + BoxId + "\"", height.ToString());
            foreach (string i in DBUtils.RefList("Height", "boxes where CupboardId = \"" + cupboardid + "\""))
            {
                heightCupboard += Convert.ToInt32(i);
            }
            if (heightCupboard > 375)
            {
                DBUtils.UpdateDB("boxes", "Height", "BoxId= \"" + BoxId + "\"", backupheight);
            }
            else
            {
                foreach (string i in DBUtils.RefList("Code", "cleats where BoxId= \"" + BoxId + "\""))
                {
                    string new_code = i.Substring(0, 3) + (specialheight - 5).ToString();
                    DBUtils.UpdateDB("cleats", "Code", "BoxId = \"" + BoxId + "\"", new_code);
                }
                foreach (string i in DBUtils.RefList("Position", "panels where BoxId= \"" + BoxId + "\""))
                {
                    if (i == "B")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxId = \"" + BoxId + "\" and Position = \"" + i + "\"")[0];
                        string width = DBUtils.RefList("Width", "kitbox where Code = \"" + code + "\"")[0];
                        string new_code = code.Substring(0, 3) + specialheight.ToString() + width + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDB("panels", "Code", "Position = \"" + i + "\" and BoxId = \"" + BoxId + "\"", new_code);
                    }
                    else if (i == "RS" || i == "LS")
                    {
                        string code = DBUtils.RefList("Code", "panels where BoxId = \"" + BoxId + "\" and Position = \"" + i + "\"")[0];
                        string width = DBUtils.RefList("Depth", "kitbox where Code = \"" + code + "\"")[0];
                        string new_code = code.Substring(0, 3) + specialheight.ToString() + width + code.Substring(code.Length - 2, 2);
                        DBUtils.UpdateDB("panels", "Code", "Position = \"" + i + "\" and BoxId = \"" + BoxId + "\"", new_code);
                    }
                }
                foreach (string i in DBUtils.RefList("DoorId", "doors where BoxId= \"" + BoxId + "\""))
                {
                    string code = DBUtils.RefList("Code", "doors where BoxId = \"" + BoxId + "\" and DoorId = \"" + i + "\"")[0];
                    string new_code = code.Substring(0, 3) + specialheight.ToString() + code.Substring(code.Length - 4, 4);
                    DBUtils.UpdateDB("doors", "Code", "DoorId = \"" + i + "\"", new_code);
                }
                if (heightCupboard % 36 == 0 || heightCupboard % 46 == 0 || heightCupboard % 56 == 0)
                {
                    foreach (string i in DBUtils.RefList("AngleId", "angles where CupboardId= \"" + cupboardid + "\""))
                    {
                        string code = DBUtils.RefList("Code", "angles where AngleId = \"" + i + "\"")[0];
                        string new_code;
                        if (code.Length <= 8)
                        {
                            new_code = code.Substring(0, 3) + heightCupboard.ToString() + code.Substring(code.Length - 2, 2);
                        }
                        else
                        {
                            new_code = code.Substring(0, 3) + heightCupboard.ToString() + code.Substring(code.Length - 5, 2);
                        }
                        DBUtils.UpdateDB("angles", "Code", "AngleId = \"" + i + "\"", new_code);
                    }
                }
                else
                {
                    List<string> All = DBUtils.RefListND("Height", "kitbox where Ref = \"AngleBracket\"");
                    List<int> Unstandarded = new List<int>();
                    foreach(string i in All)
                    {
                        int ii = Convert.ToInt32(i);
                        if (ii % 36 != 0 && ii % 46 != 0 && ii % 56 != 0)
                        {
                            Unstandarded.Add(ii);
                        }
                    }
                    int x = 10000;
                    foreach (int value in Unstandarded)
                    {
                        if(value > heightCupboard && value < x)
                        {
                            x = value;
                        }
                    }
                    foreach (string i in DBUtils.RefList("AngleId", "angles where CupboardId= \"" + cupboardid + "\""))
                    {
                        string code = DBUtils.RefList("Code", "angles where AngleId = \"" + i + "\"")[0];
                        string new_code = "";
                        if (code.Length <= 8)
                        {
                            new_code = code.Substring(0, 3) + x.ToString() + code.Substring(code.Length - 2, 2) + "CUT";
                        }
                        else
                        {
                            new_code = code.Substring(0, 3) + x.ToString() + code.Substring(code.Length - 5, 5);
                        }
                        DBUtils.UpdateDB("angles", "Code", "AngleId = \"" + i + "\"", new_code);
                    }
                }
                DBUtils.UpdateDB("cupboards", "Height", "CupboardId = \"" + cupboardid + "\"", heightCupboard.ToString());
                DBUtils.UpdateDB("boxes", "Height", "BoxId= \"" + BoxId + "\"", height.ToString());
            }
        }

        public static void Doors(string BoxId, DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            DataTable elements = dataTable;
            DataColumn dtColumn = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "Id",
                ReadOnly = true,
                Unique = true
            };
            elements.Columns.Add(dtColumn);
            DataColumn dtColumn1 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Code",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn1);
            DataColumn dtColumn2 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Position",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn2);
            DataColumn dtColumn3 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Stock",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn3);
            int index = 1;
            foreach (string i in DBUtils.RefList("DoorId", "doors where BoxId= \"" + BoxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DBUtils.RefList("Code", "doors where DoorId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = null;
                string enstock = DBUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
                if (Convert.ToInt32(enstock) < 10)
                { 
                    myDataRow["Stock"] = "false";
                }
                else
                {
                    myDataRow["Stock"] = "true";
                }
                elements.Rows.Add(myDataRow);
                index += 1;
            }
            dataGridView.DataSource = dataTable;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Stock"].Value.ToString() == "false")
                    row.Cells["Stock"].Style.BackColor = Color.Red;
                else
                    row.Cells["Stock"].Style.BackColor = Color.LimeGreen;
            }
        }

        public static void Panels(string BoxId, DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            DataTable elements = dataTable;
            DataColumn dtColumn = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "Id",
                ReadOnly = true,
                Unique = true
            };
            elements.Columns.Add(dtColumn);
            DataColumn dtColumn1 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Code",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn1);
            DataColumn dtColumn2 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Position",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn2);
            DataColumn dtColumn3 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Stock",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn3);
            int index = 1;
            foreach (string i in DBUtils.RefList("PanelId", "panels where BoxId= \"" + BoxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DBUtils.RefList("Code", "panels where PanelId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = DBUtils.RefList("Position", "panels where PanelId = \"" + i + "\"")[0];
                string enstock = DBUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
                if (Convert.ToInt32(enstock) < 10)
                {
                    myDataRow["Stock"] = "false";
                }
                else
                {
                    myDataRow["Stock"] = "true";
                }
                elements.Rows.Add(myDataRow);
                index += 1;
            }
            dataGridView.DataSource = dataTable;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Stock"].Value.ToString() == "false")
                    row.Cells["Stock"].Style.BackColor = Color.Red;
                else
                    row.Cells["Stock"].Style.BackColor = Color.LimeGreen;
            }
        }

        public static void Angles(string CupboardId, DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            DataTable elements = dataTable;
            DataColumn dtColumn = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "Id",
                ReadOnly = true,
                Unique = true
            };
            elements.Columns.Add(dtColumn);
            DataColumn dtColumn1 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Code",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn1);
            DataColumn dtColumn2 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Position",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn2);
            DataColumn dtColumn3 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Stock",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn3);
            int index = 1;
            foreach (string i in DBUtils.RefList("AngleId", "angles where CupboardId= \"" + CupboardId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DBUtils.RefList("Code", "angles where AngleId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = null;
                string enstock = DBUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
                if (Convert.ToInt32(enstock) < 10)
                {
                    myDataRow["Stock"] = "false";
                }
                else
                {
                    myDataRow["Stock"] = "true";
                }
                elements.Rows.Add(myDataRow);
                index += 1;
            }
            dataGridView.DataSource = dataTable;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Stock"].Value.ToString() == "false")
                    row.Cells["Stock"].Style.BackColor = Color.Red;
                else
                    row.Cells["Stock"].Style.BackColor = Color.LimeGreen;
            }
        }

        public static void ElementList(string BoxId, DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            DataTable elements = dataTable;
            DataColumn dtColumn = new DataColumn
            {
                DataType = typeof(Int32),
                ColumnName = "Id",
                ReadOnly = true,
                Unique = true
            };
            elements.Columns.Add(dtColumn);
            DataColumn dtColumn1 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Code",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn1);
            DataColumn dtColumn2 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Position",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn2);
            DataColumn dtColumn3 = new DataColumn
            {
                DataType = typeof(String),
                ColumnName = "Stock",
                ReadOnly = true,
                Unique = false
            };
            elements.Columns.Add(dtColumn3);
            int index = 1;
            foreach (string i in DBUtils.RefList("DoorId", "doors where BoxId= \"" + BoxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DBUtils.RefList("Code", "doors where DoorId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = null;
                string enstock = DBUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
                if (Convert.ToInt32(enstock) < 10)
                {
                    myDataRow["Stock"] = "false";
                }
                else
                {
                    myDataRow["Stock"] = "true";
                }
                elements.Rows.Add(myDataRow);
                index += 1;
            }
            foreach (string i in DBUtils.RefList("CrossbarId", "crossbars where BoxId= \"" + BoxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DBUtils.RefList("Code", "crossbars where CrossbarId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                string position = DBUtils.RefList("Position", "crossbars where CrossbarId = \"" + i + "\"")[0];
                myDataRow["Position"] = position;
                string enstock = DBUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
                if (Convert.ToInt32(enstock) < 10)
                {
                    myDataRow["Stock"] = "false";
                }
                else
                {
                    myDataRow["Stock"] = "true";
                }
                elements.Rows.Add(myDataRow);
                index += 1;
            }
            foreach (string i in DBUtils.RefList("PanelId", "panels where BoxId= \"" + BoxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DBUtils.RefList("Code", "panels where PanelId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                string position = DBUtils.RefList("Position", "panels where PanelId = \"" + i + "\"")[0];
                myDataRow["Position"] = position;
                string enstock = DBUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
                if (Convert.ToInt32(enstock) < 10)
                {
                    myDataRow["Stock"] = "false";
                }
                else
                {
                    myDataRow["Stock"] = "true";
                }
                elements.Rows.Add(myDataRow);
                index += 1;
            }
            foreach (string i in DBUtils.RefList("CleatId", "cleats where BoxId= \"" + BoxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DBUtils.RefList("Code", "cleats where CleatId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = null;
                string enstock = DBUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
                if (Convert.ToInt32(enstock) < 10)
                {
                    myDataRow["Stock"] = "false";
                }
                else
                {
                    myDataRow["Stock"] = "true";
                }
                elements.Rows.Add(myDataRow);
                index += 1;
            }
            dataGridView.DataSource = dataTable;
            foreach(DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells["Stock"].Value.ToString() == "false")
                    row.Cells["Stock"].Style.BackColor = Color.Red;
                else
                    row.Cells["Stock"].Style.BackColor = Color.LimeGreen;
            }
        }
    }
}
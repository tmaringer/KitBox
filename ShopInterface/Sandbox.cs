using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using projectCS;
using projectCS.Tools_class;
using Color = System.Drawing.Color;
namespace ShopInterface
{
    class Sandbox
    {
        public static void SandBox(string orderId)
        {
            DbUtils.DeleteRow("listsitems", "OrderId = \"" + orderId + "\"");
            foreach (string i in DbUtils.RefList("CupboardId", "cupboards where OrderId = \""+ orderId +"\""))
            {
                foreach (string j in DbUtils.RefList("BoxId", "boxes where CupboardId = \"" + i + "\""))
                {
                    foreach (string k in DbUtils.RefList("Code", "doors where BoxId= \"" + j + "\""))
                    {
                        Test(orderId, k);
                        if (DbUtils.RefList("Code", "listsitems where OrderId = \"" + orderId + "\" and Code = \"Cup\"").Count == 0)
                        {
                            DbUtils.InsertDb("listsitems","OrderId,Code,Quantity", "\"" + orderId + "\", \"" + "Cup" + "\", \"" + "1" + "\"");
                        }
                        else
                        {
                            string quantity = DbUtils.RefList("Quantity", "listsitems where OrderId = \"" + orderId + "\" and Code = \"Cup\"")[0];
                            int newQuantity = Convert.ToInt32(quantity) + 1;
                            DbUtils.UpdateDb("listsitems", "Quantity", "OrderId = \"" + orderId + "\" and Code = \"Cup\"", newQuantity.ToString());
                        }
                    }
                    foreach (string k in DbUtils.RefList("Code", "crossbars where BoxId= \"" + j + "\""))
                    {
                        Test(orderId, k);
                    }
                    foreach (string k in DbUtils.RefList("Code", "panels where BoxId= \"" + j + "\""))
                    {
                        Test(orderId, k);
                    }
                    foreach (string k in DbUtils.RefList("Code", "cleats where BoxId= \"" + j + "\""))
                    {
                        Test(orderId, k);
                    }
                    
                }
                foreach (string j in DbUtils.RefList("Code", "angles where CupboardId= \"" + i + "\""))
                {
                    Test(orderId, j);
                }
            }
            Console.ReadLine();
        }

        public static void Test(string orderId, string k)
        {
            if (DbUtils.RefList("Code", "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + k + "\"").Count == 0)
            {
                DbUtils.InsertDb("listsitems", "OrderId,Code,Quantity", "\"" + orderId + "\", \"" + k + "\", \"" + "1" + "\"");
            }
            else
            {
                string quantity = DbUtils.RefList("Quantity", "listsitems where OrderId = \"" + orderId + "\" and Code = \"" + k + "\"")[0];
                int newQuantity = Convert.ToInt32(quantity) + 1;
                DbUtils.UpdateDb("listsitems", "Quantity", "OrderId = \"" + orderId + "\" and Code = \"" + k + "\"", newQuantity.ToString());
            }
        }

        public static void Depth(string cupboardId, int depth)
        {
            foreach (string i in DbUtils.RefList("BoxId", "boxes where CupboardId = \"" + cupboardId + "\""))
            {
                foreach (string j in DbUtils.RefList("Position", "crossbars where BoxId= \"" + i + "\""))
                {
                    // LL = LOW LEFT, HL = HIGH LEFT, LR = LOW RIGHT, HR = HIGH RIGHT
                    if (j == "LL" || j == "HL" || j == "LR" || j == "HR")
                    {
                        string code = DbUtils.RefList("Code", "crossbars where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string newCode = code.Substring(0, 3) + depth.ToString();
                        DbUtils.UpdateDb("crossbars", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", newCode);
                    }
                }
                foreach (string j in DbUtils.RefList("Position", "panels where BoxId= \"" + i + "\""))
                {
                    if (j == "H" || j == "L")
                    {
                        string code = DbUtils.RefList("Code", "panels where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string width = DbUtils.RefList("Width", "kitbox where Code = \"" + code + "\"")[0];
                        string newCode = code.Substring(0, 3) + depth.ToString() + width + code.Substring(code.Length - 2, 2);
                        DbUtils.UpdateDb("panels", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", newCode);
                    }
                    else if (j == "RS" || j == "LS")
                    {
                        string code = DbUtils.RefList("Code", "panels where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string height = DbUtils.RefList("Height", "kitbox where Code = \"" + code + "\"")[0];
                        string newCode = code.Substring(0, 3) + height + depth.ToString() + code.Substring(code.Length - 2, 2);
                        DbUtils.UpdateDb("panels", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", newCode);
                    }
                }
            }
            DbUtils.UpdateDb("cupboards", "Depth", "CupboardId= \"" + cupboardId + "\"", depth.ToString());
        }

        public static void Width(string cupboardId, int width)
        {
            foreach (string i in DbUtils.RefList("BoxId", "boxes where CupboardId = \"" + cupboardId + "\""))
            {
                if (Convert.ToInt32(DbUtils.RefList("Width", "cupboards where CupboardId = \"" + cupboardId + "\"")[0]) > 60)
                {
                    foreach (string j in DbUtils.RefList("DoorId", "doors where BoxId= \"" + i + "\""))
                    {
                        string newCode;
                        if (width == 62)
                        {
                            string code = DbUtils.RefList("Code", "doors where DoorId = \"" + j + "\"")[0];
                            newCode = code.Substring(0, 5) + "62" + code.Substring(7, 2);
                        }
                        else
                        {
                            string code = DbUtils.RefList("Code", "doors where DoorId = \"" + j + "\"")[0];
                            int newWidth = (Convert.ToInt32(width) / 2) + 2;
                            newCode = code.Substring(0, 5) + newWidth.ToString() + code.Substring(7, 2);
                        }
                        DbUtils.UpdateDb("doors", "Code", "DoorId = \"" + j + "\"", newCode);
                    }
                }
                foreach (string j in DbUtils.RefList("Position", "crossbars where BoxId= \"" + i + "\""))
                {
                    if (j == "HB" || j == "HF" || j == "LF" || j == "LB")
                    {
                        string code = DbUtils.RefList("Code", "crossbars where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string newCode = code.Substring(0, 3) + width.ToString();
                        DbUtils.UpdateDb("crossbars", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", newCode);
                    }
                }
                foreach (string j in DbUtils.RefList("Position", "panels where BoxId= \"" + i + "\""))
                {
                    if (j == "H" || j == "L" || j == "B")
                    {
                        string code = DbUtils.RefList("Code", "panels where BoxId = \"" + i + "\" and Position = \"" + j + "\"")[0];
                        string newCode = code.Substring(0, 5) + width.ToString() + code.Substring(code.Length - 2, 2);
                        DbUtils.UpdateDb("panels", "Code", "Position = \"" + j + "\" and BoxId = \"" + i + "\"", newCode);
                    }
                }
                
            }
            DbUtils.UpdateDb("cupboards", "Width", "CupboardId= \"" + cupboardId + "\"", width.ToString());
        }

        public static void Height(string boxId, int height)
        {
            int specialheight = height - 4;
            string cupboardid = DbUtils.RefList("CupboardId", "boxes where BoxId= \"" + boxId + "\"")[0];
            string backupheight = DbUtils.RefList("Height", "boxes where BoxId= \"" + boxId + "\"")[0];
            int heightCupboard = 0;
            DbUtils.UpdateDb("boxes", "Height", "BoxId= \"" + boxId + "\"", height.ToString());
            foreach (string i in DbUtils.RefList("Height", "boxes where CupboardId = \"" + cupboardid + "\""))
            {
                heightCupboard += Convert.ToInt32(i);
            }
            if (heightCupboard > 375)
            {
                DbUtils.UpdateDb("boxes", "Height", "BoxId= \"" + boxId + "\"", backupheight);
            }
            else
            {
                foreach (string i in DbUtils.RefList("Code", "cleats where BoxId= \"" + boxId + "\""))
                {
                    string newCode = i.Substring(0, 3) + (specialheight - 5).ToString();
                    DbUtils.UpdateDb("cleats", "Code", "BoxId = \"" + boxId + "\"", newCode);
                }
                foreach (string i in DbUtils.RefList("Position", "panels where BoxId= \"" + boxId + "\""))
                {
                    if (i == "B")
                    {
                        string code = DbUtils.RefList("Code", "panels where BoxId = \"" + boxId + "\" and Position = \"" + i + "\"")[0];
                        string width = DbUtils.RefList("Width", "kitbox where Code = \"" + code + "\"")[0];
                        string newCode = code.Substring(0, 3) + specialheight.ToString() + width + code.Substring(code.Length - 2, 2);
                        DbUtils.UpdateDb("panels", "Code", "Position = \"" + i + "\" and BoxId = \"" + boxId + "\"", newCode);
                    }
                    else if (i == "RS" || i == "LS")
                    {
                        string code = DbUtils.RefList("Code", "panels where BoxId = \"" + boxId + "\" and Position = \"" + i + "\"")[0];
                        string width = DbUtils.RefList("Depth", "kitbox where Code = \"" + code + "\"")[0];
                        string newCode = code.Substring(0, 3) + specialheight.ToString() + width + code.Substring(code.Length - 2, 2);
                        DbUtils.UpdateDb("panels", "Code", "Position = \"" + i + "\" and BoxId = \"" + boxId + "\"", newCode);
                    }
                }
                foreach (string i in DbUtils.RefList("DoorId", "doors where BoxId= \"" + boxId + "\""))
                {
                    string code = DbUtils.RefList("Code", "doors where BoxId = \"" + boxId + "\" and DoorId = \"" + i + "\"")[0];
                    string newCode = code.Substring(0, 3) + specialheight.ToString() + code.Substring(code.Length - 4, 4);
                    DbUtils.UpdateDb("doors", "Code", "DoorId = \"" + i + "\"", newCode);
                }
                if (heightCupboard % 36 == 0 || heightCupboard % 46 == 0 || heightCupboard % 56 == 0)
                {
                    foreach (string i in DbUtils.RefList("AngleId", "angles where CupboardId= \"" + cupboardid + "\""))
                    {
                        string code = DbUtils.RefList("Code", "angles where AngleId = \"" + i + "\"")[0];
                        string newCode;
                        if (code.Length <= 8)
                        {
                            newCode = code.Substring(0, 3) + heightCupboard.ToString() + code.Substring(code.Length - 2, 2);
                        }
                        else
                        {
                            newCode = code.Substring(0, 3) + heightCupboard.ToString() + code.Substring(code.Length - 5, 2);
                        }
                        DbUtils.UpdateDb("angles", "Code", "AngleId = \"" + i + "\"", newCode);
                    }
                }
                else
                {
                    List<string> all = DbUtils.RefListNd("Height", "kitbox where Ref = \"AngleBracket\"");
                    List<int> unstandarded = new List<int>();
                    foreach(string i in all)
                    {
                        int ii = Convert.ToInt32(i);
                        if (ii % 36 != 0 && ii % 46 != 0 && ii % 56 != 0)
                        {
                            unstandarded.Add(ii);
                        }
                    }
                    int x = 10000;
                    foreach (int value in unstandarded)
                    {
                        if(value > heightCupboard && value < x)
                        {
                            x = value;
                        }
                    }
                    foreach (string i in DbUtils.RefList("AngleId", "angles where CupboardId= \"" + cupboardid + "\""))
                    {
                        string code = DbUtils.RefList("Code", "angles where AngleId = \"" + i + "\"")[0];
                        string newCode;
                        if (code.Length <= 8)
                        {
                            newCode = code.Substring(0, 3) + x.ToString() + code.Substring(code.Length - 2, 2) + "CUT";
                        }
                        else
                        {
                            newCode = code.Substring(0, 3) + x.ToString() + code.Substring(code.Length - 5, 5);
                        }
                        DbUtils.UpdateDb("angles", "Code", "AngleId = \"" + i + "\"", newCode);
                    }
                }
                DbUtils.UpdateDb("cupboards", "Height", "CupboardId = \"" + cupboardid + "\"", heightCupboard.ToString());
                DbUtils.UpdateDb("boxes", "Height", "BoxId= \"" + boxId + "\"", height.ToString());
            }
        }

        public static void Doors(string boxId, DataGridView dataGridView)
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
            foreach (string i in DbUtils.RefList("DoorId", "doors where BoxId= \"" + boxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DbUtils.RefList("Code", "doors where DoorId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = null;
                string enstock = DbUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
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

        public static void Panels(string boxId, DataGridView dataGridView)
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
            foreach (string i in DbUtils.RefList("PanelId", "panels where BoxId= \"" + boxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DbUtils.RefList("Code", "panels where PanelId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = DbUtils.RefList("Position", "panels where PanelId = \"" + i + "\"")[0];
                string enstock = DbUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
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

        public static void Angles(string cupboardId, DataGridView dataGridView)
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
            foreach (string i in DbUtils.RefList("AngleId", "angles where CupboardId= \"" + cupboardId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DbUtils.RefList("Code", "angles where AngleId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = null;
                string enstock = DbUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
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

        public static void ElementList(string boxId, DataGridView dataGridView)
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
            foreach (string i in DbUtils.RefList("DoorId", "doors where BoxId= \"" + boxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DbUtils.RefList("Code", "doors where DoorId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = null;
                string enstock = DbUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
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
            foreach (string i in DbUtils.RefList("CrossbarId", "crossbars where BoxId= \"" + boxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DbUtils.RefList("Code", "crossbars where CrossbarId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                string position = DbUtils.RefList("Position", "crossbars where CrossbarId = \"" + i + "\"")[0];
                myDataRow["Position"] = position;
                string enstock = DbUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
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
            foreach (string i in DbUtils.RefList("PanelId", "panels where BoxId= \"" + boxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DbUtils.RefList("Code", "panels where PanelId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                string position = DbUtils.RefList("Position", "panels where PanelId = \"" + i + "\"")[0];
                myDataRow["Position"] = position;
                string enstock = DbUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
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
            foreach (string i in DbUtils.RefList("CleatId", "cleats where BoxId= \"" + boxId + "\""))
            {
                DataRow myDataRow;
                myDataRow = elements.NewRow();
                myDataRow["Id"] = index;
                string code = DbUtils.RefList("Code", "cleats where CleatId = \"" + i + "\"")[0];
                myDataRow["Code"] = code;
                myDataRow["Position"] = null;
                string enstock = DbUtils.RefList("Instock", "kitbox where Code = \"" + code + "\"")[0];
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
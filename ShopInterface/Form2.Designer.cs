using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;

namespace ShopInterface
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dataGridView12 = new System.Windows.Forms.DataGridView();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.comboBox31 = new System.Windows.Forms.ComboBox();
            this.comboBox30 = new System.Windows.Forms.ComboBox();
            this.comboBox33 = new System.Windows.Forms.ComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.comboBox32 = new System.Windows.Forms.ComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.comboBox28 = new System.Windows.Forms.ComboBox();
            this.comboBox29 = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.button28 = new System.Windows.Forms.Button();
            this.dataGridView11 = new System.Windows.Forms.DataGridView();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.comboBox27 = new System.Windows.Forms.ComboBox();
            this.comboBox26 = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.comboBox25 = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.button25 = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.comboBox20 = new System.Windows.Forms.ComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.comboBox24 = new System.Windows.Forms.ComboBox();
            this.comboBox23 = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.button27 = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.comboBox21 = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.comboBox22 = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.button26 = new System.Windows.Forms.Button();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button17 = new System.Windows.Forms.Button();
            this.comboBox18 = new System.Windows.Forms.ComboBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.label47 = new System.Windows.Forms.Label();
            this.button24 = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.comboBox19 = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.comboBox17 = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button23 = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button21 = new System.Windows.Forms.Button();
            this.dataGridView10 = new System.Windows.Forms.DataGridView();
            this.dataGridView9 = new System.Windows.Forms.DataGridView();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView12)).BeginInit();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView11)).BeginInit();
            this.groupBox20.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.tabPage4.Controls.Add(this.progressBar2);
            this.tabPage4.Controls.Add(this.button16);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(972, 599);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Stock management";
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar2.ForeColor = System.Drawing.Color.Gold;
            this.progressBar2.Location = new System.Drawing.Point(489, 572);
            this.progressBar2.MarqueeAnimationSpeed = 160;
            this.progressBar2.Maximum = 3080;
            this.progressBar2.Minimum = 10;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(178, 13);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 16;
            this.progressBar2.Value = 10;
            // 
            // button16
            // 
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button16.Location = new System.Drawing.Point(489, 543);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(178, 23);
            this.button16.TabIndex = 15;
            this.button16.Text = "Update minimum stock value";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.comboBox3);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.chart1);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.comboBox2);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Location = new System.Drawing.Point(8, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(946, 349);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Generate a graph";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 205);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 13);
            this.label22.TabIndex = 14;
            this.label22.Text = "Value:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label15.Location = new System.Drawing.Point(520, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 31);
            this.label15.TabIndex = 13;
            this.label15.Text = "Loading";
            this.label15.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(131, 110);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(114, 21);
            this.comboBox3.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(49, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Value of selection";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(74, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Selection";
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(251, 17);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderColor = System.Drawing.Color.Black;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Black;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(689, 326);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(82, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Interval";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(131, 164);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(114, 21);
            this.comboBox2.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "day",
            "month",
            "year"});
            this.comboBox1.Location = new System.Drawing.Point(131, 137);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(114, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "day";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Code";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(150, 201);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(95, 21);
            this.button8.TabIndex = 0;
            this.button8.Text = "Generate";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToResizeColumns = false;
            this.dataGridView4.AllowUserToResizeRows = false;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.dataGridView4.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(8, 363);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.Size = new System.Drawing.Size(460, 230);
            this.dataGridView4.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.tabPage3.Controls.Add(this.groupBox11);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Controls.Add(this.groupBox10);
            this.tabPage3.Controls.Add(this.groupBox9);
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(972, 599);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Orders management";
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.comboBox9);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Controls.Add(this.label30);
            this.groupBox11.Controls.Add(this.button15);
            this.groupBox11.Location = new System.Drawing.Point(562, 112);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(199, 100);
            this.groupBox11.TabIndex = 14;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Order true -> waiting for removal";
            // 
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(65, 31);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(114, 21);
            this.comboBox9.TabIndex = 14;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(19, 34);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(42, 13);
            this.label29.TabIndex = 8;
            this.label29.Text = "OrderId";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(22, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 13);
            this.label30.TabIndex = 8;
            this.label30.Text = "Output";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(84, 64);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(95, 21);
            this.button15.TabIndex = 0;
            this.button15.Text = "Confirm";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.Location = new System.Drawing.Point(880, 561);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 13;
            this.button14.Text = "Refresh";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.comboBox7);
            this.groupBox10.Controls.Add(this.label25);
            this.groupBox10.Controls.Add(this.label26);
            this.groupBox10.Controls.Add(this.button13);
            this.groupBox10.Location = new System.Drawing.Point(767, 112);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(199, 100);
            this.groupBox10.TabIndex = 12;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Close an order";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(66, 33);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(114, 21);
            this.comboBox7.TabIndex = 14;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(20, 36);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 13);
            this.label25.TabIndex = 8;
            this.label25.Text = "OrderId";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(23, 70);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(39, 13);
            this.label26.TabIndex = 8;
            this.label26.Text = "Output";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(85, 66);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(95, 21);
            this.button13.TabIndex = 0;
            this.button13.Text = "Confirm";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.comboBox8);
            this.groupBox9.Controls.Add(this.label23);
            this.groupBox9.Controls.Add(this.label24);
            this.groupBox9.Controls.Add(this.button12);
            this.groupBox9.Location = new System.Drawing.Point(562, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(199, 100);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Delete an order";
            // 
            // comboBox8
            // 
            this.comboBox8.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(66, 31);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(114, 21);
            this.comboBox8.TabIndex = 14;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 13);
            this.label23.TabIndex = 8;
            this.label23.Text = "OrderId";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(23, 68);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 8;
            this.label24.Text = "Output";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(85, 64);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(95, 21);
            this.button12.TabIndex = 0;
            this.button12.Text = "Delete";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.comboBox6);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Controls.Add(this.button9);
            this.groupBox8.Location = new System.Drawing.Point(767, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(199, 100);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Confirm a pending order";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(66, 33);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(114, 21);
            this.comboBox6.TabIndex = 14;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(20, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "OrderId";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(23, 70);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 13);
            this.label21.TabIndex = 8;
            this.label21.Text = "Output";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(85, 66);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(95, 21);
            this.button9.TabIndex = 0;
            this.button9.Text = "Confirm";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.comboBox5);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.button10);
            this.groupBox7.Location = new System.Drawing.Point(282, 218);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(267, 79);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Find orders and components";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(131, 18);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(114, 21);
            this.comboBox5.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(35, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Customer\'s  name";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 56);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 8;
            this.label19.Text = "Output";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(150, 48);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(95, 21);
            this.button10.TabIndex = 0;
            this.button10.Text = "Find";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBox4);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.button11);
            this.groupBox6.Location = new System.Drawing.Point(6, 218);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(267, 79);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Show list of items and test availability";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(131, 18);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(114, 21);
            this.comboBox4.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(83, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "OrderId";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Output";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(150, 48);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(95, 21);
            this.button11.TabIndex = 0;
            this.button11.Text = "Test";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.dataGridView3.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 303);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(543, 290);
            this.dataGridView3.TabIndex = 3;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(543, 206);
            this.dataGridView2.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(972, 599);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database management";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(698, 308);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 285);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add a row";
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(66, 55);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(78, 21);
            this.button7.TabIndex = 13;
            this.button7.Text = "Cancel";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(24, 82);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(220, 149);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(150, 55);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(95, 21);
            this.button6.TabIndex = 9;
            this.button6.Text = "Add element";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(119, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ref (String)";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar1.ForeColor = System.Drawing.Color.Gold;
            this.progressBar1.Location = new System.Drawing.Point(24, 237);
            this.progressBar1.MarqueeAnimationSpeed = 160;
            this.progressBar1.Maximum = 160;
            this.progressBar1.Minimum = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(221, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Value = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 262);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Output";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(131, 19);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(114, 20);
            this.textBox4.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(150, 258);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 21);
            this.button3.TabIndex = 0;
            this.button3.Text = "Add the row";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.textBox10);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(698, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(267, 76);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search an element";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(130, 19);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(114, 20);
            this.textBox10.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(49, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 21);
            this.button4.TabIndex = 9;
            this.button4.Text = "Stop search";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(150, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 21);
            this.button5.TabIndex = 8;
            this.button5.Text = "Search";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(83, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Search";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBox10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(698, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 79);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete a row";
            // 
            // comboBox10
            // 
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(131, 19);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(114, 21);
            this.comboBox10.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Output";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 21);
            this.button2.TabIndex = 0;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox12);
            this.groupBox1.Controls.Add(this.comboBox11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(698, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 129);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modify an element";
            // 
            // comboBox12
            // 
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.Location = new System.Drawing.Point(131, 19);
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(114, 21);
            this.comboBox12.TabIndex = 16;
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(131, 45);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(114, 21);
            this.comboBox11.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Column";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(131, 71);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(114, 20);
            this.textBox3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Modify";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(680, 587);
            this.dataGridView1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 625);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(972, 599);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Welcome page";
            this.tabPage2.ToolTipText = "ninja";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.label27.Location = new System.Drawing.Point(105, 280);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(752, 109);
            this.label27.TabIndex = 1;
            this.label27.Text = "Welcome";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label28.Location = new System.Drawing.Point(110, 350);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(752, 109);
            this.label28.TabIndex = 2;
            this.label28.Text = "label28";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label28.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label13.Location = new System.Drawing.Point(105, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(752, 109);
            this.label13.TabIndex = 0;
            this.label13.Text = "label13";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Visible = false;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.tabPage7.Controls.Add(this.dataGridView12);
            this.tabPage7.Controls.Add(this.groupBox23);
            this.tabPage7.Controls.Add(this.dataGridView11);
            this.tabPage7.Controls.Add(this.groupBox20);
            this.tabPage7.Controls.Add(this.groupBox22);
            this.tabPage7.Controls.Add(this.groupBox21);
            this.tabPage7.Controls.Add(this.dataGridView6);
            this.tabPage7.Location = new System.Drawing.Point(4, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(972, 599);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Order visualisation";
            // 
            // dataGridView12
            // 
            this.dataGridView12.AllowUserToAddRows = false;
            this.dataGridView12.AllowUserToResizeColumns = false;
            this.dataGridView12.AllowUserToResizeRows = false;
            this.dataGridView12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView12.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView12.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.dataGridView12.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView12.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView12.Location = new System.Drawing.Point(477, 195);
            this.dataGridView12.Name = "dataGridView12";
            this.dataGridView12.ReadOnly = true;
            this.dataGridView12.Size = new System.Drawing.Size(489, 398);
            this.dataGridView12.TabIndex = 28;
            this.dataGridView12.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView12_CellDoubleClick);
            // 
            // groupBox23
            // 
            this.groupBox23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox23.Controls.Add(this.comboBox31);
            this.groupBox23.Controls.Add(this.comboBox30);
            this.groupBox23.Controls.Add(this.comboBox33);
            this.groupBox23.Controls.Add(this.label65);
            this.groupBox23.Controls.Add(this.comboBox32);
            this.groupBox23.Controls.Add(this.label64);
            this.groupBox23.Controls.Add(this.label63);
            this.groupBox23.Controls.Add(this.label59);
            this.groupBox23.Controls.Add(this.label60);
            this.groupBox23.Controls.Add(this.comboBox28);
            this.groupBox23.Controls.Add(this.comboBox29);
            this.groupBox23.Controls.Add(this.label61);
            this.groupBox23.Controls.Add(this.label62);
            this.groupBox23.Controls.Add(this.button28);
            this.groupBox23.Location = new System.Drawing.Point(6, 396);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(465, 197);
            this.groupBox23.TabIndex = 27;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Modify an element";
            // 
            // comboBox31
            // 
            this.comboBox31.FormattingEnabled = true;
            this.comboBox31.Location = new System.Drawing.Point(324, 39);
            this.comboBox31.Name = "comboBox31";
            this.comboBox31.Size = new System.Drawing.Size(114, 21);
            this.comboBox31.TabIndex = 27;
            // 
            // comboBox30
            // 
            this.comboBox30.FormattingEnabled = true;
            this.comboBox30.Location = new System.Drawing.Point(121, 39);
            this.comboBox30.Name = "comboBox30";
            this.comboBox30.Size = new System.Drawing.Size(114, 21);
            this.comboBox30.TabIndex = 26;
            // 
            // comboBox33
            // 
            this.comboBox33.FormattingEnabled = true;
            this.comboBox33.Location = new System.Drawing.Point(120, 110);
            this.comboBox33.Name = "comboBox33";
            this.comboBox33.Size = new System.Drawing.Size(114, 21);
            this.comboBox33.TabIndex = 25;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(29, 113);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(85, 13);
            this.label65.TabIndex = 24;
            this.label65.Text = "Number of doors";
            // 
            // comboBox32
            // 
            this.comboBox32.FormattingEnabled = true;
            this.comboBox32.Items.AddRange(new object[] {
            "Angles",
            "Doors",
            "Panels",
            "Crossbars"});
            this.comboBox32.Location = new System.Drawing.Point(121, 76);
            this.comboBox32.Name = "comboBox32";
            this.comboBox32.Size = new System.Drawing.Size(114, 21);
            this.comboBox32.TabIndex = 23;
            this.comboBox32.SelectionChangeCommitted += new System.EventHandler(this.comboBox32_SelectionChangeCommitted);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(32, 79);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(83, 13);
            this.label64.TabIndex = 22;
            this.label64.Text = "Type of element";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(284, 42);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(34, 13);
            this.label63.TabIndex = 21;
            this.label63.Text = "BoxId";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(284, 113);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(31, 13);
            this.label59.TabIndex = 19;
            this.label59.Text = "Color";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(264, 79);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(54, 13);
            this.label60.TabIndex = 18;
            this.label60.Text = "ElementId";
            // 
            // comboBox28
            // 
            this.comboBox28.FormattingEnabled = true;
            this.comboBox28.Location = new System.Drawing.Point(324, 110);
            this.comboBox28.Name = "comboBox28";
            this.comboBox28.Size = new System.Drawing.Size(114, 21);
            this.comboBox28.TabIndex = 17;
            // 
            // comboBox29
            // 
            this.comboBox29.FormattingEnabled = true;
            this.comboBox29.Location = new System.Drawing.Point(324, 76);
            this.comboBox29.Name = "comboBox29";
            this.comboBox29.Size = new System.Drawing.Size(114, 21);
            this.comboBox29.TabIndex = 16;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(18, 160);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(39, 13);
            this.label61.TabIndex = 7;
            this.label61.Text = "Output";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(52, 42);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(62, 13);
            this.label62.TabIndex = 5;
            this.label62.Text = "CupboardId";
            // 
            // button28
            // 
            this.button28.Enabled = false;
            this.button28.Location = new System.Drawing.Point(343, 152);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(95, 21);
            this.button28.TabIndex = 0;
            this.button28.Text = "Modify";
            this.button28.UseVisualStyleBackColor = true;
            // 
            // dataGridView11
            // 
            this.dataGridView11.AllowUserToAddRows = false;
            this.dataGridView11.AllowUserToResizeColumns = false;
            this.dataGridView11.AllowUserToResizeRows = false;
            this.dataGridView11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView11.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView11.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.dataGridView11.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView11.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView11.Location = new System.Drawing.Point(6, 198);
            this.dataGridView11.Name = "dataGridView11";
            this.dataGridView11.ReadOnly = true;
            this.dataGridView11.Size = new System.Drawing.Size(248, 192);
            this.dataGridView11.TabIndex = 26;
            this.dataGridView11.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView11_CellClick);
            // 
            // groupBox20
            // 
            this.groupBox20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox20.Controls.Add(this.comboBox27);
            this.groupBox20.Controls.Add(this.comboBox26);
            this.groupBox20.Controls.Add(this.label55);
            this.groupBox20.Controls.Add(this.label56);
            this.groupBox20.Controls.Add(this.comboBox25);
            this.groupBox20.Controls.Add(this.label57);
            this.groupBox20.Controls.Add(this.label58);
            this.groupBox20.Controls.Add(this.button25);
            this.groupBox20.Location = new System.Drawing.Point(260, 198);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(211, 192);
            this.groupBox20.TabIndex = 25;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Modify a box";
            this.groupBox20.Enter += new System.EventHandler(this.groupBox20_Enter);
            // 
            // comboBox27
            // 
            this.comboBox27.FormattingEnabled = true;
            this.comboBox27.Location = new System.Drawing.Point(77, 65);
            this.comboBox27.Name = "comboBox27";
            this.comboBox27.Size = new System.Drawing.Size(114, 21);
            this.comboBox27.TabIndex = 22;
            // 
            // comboBox26
            // 
            this.comboBox26.FormattingEnabled = true;
            this.comboBox26.Location = new System.Drawing.Point(77, 28);
            this.comboBox26.Name = "comboBox26";
            this.comboBox26.Size = new System.Drawing.Size(114, 21);
            this.comboBox26.TabIndex = 21;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(33, 108);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(38, 13);
            this.label55.TabIndex = 19;
            this.label55.Text = "Height";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(37, 68);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(34, 13);
            this.label56.TabIndex = 18;
            this.label56.Text = "BoxId";
            // 
            // comboBox25
            // 
            this.comboBox25.FormattingEnabled = true;
            this.comboBox25.Location = new System.Drawing.Point(77, 105);
            this.comboBox25.Name = "comboBox25";
            this.comboBox25.Size = new System.Drawing.Size(114, 21);
            this.comboBox25.TabIndex = 17;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(8, 152);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(39, 13);
            this.label57.TabIndex = 7;
            this.label57.Text = "Output";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(9, 31);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(62, 13);
            this.label58.TabIndex = 5;
            this.label58.Text = "CupboardId";
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(96, 148);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(95, 21);
            this.button25.TabIndex = 0;
            this.button25.Text = "Modify";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox22.Controls.Add(this.comboBox20);
            this.groupBox22.Controls.Add(this.label49);
            this.groupBox22.Controls.Add(this.label48);
            this.groupBox22.Controls.Add(this.comboBox24);
            this.groupBox22.Controls.Add(this.comboBox23);
            this.groupBox22.Controls.Add(this.label53);
            this.groupBox22.Controls.Add(this.label54);
            this.groupBox22.Controls.Add(this.button27);
            this.groupBox22.Location = new System.Drawing.Point(425, 6);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(267, 183);
            this.groupBox22.TabIndex = 24;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Modify a cupboard";
            // 
            // comboBox20
            // 
            this.comboBox20.FormattingEnabled = true;
            this.comboBox20.Location = new System.Drawing.Point(131, 28);
            this.comboBox20.Name = "comboBox20";
            this.comboBox20.Size = new System.Drawing.Size(114, 21);
            this.comboBox20.TabIndex = 20;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(91, 108);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(34, 13);
            this.label49.TabIndex = 19;
            this.label49.Text = "Value";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(83, 68);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(42, 13);
            this.label48.TabIndex = 18;
            this.label48.Text = "Column";
            // 
            // comboBox24
            // 
            this.comboBox24.FormattingEnabled = true;
            this.comboBox24.Location = new System.Drawing.Point(131, 105);
            this.comboBox24.Name = "comboBox24";
            this.comboBox24.Size = new System.Drawing.Size(114, 21);
            this.comboBox24.TabIndex = 17;
            // 
            // comboBox23
            // 
            this.comboBox23.FormattingEnabled = true;
            this.comboBox23.Items.AddRange(new object[] {
            "Width",
            "Depth"});
            this.comboBox23.Location = new System.Drawing.Point(131, 65);
            this.comboBox23.Name = "comboBox23";
            this.comboBox23.Size = new System.Drawing.Size(114, 21);
            this.comboBox23.TabIndex = 16;
            this.comboBox23.Text = "Width";
            this.comboBox23.SelectionChangeCommitted += new System.EventHandler(this.comboBox23_SelectionChangeCommitted);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(35, 149);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(39, 13);
            this.label53.TabIndex = 7;
            this.label53.Text = "Output";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(63, 31);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(62, 13);
            this.label54.TabIndex = 5;
            this.label54.Text = "CupboardId";
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(150, 145);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(95, 21);
            this.button27.TabIndex = 0;
            this.button27.Text = "Modify";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox21.Controls.Add(this.comboBox21);
            this.groupBox21.Controls.Add(this.label32);
            this.groupBox21.Controls.Add(this.comboBox22);
            this.groupBox21.Controls.Add(this.label51);
            this.groupBox21.Controls.Add(this.label52);
            this.groupBox21.Controls.Add(this.button26);
            this.groupBox21.Location = new System.Drawing.Point(699, 6);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(267, 183);
            this.groupBox21.TabIndex = 21;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Find order";
            // 
            // comboBox21
            // 
            this.comboBox21.FormattingEnabled = true;
            this.comboBox21.Location = new System.Drawing.Point(131, 28);
            this.comboBox21.Name = "comboBox21";
            this.comboBox21.Size = new System.Drawing.Size(114, 21);
            this.comboBox21.TabIndex = 16;
            this.comboBox21.SelectionChangeCommitted += new System.EventHandler(this.comboBox21_SelectionChangeCommitted);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(83, 67);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(42, 13);
            this.label32.TabIndex = 15;
            this.label32.Text = "OrderId";
            // 
            // comboBox22
            // 
            this.comboBox22.FormattingEnabled = true;
            this.comboBox22.Location = new System.Drawing.Point(131, 64);
            this.comboBox22.Name = "comboBox22";
            this.comboBox22.Size = new System.Drawing.Size(114, 21);
            this.comboBox22.TabIndex = 14;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(35, 29);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(90, 13);
            this.label51.TabIndex = 8;
            this.label51.Text = "Customer\'s  name";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(30, 141);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(39, 13);
            this.label52.TabIndex = 8;
            this.label52.Text = "Output";
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(150, 141);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(95, 21);
            this.button26.TabIndex = 0;
            this.button26.Text = "Find";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.AllowUserToResizeColumns = false;
            this.dataGridView6.AllowUserToResizeRows = false;
            this.dataGridView6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.dataGridView6.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Location = new System.Drawing.Point(6, 6);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.Size = new System.Drawing.Size(413, 186);
            this.dataGridView6.TabIndex = 20;
            this.dataGridView6.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView6_CellClick);
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.tabPage5.Controls.Add(this.dataGridView8);
            this.tabPage5.Controls.Add(this.dataGridView7);
            this.tabPage5.Controls.Add(this.groupBox15);
            this.tabPage5.Controls.Add(this.groupBox14);
            this.tabPage5.Controls.Add(this.groupBox13);
            this.tabPage5.Controls.Add(this.groupBox12);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(972, 599);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Suppliers orders";
            // 
            // dataGridView8
            // 
            this.dataGridView8.AllowUserToAddRows = false;
            this.dataGridView8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView8.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView8.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Location = new System.Drawing.Point(6, 375);
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.Size = new System.Drawing.Size(520, 218);
            this.dataGridView8.TabIndex = 18;
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView7.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Location = new System.Drawing.Point(6, 8);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.Size = new System.Drawing.Size(520, 226);
            this.dataGridView7.TabIndex = 3;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.comboBox16);
            this.groupBox15.Controls.Add(this.label35);
            this.groupBox15.Controls.Add(this.label36);
            this.groupBox15.Controls.Add(this.label37);
            this.groupBox15.Controls.Add(this.textBox2);
            this.groupBox15.Controls.Add(this.button20);
            this.groupBox15.Location = new System.Drawing.Point(268, 240);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(258, 129);
            this.groupBox15.TabIndex = 17;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Add an item";
            // 
            // comboBox16
            // 
            this.comboBox16.FormattingEnabled = true;
            this.comboBox16.Location = new System.Drawing.Point(108, 28);
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(114, 21);
            this.comboBox16.TabIndex = 15;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(21, 106);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(39, 13);
            this.label35.TabIndex = 7;
            this.label35.Text = "Output";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(56, 66);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(46, 13);
            this.label36.TabIndex = 6;
            this.label36.Text = "Quantity";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(70, 31);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(32, 13);
            this.label37.TabIndex = 5;
            this.label37.Text = "Code";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 20);
            this.textBox2.TabIndex = 3;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(127, 98);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(95, 21);
            this.button20.TabIndex = 0;
            this.button20.Text = "Add";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.comboBox14);
            this.groupBox14.Controls.Add(this.label31);
            this.groupBox14.Controls.Add(this.label33);
            this.groupBox14.Controls.Add(this.button19);
            this.groupBox14.Location = new System.Drawing.Point(6, 240);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(256, 129);
            this.groupBox14.TabIndex = 4;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Show an order";
            // 
            // comboBox14
            // 
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.Location = new System.Drawing.Point(113, 45);
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(114, 21);
            this.comboBox14.TabIndex = 15;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(21, 106);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(39, 13);
            this.label31.TabIndex = 7;
            this.label31.Text = "Output";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(75, 48);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 13);
            this.label33.TabIndex = 5;
            this.label33.Text = "Code";
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(132, 82);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(95, 21);
            this.button19.TabIndex = 0;
            this.button19.Text = "Modify";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.label34);
            this.groupBox13.Controls.Add(this.button18);
            this.groupBox13.Controls.Add(this.dataGridView5);
            this.groupBox13.Location = new System.Drawing.Point(532, 118);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(433, 475);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Supplier order";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 440);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(61, 13);
            this.label34.TabIndex = 9;
            this.label34.Text = "Amount: 0€";
            // 
            // button18
            // 
            this.button18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button18.Location = new System.Drawing.Point(298, 431);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(103, 22);
            this.button18.TabIndex = 3;
            this.button18.Text = "Order";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView5.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Location = new System.Drawing.Point(6, 19);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(421, 406);
            this.dataGridView5.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox12.Controls.Add(this.button17);
            this.groupBox12.Controls.Add(this.comboBox18);
            this.groupBox12.Location = new System.Drawing.Point(532, 8);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(433, 104);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Supplier choice";
            // 
            // button17
            // 
            this.button17.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button17.Location = new System.Drawing.Point(181, 58);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 1;
            this.button17.Text = "Confirm";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // comboBox18
            // 
            this.comboBox18.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.comboBox18.FormattingEnabled = true;
            this.comboBox18.Location = new System.Drawing.Point(161, 19);
            this.comboBox18.Name = "comboBox18";
            this.comboBox18.Size = new System.Drawing.Size(121, 21);
            this.comboBox18.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.tabPage6.Controls.Add(this.groupBox19);
            this.tabPage6.Controls.Add(this.groupBox18);
            this.tabPage6.Controls.Add(this.groupBox17);
            this.tabPage6.Controls.Add(this.groupBox16);
            this.tabPage6.Controls.Add(this.dataGridView10);
            this.tabPage6.Controls.Add(this.dataGridView9);
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(972, 599);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Suppliers update";
            // 
            // groupBox19
            // 
            this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox19.Controls.Add(this.progressBar3);
            this.groupBox19.Controls.Add(this.label47);
            this.groupBox19.Controls.Add(this.button24);
            this.groupBox19.Location = new System.Drawing.Point(708, 141);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(258, 99);
            this.groupBox19.TabIndex = 21;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Update prices";
            // 
            // progressBar3
            // 
            this.progressBar3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.progressBar3.ForeColor = System.Drawing.Color.Gold;
            this.progressBar3.Location = new System.Drawing.Point(130, 78);
            this.progressBar3.MarqueeAnimationSpeed = 160;
            this.progressBar3.Maximum = 160;
            this.progressBar3.Minimum = 10;
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(95, 15);
            this.progressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar3.TabIndex = 11;
            this.progressBar3.Value = 10;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(24, 83);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(39, 13);
            this.label47.TabIndex = 7;
            this.label47.Text = "Output";
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(130, 27);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(95, 21);
            this.button24.TabIndex = 0;
            this.button24.Text = "Update";
            this.button24.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.label50);
            this.groupBox18.Controls.Add(this.comboBox19);
            this.groupBox18.Controls.Add(this.label42);
            this.groupBox18.Controls.Add(this.comboBox17);
            this.groupBox18.Controls.Add(this.label44);
            this.groupBox18.Controls.Add(this.label45);
            this.groupBox18.Controls.Add(this.label46);
            this.groupBox18.Controls.Add(this.textBox6);
            this.groupBox18.Controls.Add(this.button23);
            this.groupBox18.Location = new System.Drawing.Point(444, 141);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(258, 177);
            this.groupBox18.TabIndex = 20;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Modify an item";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(60, 65);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(42, 13);
            this.label50.TabIndex = 24;
            this.label50.Text = "Column";
            // 
            // comboBox19
            // 
            this.comboBox19.FormattingEnabled = true;
            this.comboBox19.Location = new System.Drawing.Point(108, 62);
            this.comboBox19.Name = "comboBox19";
            this.comboBox19.Size = new System.Drawing.Size(114, 21);
            this.comboBox19.TabIndex = 23;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(10, 22);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(32, 13);
            this.label42.TabIndex = 22;
            this.label42.Text = "Code";
            // 
            // comboBox17
            // 
            this.comboBox17.FormattingEnabled = true;
            this.comboBox17.Location = new System.Drawing.Point(108, 28);
            this.comboBox17.Name = "comboBox17";
            this.comboBox17.Size = new System.Drawing.Size(114, 21);
            this.comboBox17.TabIndex = 15;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(21, 143);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(39, 13);
            this.label44.TabIndex = 7;
            this.label44.Text = "Output";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(70, 102);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(34, 13);
            this.label45.TabIndex = 6;
            this.label45.Text = "Value";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(70, 31);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(32, 13);
            this.label46.TabIndex = 5;
            this.label46.Text = "Code";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(108, 99);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(114, 20);
            this.textBox6.TabIndex = 3;
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(127, 139);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(95, 21);
            this.button23.TabIndex = 0;
            this.button23.Text = "Modify";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.comboBox15);
            this.groupBox17.Controls.Add(this.label38);
            this.groupBox17.Controls.Add(this.label43);
            this.groupBox17.Controls.Add(this.button22);
            this.groupBox17.Location = new System.Drawing.Point(708, 6);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(258, 129);
            this.groupBox17.TabIndex = 19;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Delete an item";
            // 
            // comboBox15
            // 
            this.comboBox15.FormattingEnabled = true;
            this.comboBox15.Location = new System.Drawing.Point(108, 28);
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(114, 21);
            this.comboBox15.TabIndex = 15;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(21, 106);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(39, 13);
            this.label38.TabIndex = 7;
            this.label38.Text = "Output";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(70, 31);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(32, 13);
            this.label43.TabIndex = 5;
            this.label43.Text = "Code";
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(127, 98);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(95, 21);
            this.button22.TabIndex = 0;
            this.button22.Text = "Delete";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox16.Controls.Add(this.comboBox13);
            this.groupBox16.Controls.Add(this.label39);
            this.groupBox16.Controls.Add(this.label40);
            this.groupBox16.Controls.Add(this.label41);
            this.groupBox16.Controls.Add(this.textBox1);
            this.groupBox16.Controls.Add(this.button21);
            this.groupBox16.Location = new System.Drawing.Point(444, 6);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(258, 129);
            this.groupBox16.TabIndex = 18;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Add an item";
            // 
            // comboBox13
            // 
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.Location = new System.Drawing.Point(108, 28);
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(114, 21);
            this.comboBox13.TabIndex = 15;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(21, 106);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(39, 13);
            this.label39.TabIndex = 7;
            this.label39.Text = "Output";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(56, 66);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(46, 13);
            this.label40.TabIndex = 6;
            this.label40.Text = "Quantity";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(70, 31);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(32, 13);
            this.label41.TabIndex = 5;
            this.label41.Text = "Code";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 3;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(127, 98);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(95, 21);
            this.button21.TabIndex = 0;
            this.button21.Text = "Add";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // dataGridView10
            // 
            this.dataGridView10.AllowUserToAddRows = false;
            this.dataGridView10.AllowUserToResizeColumns = false;
            this.dataGridView10.AllowUserToResizeRows = false;
            this.dataGridView10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView10.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.dataGridView10.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView10.Location = new System.Drawing.Point(6, 6);
            this.dataGridView10.Name = "dataGridView10";
            this.dataGridView10.ReadOnly = true;
            this.dataGridView10.Size = new System.Drawing.Size(432, 587);
            this.dataGridView10.TabIndex = 16;
            // 
            // dataGridView9
            // 
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView9.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView9.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.dataGridView9.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView9.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView9.Location = new System.Drawing.Point(444, 326);
            this.dataGridView9.Name = "dataGridView9";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridView9.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView9.Size = new System.Drawing.Size(522, 267);
            this.dataGridView9.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(981, 626);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitbox";
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView12)).EndInit();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView11)).EndInit();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CustomInstaller customInstaller1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.DataGridView dataGridView3;
        public System.Windows.Forms.DataGridView dataGridView2;
        public System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.ComboBox comboBox12;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView dataGridView8;
        private System.Windows.Forms.DataGridView dataGridView7;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.ComboBox comboBox16;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridView9;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.ComboBox comboBox17;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.ComboBox comboBox15;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.ComboBox comboBox13;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button21;
        public System.Windows.Forms.DataGridView dataGridView10;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.ComboBox comboBox19;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.ComboBox comboBox18;
        private System.Windows.Forms.TabPage tabPage7;
        public System.Windows.Forms.DataGridView dataGridView6;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.ComboBox comboBox22;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.ComboBox comboBox23;
        private System.Windows.Forms.ComboBox comboBox21;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox comboBox24;
        public System.Windows.Forms.DataGridView dataGridView11;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox comboBox25;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button25;
        public System.Windows.Forms.DataGridView dataGridView12;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.ComboBox comboBox33;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.ComboBox comboBox32;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.ComboBox comboBox28;
        private System.Windows.Forms.ComboBox comboBox29;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.ComboBox comboBox31;
        private System.Windows.Forms.ComboBox comboBox30;
        private System.Windows.Forms.ComboBox comboBox27;
        private System.Windows.Forms.ComboBox comboBox26;
        private System.Windows.Forms.ComboBox comboBox20;
    }
}
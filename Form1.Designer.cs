namespace Meter
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ConnectStateLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.訊號狀態 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.connect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DO1OFF = new System.Windows.Forms.RadioButton();
            this.DO1ON = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DO0OFF = new System.Windows.Forms.RadioButton();
            this.DO0ON = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SystemTimeLabel = new System.Windows.Forms.Label();
            this.資料查詢 = new System.Windows.Forms.TabPage();
            this.SERCH = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.datasearch = new System.Windows.Forms.Button();
            this.ENDlabel = new System.Windows.Forms.Label();
            this.hourlabel2 = new System.Windows.Forms.Label();
            this.hourcomboBox2 = new System.Windows.Forms.ComboBox();
            this.daycomboBox2 = new System.Windows.Forms.ComboBox();
            this.daylabel2 = new System.Windows.Forms.Label();
            this.monthlabel2 = new System.Windows.Forms.Label();
            this.yearlabel2 = new System.Windows.Forms.Label();
            this.monthcomboBox2 = new System.Windows.Forms.ComboBox();
            this.yearcomboBox2 = new System.Windows.Forms.ComboBox();
            this.hourlabel1 = new System.Windows.Forms.Label();
            this.hourcomboBox1 = new System.Windows.Forms.ComboBox();
            this.daycomboBox1 = new System.Windows.Forms.ComboBox();
            this.daylabel1 = new System.Windows.Forms.Label();
            this.monthlabel1 = new System.Windows.Forms.Label();
            this.yearlabel1 = new System.Windows.Forms.Label();
            this.startlabel = new System.Windows.Forms.Label();
            this.monthcomboBox1 = new System.Windows.Forms.ComboBox();
            this.yearcomboBox1 = new System.Windows.Forms.ComboBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.disconnect = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.訊號狀態.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.資料查詢.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectStateLabel
            // 
            this.ConnectStateLabel.AutoSize = true;
            this.ConnectStateLabel.Location = new System.Drawing.Point(688, 445);
            this.ConnectStateLabel.Name = "ConnectStateLabel";
            this.ConnectStateLabel.Size = new System.Drawing.Size(72, 16);
            this.ConnectStateLabel.TabIndex = 42;
            this.ConnectStateLabel.Text = "連接狀態";
            this.ConnectStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.訊號狀態);
            this.tabControl1.Controls.Add(this.資料查詢);
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(30, 20);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1366, 602);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 51;
            // 
            // 訊號狀態
            // 
            this.訊號狀態.BackColor = System.Drawing.Color.PowderBlue;
            this.訊號狀態.Controls.Add(this.disconnect);
            this.訊號狀態.Controls.Add(this.groupBox4);
            this.訊號狀態.Controls.Add(this.groupBox3);
            this.訊號狀態.Controls.Add(this.connect);
            this.訊號狀態.Controls.Add(this.groupBox2);
            this.訊號狀態.Controls.Add(this.groupBox1);
            this.訊號狀態.Controls.Add(this.ConnectStateLabel);
            this.訊號狀態.Controls.Add(this.SystemTimeLabel);
            this.訊號狀態.Location = new System.Drawing.Point(4, 60);
            this.訊號狀態.Name = "訊號狀態";
            this.訊號狀態.Padding = new System.Windows.Forms.Padding(3);
            this.訊號狀態.Size = new System.Drawing.Size(1358, 538);
            this.訊號狀態.TabIndex = 0;
            this.訊號狀態.Text = "訊號狀態";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Location = new System.Drawing.Point(691, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 100);
            this.groupBox4.TabIndex = 62;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "感測器TCP/IP設定";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 16);
            this.label10.TabIndex = 66;
            this.label10.Text = "Port:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(59, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(127, 27);
            this.textBox2.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 16);
            this.label9.TabIndex = 64;
            this.label9.Text = "IP:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 27);
            this.textBox1.TabIndex = 63;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(36, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 136);
            this.groupBox3.TabIndex = 61;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AI訊號";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 67;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 66;
            this.label7.Text = "AI3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 65;
            this.label5.Text = "AI2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 64;
            this.label6.Text = "label6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 63;
            this.label4.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 62;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "AI1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 60;
            this.label1.Text = "AI0";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(37, 292);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(99, 39);
            this.connect.TabIndex = 60;
            this.connect.Text = "開始連線";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DO1OFF);
            this.groupBox2.Controls.Add(this.DO1ON);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(182, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(116, 119);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DO1";
            // 
            // DO1OFF
            // 
            this.DO1OFF.AutoSize = true;
            this.DO1OFF.Location = new System.Drawing.Point(6, 52);
            this.DO1OFF.Name = "DO1OFF";
            this.DO1OFF.Size = new System.Drawing.Size(53, 20);
            this.DO1OFF.TabIndex = 50;
            this.DO1OFF.TabStop = true;
            this.DO1OFF.Text = "OFF";
            this.DO1OFF.UseVisualStyleBackColor = true;
            // 
            // DO1ON
            // 
            this.DO1ON.AutoSize = true;
            this.DO1ON.Location = new System.Drawing.Point(6, 26);
            this.DO1ON.Name = "DO1ON";
            this.DO1ON.Size = new System.Drawing.Size(48, 20);
            this.DO1ON.TabIndex = 49;
            this.DO1ON.TabStop = true;
            this.DO1ON.Text = "ON";
            this.DO1ON.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 46;
            this.button2.Text = "變更";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DO0OFF);
            this.groupBox1.Controls.Add(this.DO0ON);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(37, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 119);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DO0";
            // 
            // DO0OFF
            // 
            this.DO0OFF.AutoSize = true;
            this.DO0OFF.Location = new System.Drawing.Point(6, 52);
            this.DO0OFF.Name = "DO0OFF";
            this.DO0OFF.Size = new System.Drawing.Size(53, 20);
            this.DO0OFF.TabIndex = 50;
            this.DO0OFF.TabStop = true;
            this.DO0OFF.Text = "OFF";
            this.DO0OFF.UseVisualStyleBackColor = true;
            // 
            // DO0ON
            // 
            this.DO0ON.AutoSize = true;
            this.DO0ON.Location = new System.Drawing.Point(6, 26);
            this.DO0ON.Name = "DO0ON";
            this.DO0ON.Size = new System.Drawing.Size(48, 20);
            this.DO0ON.TabIndex = 49;
            this.DO0ON.TabStop = true;
            this.DO0ON.Text = "ON";
            this.DO0ON.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 46;
            this.button1.Text = "變更";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SystemTimeLabel
            // 
            this.SystemTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SystemTimeLabel.Location = new System.Drawing.Point(763, 442);
            this.SystemTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SystemTimeLabel.Name = "SystemTimeLabel";
            this.SystemTimeLabel.Size = new System.Drawing.Size(174, 20);
            this.SystemTimeLabel.TabIndex = 37;
            this.SystemTimeLabel.Text = "0000/00/00 00:00:00";
            this.SystemTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 資料查詢
            // 
            this.資料查詢.BackColor = System.Drawing.Color.PowderBlue;
            this.資料查詢.Controls.Add(this.SERCH);
            this.資料查詢.Controls.Add(this.checkedListBox1);
            this.資料查詢.Controls.Add(this.dataGridView1);
            this.資料查詢.Controls.Add(this.datasearch);
            this.資料查詢.Controls.Add(this.ENDlabel);
            this.資料查詢.Controls.Add(this.hourlabel2);
            this.資料查詢.Controls.Add(this.hourcomboBox2);
            this.資料查詢.Controls.Add(this.daycomboBox2);
            this.資料查詢.Controls.Add(this.daylabel2);
            this.資料查詢.Controls.Add(this.monthlabel2);
            this.資料查詢.Controls.Add(this.yearlabel2);
            this.資料查詢.Controls.Add(this.monthcomboBox2);
            this.資料查詢.Controls.Add(this.yearcomboBox2);
            this.資料查詢.Controls.Add(this.hourlabel1);
            this.資料查詢.Controls.Add(this.hourcomboBox1);
            this.資料查詢.Controls.Add(this.daycomboBox1);
            this.資料查詢.Controls.Add(this.daylabel1);
            this.資料查詢.Controls.Add(this.monthlabel1);
            this.資料查詢.Controls.Add(this.yearlabel1);
            this.資料查詢.Controls.Add(this.startlabel);
            this.資料查詢.Controls.Add(this.monthcomboBox1);
            this.資料查詢.Controls.Add(this.yearcomboBox1);
            this.資料查詢.Controls.Add(this.zedGraphControl1);
            this.資料查詢.ImageIndex = 7;
            this.資料查詢.Location = new System.Drawing.Point(4, 60);
            this.資料查詢.Name = "資料查詢";
            this.資料查詢.Size = new System.Drawing.Size(1358, 538);
            this.資料查詢.TabIndex = 3;
            this.資料查詢.Text = "資料查詢";
            // 
            // SERCH
            // 
            this.SERCH.AutoSize = true;
            this.SERCH.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SERCH.Location = new System.Drawing.Point(348, 367);
            this.SERCH.Name = "SERCH";
            this.SERCH.Size = new System.Drawing.Size(77, 20);
            this.SERCH.TabIndex = 79;
            this.SERCH.Text = "查詢項目:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(352, 390);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(183, 48);
            this.checkedListBox1.TabIndex = 78;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 294);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(304, 145);
            this.dataGridView1.TabIndex = 77;
            // 
            // datasearch
            // 
            this.datasearch.BackColor = System.Drawing.Color.White;
            this.datasearch.Image = ((System.Drawing.Image)(resources.GetObject("datasearch.Image")));
            this.datasearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.datasearch.Location = new System.Drawing.Point(557, 388);
            this.datasearch.Name = "datasearch";
            this.datasearch.Size = new System.Drawing.Size(106, 50);
            this.datasearch.TabIndex = 73;
            this.datasearch.Text = "查詢";
            this.datasearch.UseVisualStyleBackColor = false;
            this.datasearch.Click += new System.EventHandler(this.datasearch_Click);
            // 
            // ENDlabel
            // 
            this.ENDlabel.AutoSize = true;
            this.ENDlabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ENDlabel.Location = new System.Drawing.Point(348, 335);
            this.ENDlabel.Name = "ENDlabel";
            this.ENDlabel.Size = new System.Drawing.Size(109, 20);
            this.ENDlabel.TabIndex = 72;
            this.ENDlabel.Text = "查詢結束時間:";
            // 
            // hourlabel2
            // 
            this.hourlabel2.AutoSize = true;
            this.hourlabel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.hourlabel2.Location = new System.Drawing.Point(884, 335);
            this.hourlabel2.Name = "hourlabel2";
            this.hourlabel2.Size = new System.Drawing.Size(25, 20);
            this.hourlabel2.TabIndex = 71;
            this.hourlabel2.Text = "時";
            // 
            // hourcomboBox2
            // 
            this.hourcomboBox2.FormattingEnabled = true;
            this.hourcomboBox2.Location = new System.Drawing.Point(810, 336);
            this.hourcomboBox2.Name = "hourcomboBox2";
            this.hourcomboBox2.Size = new System.Drawing.Size(68, 24);
            this.hourcomboBox2.TabIndex = 70;
            // 
            // daycomboBox2
            // 
            this.daycomboBox2.FormattingEnabled = true;
            this.daycomboBox2.Location = new System.Drawing.Point(705, 336);
            this.daycomboBox2.Name = "daycomboBox2";
            this.daycomboBox2.Size = new System.Drawing.Size(68, 24);
            this.daycomboBox2.TabIndex = 69;
            // 
            // daylabel2
            // 
            this.daylabel2.AutoSize = true;
            this.daylabel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.daylabel2.Location = new System.Drawing.Point(779, 336);
            this.daylabel2.Name = "daylabel2";
            this.daylabel2.Size = new System.Drawing.Size(25, 20);
            this.daylabel2.TabIndex = 68;
            this.daylabel2.Text = "日";
            // 
            // monthlabel2
            // 
            this.monthlabel2.AutoSize = true;
            this.monthlabel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monthlabel2.Location = new System.Drawing.Point(674, 336);
            this.monthlabel2.Name = "monthlabel2";
            this.monthlabel2.Size = new System.Drawing.Size(25, 20);
            this.monthlabel2.TabIndex = 67;
            this.monthlabel2.Text = "月";
            // 
            // yearlabel2
            // 
            this.yearlabel2.AutoSize = true;
            this.yearlabel2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yearlabel2.Location = new System.Drawing.Point(580, 336);
            this.yearlabel2.Name = "yearlabel2";
            this.yearlabel2.Size = new System.Drawing.Size(25, 20);
            this.yearlabel2.TabIndex = 66;
            this.yearlabel2.Text = "年";
            // 
            // monthcomboBox2
            // 
            this.monthcomboBox2.FormattingEnabled = true;
            this.monthcomboBox2.Location = new System.Drawing.Point(606, 336);
            this.monthcomboBox2.Name = "monthcomboBox2";
            this.monthcomboBox2.Size = new System.Drawing.Size(57, 24);
            this.monthcomboBox2.TabIndex = 64;
            // 
            // yearcomboBox2
            // 
            this.yearcomboBox2.FormattingEnabled = true;
            this.yearcomboBox2.Location = new System.Drawing.Point(463, 336);
            this.yearcomboBox2.Name = "yearcomboBox2";
            this.yearcomboBox2.Size = new System.Drawing.Size(121, 24);
            this.yearcomboBox2.TabIndex = 63;
            // 
            // hourlabel1
            // 
            this.hourlabel1.AutoSize = true;
            this.hourlabel1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.hourlabel1.Location = new System.Drawing.Point(884, 292);
            this.hourlabel1.Name = "hourlabel1";
            this.hourlabel1.Size = new System.Drawing.Size(25, 20);
            this.hourlabel1.TabIndex = 62;
            this.hourlabel1.Text = "時";
            // 
            // hourcomboBox1
            // 
            this.hourcomboBox1.FormattingEnabled = true;
            this.hourcomboBox1.Location = new System.Drawing.Point(810, 293);
            this.hourcomboBox1.Name = "hourcomboBox1";
            this.hourcomboBox1.Size = new System.Drawing.Size(68, 24);
            this.hourcomboBox1.TabIndex = 61;
            // 
            // daycomboBox1
            // 
            this.daycomboBox1.FormattingEnabled = true;
            this.daycomboBox1.Location = new System.Drawing.Point(705, 293);
            this.daycomboBox1.Name = "daycomboBox1";
            this.daycomboBox1.Size = new System.Drawing.Size(68, 24);
            this.daycomboBox1.TabIndex = 60;
            // 
            // daylabel1
            // 
            this.daylabel1.AutoSize = true;
            this.daylabel1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.daylabel1.Location = new System.Drawing.Point(779, 293);
            this.daylabel1.Name = "daylabel1";
            this.daylabel1.Size = new System.Drawing.Size(25, 20);
            this.daylabel1.TabIndex = 59;
            this.daylabel1.Text = "日";
            // 
            // monthlabel1
            // 
            this.monthlabel1.AutoSize = true;
            this.monthlabel1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.monthlabel1.Location = new System.Drawing.Point(674, 293);
            this.monthlabel1.Name = "monthlabel1";
            this.monthlabel1.Size = new System.Drawing.Size(25, 20);
            this.monthlabel1.TabIndex = 58;
            this.monthlabel1.Text = "月";
            // 
            // yearlabel1
            // 
            this.yearlabel1.AutoSize = true;
            this.yearlabel1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.yearlabel1.Location = new System.Drawing.Point(580, 293);
            this.yearlabel1.Name = "yearlabel1";
            this.yearlabel1.Size = new System.Drawing.Size(25, 20);
            this.yearlabel1.TabIndex = 57;
            this.yearlabel1.Text = "年";
            // 
            // startlabel
            // 
            this.startlabel.AutoSize = true;
            this.startlabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.startlabel.Location = new System.Drawing.Point(348, 293);
            this.startlabel.Name = "startlabel";
            this.startlabel.Size = new System.Drawing.Size(109, 20);
            this.startlabel.TabIndex = 56;
            this.startlabel.Text = "查詢啟始時間:";
            // 
            // monthcomboBox1
            // 
            this.monthcomboBox1.FormattingEnabled = true;
            this.monthcomboBox1.Location = new System.Drawing.Point(606, 293);
            this.monthcomboBox1.Name = "monthcomboBox1";
            this.monthcomboBox1.Size = new System.Drawing.Size(57, 24);
            this.monthcomboBox1.TabIndex = 55;
            // 
            // yearcomboBox1
            // 
            this.yearcomboBox1.FormattingEnabled = true;
            this.yearcomboBox1.Location = new System.Drawing.Point(463, 293);
            this.yearcomboBox1.Name = "yearcomboBox1";
            this.yearcomboBox1.Size = new System.Drawing.Size(121, 24);
            this.yearcomboBox1.TabIndex = 54;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(36, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(871, 267);
            this.zedGraphControl1.TabIndex = 52;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(590, 437);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(92, 33);
            this.disconnect.TabIndex = 63;
            this.disconnect.Text = "結束連線";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 532);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.訊號狀態.ResumeLayout(false);
            this.訊號狀態.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.資料查詢.ResumeLayout(false);
            this.資料查詢.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ConnectStateLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 訊號狀態;
        private System.Windows.Forms.TabPage 資料查詢;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label startlabel;
        private System.Windows.Forms.ComboBox monthcomboBox1;
        private System.Windows.Forms.ComboBox yearcomboBox1;
        private System.Windows.Forms.Label hourlabel2;
        private System.Windows.Forms.ComboBox hourcomboBox2;
        private System.Windows.Forms.ComboBox daycomboBox2;
        private System.Windows.Forms.Label daylabel2;
        private System.Windows.Forms.Label monthlabel2;
        private System.Windows.Forms.Label yearlabel2;
        private System.Windows.Forms.ComboBox monthcomboBox2;
        private System.Windows.Forms.ComboBox yearcomboBox2;
        private System.Windows.Forms.Label hourlabel1;
        private System.Windows.Forms.ComboBox hourcomboBox1;
        private System.Windows.Forms.ComboBox daycomboBox1;
        private System.Windows.Forms.Label daylabel1;
        private System.Windows.Forms.Label monthlabel1;
        private System.Windows.Forms.Label yearlabel1;
        private System.Windows.Forms.Label ENDlabel;
        private System.Windows.Forms.Button datasearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label SERCH;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton DO1OFF;
        private System.Windows.Forms.RadioButton DO1ON;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DO0OFF;
        private System.Windows.Forms.RadioButton DO0ON;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label SystemTimeLabel;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button disconnect;
    }
}


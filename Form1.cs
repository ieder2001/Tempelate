using MathLibrary;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;

namespace Meter
{
    public partial class Form1 : Form
    {
        StrHandler msgHandler;
        errorHandler errorHandler;
        DataClient dataClient;

        public Form1()
        {
            InitializeComponent();
            msgHandler = this.dataRefresh;
            errorHandler = this.errorRefresh;
            //全螢幕
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.WorkerSupportsCancellation = true;
            textBoxIP.Text = "127.0.0.1";
            textBoxPort.Text = "502";
            #region 時間設定
            yearcomboBox1.Text = DateTime.Now.ToString("yyyy");
            yearcomboBox2.Text = DateTime.Now.ToString("yyyy");
            monthcomboBox1.Text = DateTime.Now.ToString("MM");
            monthcomboBox2.Text = DateTime.Now.ToString("MM");
            daycomboBox1.Text = DateTime.Now.ToString("dd");
            daycomboBox2.Text = DateTime.Now.ToString("dd");
            hourcomboBox1.Text = DateTime.Now.ToString("HH");
            hourcomboBox2.Text = DateTime.Now.ToString("HH");

            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
            {
                yearcomboBox1.Items.Add(i.ToString());
                yearcomboBox2.Items.Add(i.ToString());
            }
            for (int i = 1; i <=9; i++)
            {
                monthcomboBox1.Items.Add("0"+i.ToString());
                monthcomboBox2.Items.Add("0"+i.ToString());
            }
            for (int i = 10; i <= 12; i++)
            {
                monthcomboBox1.Items.Add(i.ToString());
                monthcomboBox2.Items.Add(i.ToString());
            }
            for (int i = 1; i <= 9; i++)
            {
                daycomboBox1.Items.Add("0"+i.ToString());
                daycomboBox2.Items.Add("0"+i.ToString());
            }
            for (int i = 10; i <= 31; i++)
            {
                daycomboBox1.Items.Add(i.ToString());
                daycomboBox2.Items.Add(i.ToString());
            }
            for (int i = 0; i <= 9; i++)
            {
                hourcomboBox1.Items.Add("0"+i.ToString());
                hourcomboBox2.Items.Add("0"+i.ToString());
            }
            for (int i = 10; i <= 24; i++)
            {
                hourcomboBox1.Items.Add(i.ToString());
                hourcomboBox2.Items.Add(i.ToString());
            }
            #endregion
            #region 查詢頁面設定
            string [] options = new string[]{ "AO0", "AO1", "AO2", "AO3" };
            checkedListBox1.Items.AddRange(options);
            #endregion
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) //HVAC 
        {
            dataClient.connect(messageProcess, errorProcess);
            dataClient.dataMining(miningInfo.case1());
        }

        private void datasearch_Click(object sender, EventArgs e)  //資料蒐尋
        {
            zedGraphControl1.GraphPane.CurveList.Clear(); //清除圖表
            zedGraphControl1.GraphPane.GraphObjList.Clear();//清除圖表

            string mychsitem = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)  //選擇需查詢項目
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    mychsitem += "," + checkedListBox1.Items[i].ToString();
                }
            }
            string ConnSrchLog = "server = 127.0.0.1; database=DBREMOTE; uid=sa; pwd=k260881";
            SqlConnection ConnSrch = new SqlConnection(ConnSrchLog);
            if (ConnSrch.State == ConnectionState.Closed)
                ConnSrch.Open();
            string SelectSrchData = "SELECT Time" + mychsitem + " FROM Test where Time > '" + yearcomboBox1.Text + monthcomboBox1.Text + daycomboBox1.Text + hourcomboBox1.Text +
                "' and Time <'" + yearcomboBox2.Text + monthcomboBox2.Text + daycomboBox2.Text + hourcomboBox2.Text + "'";
            try
            {

                SqlDataAdapter Srchadt = new SqlDataAdapter(SelectSrchData, ConnSrch);
                DataSet ds = new DataSet();
                Srchadt.Fill(ds, "Test");//產生表單
                dataGridView1.DataSource = ds.Tables["Test"]; //產生表單
                #region 圖表繪製
                void CreateGraph(ZedGraphControl zgc)
                {
                    // get a reference to the GraphPane
                    GraphPane myPane = zgc.GraphPane;

                    // Set the Titles
                    myPane.Title.Text = "歷史記錄曲線";
                    myPane.XAxis.Title.Text = "時間";
                    myPane.YAxis.Title.Text = "";
                    myPane.XAxis.Type = AxisType.Date;
                    myPane.XAxis.Scale.Format = "yyyyMMddHHmm";

                    // Make up some data arrays based on the Sine function
                    double x;
                    double y1, y2;
                    PointPairList list1 = new PointPairList();
                    PointPairList list2 = new PointPairList();
                    PointPairList list3 = new PointPairList();
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        string ttime = ds.Tables[0].Rows[j]["Time"].ToString();
                        int yyear = int.Parse(ttime.Substring(0, 4));
                        int mmonth = int.Parse(ttime.Substring(4, 2));
                        int dday = int.Parse(ttime.Substring(6, 2));
                        int hhour = int.Parse(ttime.Substring(8, 2));
                        int mminute = int.Parse(ttime.Substring(10, 2));
                        DateTime date1 = new DateTime(yyear, mmonth, dday, hhour, mminute, 00);
                        x = (double)new XDate(date1);
                        y1 = double.Parse(ds.Tables[0].Rows[j].ItemArray[1].ToString());
                        //ouble  a=(double)new XDate((DateTime)(dt.Rows[i]["mydate"]));
                        if (ds.Tables[0].Columns.Count > 2)
                        {
                            y2 = double.Parse(ds.Tables[0].Rows[j].ItemArray[2].ToString());
                            list2.Add(x, y2);
                        }
                        list1.Add(x, y1);
                    }
                    LineItem myCurve = myPane.AddCurve(ds.Tables[0].Columns[1].ColumnName,
                          list1, Color.Red, SymbolType.Diamond);

                    if (ds.Tables[0].Columns.Count > 2)
                    {
                        LineItem myCurve2 = myPane.AddCurve(ds.Tables[0].Columns[2].ColumnName,
                        list2, Color.Blue, SymbolType.Circle);
                    }

                    zgc.AxisChange();
                }
                #endregion
                CreateGraph(zedGraphControl1);//生成圖表

            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            ConnSrch.Close();
        }

        private void button1_Click(object sender, EventArgs e)//輸入
        {

        }

        private void button2_Click(object sender, EventArgs e)//輸入
        {
            
        }

        private void connect_Click(object sender, EventArgs e)
        {
            dataClient = new DataClient(textBoxIP.Text, textBoxPort.Text);
            dataClient.workState = true;
            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync();  
            }
            textBoxIP.Enabled = false;
            textBoxPort.Enabled = false;
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            dataClient.workState = false;
            if (backgroundWorker1.IsBusy == true)
            {
                backgroundWorker1.CancelAsync();  
            }
            textBoxIP.Enabled = true;
            textBoxPort.Enabled = true;
        }
        public String dataRefresh(string t, double a0, double a1, double a2, double a3)
        {
            
            SystemTimeLabel.Text = t;
            label2.Text = a0.ToString();
            label4.Text = a1.ToString();
            label6.Text = a2.ToString();
            label8.Text = a3.ToString();
            /*
            ConnectStateLabel.Text = state;
            ConnectStateLabel.BackColor = b;
            ConnectStateLabel.ForeColor = f;
            */
            return "OK";
        }

        public String messageProcess(string t, double a0, double a1, double a2, double a3)
        {
            this.Invoke(msgHandler, new Object[] { t, a0, a1, a2, a3 });
            return "OK";
        }

        public String errorRefresh(string state, Color b, Color f)
        {
            ConnectStateLabel.Text = state;
            ConnectStateLabel.BackColor = b;
            ConnectStateLabel.ForeColor = f;
            return "OK";
        }

        public String errorProcess(string state, Color b, Color f)
        {
            this.Invoke(errorHandler, new Object[] { state, b, f });
            return "OK";
        }


    }
}

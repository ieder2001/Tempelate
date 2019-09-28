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

        public Form1()
        {
            InitializeComponent();
            //全螢幕
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;
        }
        ErrorMessageClass ErrMsg;
        private string mWorkPath = Directory.GetCurrentDirectory();
        private string ConnStr;
        public int EditLongTime = 10;
        private DateTime mLastReadTime = DateTime.Parse("1900/01/01 00:00:00");         //最後一次讀取成功的時間
        public int mDisconnectSpace = 15;//設備數量
        private bool mDisconnectFlog = false;
        private bool myWorkState = false;
        MathClass Calculate = new MathClass();
        NetworkStream myNetworkStream;

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.WorkerSupportsCancellation = true;
            textBox1.Text = "127.0.0.1";
            textBox2.Text = "502";
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
            int mPort = int.Parse(textBox2.Text);
            IPAddress mIp = IPAddress.Parse(textBox1.Text);
            IPEndPoint myIpEndPoint = new IPEndPoint(mIp, mPort);
            TcpClient myTcpClient = new TcpClient();
            myTcpClient.ReceiveTimeout = 1000;
            myTcpClient.SendTimeout = 1000;

            try
            { myTcpClient.Connect(myIpEndPoint); }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            while (myWorkState)
            {
                string ConnStrLog = "server = 127.0.0.1; database=DBREMOTE; uid=sa; pwd=k260881";
                //string.Format("server = {0}; database={1}_" + DateTime.Now.Year.ToString() + "; uid={2}; pwd={3};", SQLServerIp, SQLDatabase, SQLUserId, SQLUserPwd);        //SQL server connect command.
                if (myTcpClient.Connected)
                {
                    myNetworkStream = myTcpClient.GetStream();
                    TimeSpan ReadTimeSpan = DateTime.Now.Subtract(mLastReadTime);
                    if (ReadTimeSpan.TotalSeconds >= 1)//單位秒
                    {
                        #region 現場數據讀取
                        try
                        {
                            byte[] Cmd = new byte[12];
                            Cmd[0] = 0x00;
                            Cmd[1] = 0x00;
                            Cmd[2] = 0x00;
                            Cmd[3] = 0x00;
                            Cmd[4] = 0x00;
                            Cmd[5] = 0x06;
                            Cmd[6] = 0X01;
                            Cmd[7] = 0x04;
                            Cmd[8] = 0x00;
                            Cmd[9] = 0x00;
                            Cmd[10] = 0x00;
                            Cmd[11] = 0x04;
                            myNetworkStream.Write(Cmd, 0, Cmd.Length);
                            byte[] Inbyte = new byte[1024];
                            try
                            {
                                myNetworkStream.Read(Inbyte, 0, Inbyte.Length);
                            }
                            catch (IOException) { }
                            if (Inbyte[6] == Cmd[6] && Inbyte[7] == Cmd[7])
                            {
                                {
                                    DateTime mNowTime = DateTime.Now;
                                    string tDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                    SystemTimeLabel.Text = tDateTime;
                                    double[] mai1 = new double[4];
                                    for (int i = 0; i < 4; i++)
                                    {
                                        mai1[i] = Calculate.work16to10(Inbyte[9 + 2 * i], Inbyte[10 + 2 * i]);
                                    }
                                    double ao0 = Math.Round(mai1[0], 2);//小數點第二位
                                    double ao1 = Math.Round(mai1[1], 2);
                                    double ao2 = Math.Round(mai1[2], 2);
                                    double ao3 = Math.Round(mai1[3], 2);
                                    label2.Text = ao0.ToString();
                                    label4.Text = ao1.ToString();
                                    label6.Text = ao2.ToString();
                                    label8.Text = ao3.ToString();

                                    
                                    SqlConnection ConnTxt = new SqlConnection(ConnStrLog);
                                    if (ConnTxt.State == ConnectionState.Closed)
                                        ConnTxt.Open();

                                    #region Insert資料更新  
                                    string SelectExiData = "SELECT*FROM TEST where Time='" + mNowTime.ToString("yyyyMMddHHmm") + "00'";  //確認資料庫是否已有資料
                                    try
                                    {
                                        SqlCommand CmdExidata = new SqlCommand(SelectExiData, ConnTxt);
                                        SqlDataReader Exidata = CmdExidata.ExecuteReader();
                                        if (Exidata.HasRows) { }
                                        else
                                        {
                                            SqlConnection Conninsert = new SqlConnection(ConnStrLog);
                                            if (Conninsert.State == ConnectionState.Closed)
                                            {
                                                Conninsert.Open();
                                            }
                                            string DataInsert = "INSERT INTO TEST(Time,AO0,AO1,AO2,AO3) VALUES (" + mNowTime.ToString("yyyyMMddHHmm") + "00" + "," + ao0 + "," + ao1 + "," + ao2 + "," + ao3 + ")";  //如果沒有則輸入資料
                                            try
                                            {
                                                SqlCommand CmdInsertdata = new SqlCommand(DataInsert, Conninsert);
                                                SqlDataReader Insertdata = CmdInsertdata.ExecuteReader();
                                                Insertdata.Close();
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.ToString());
                                            }
                                            Conninsert.Close();
                                        }
                                        Exidata.Close();

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                    #endregion

                                    #region Update資料更新 
                                    /*
                                    int nowtimesec = Int32.Parse(DateTime.Now.Second.ToString());
                                    if (nowtimesec % 5 == 0)
                                    {
                                        string SelectExiData1 = "SELECT*FROM TableUpdate where Time='" + mNowTime.ToString("yyyyMMddHHmmss") + "'";
                                        try
                                        {
                                            SqlCommand CmdExidata = new SqlCommand(SelectExiData1, ConnTxt);
                                            SqlDataReader Exidata = CmdExidata.ExecuteReader();
                                            if (Exidata.HasRows) { }
                                            else
                                            {
                                                SqlConnection Conninsert = new SqlConnection(ConnStrLog);
                                                if (Conninsert.State == ConnectionState.Closed)
                                                {
                                                    Conninsert.Open();
                                                }
                                                string DataInsert1 = "UPDATE TableUpdate SET Time =" + mNowTime.ToString("yyyyMMddHHmmss") + ",OA_TT =" + mai1[0] / 100 + ", OA_RH=" + mai1[1] / 100 + ", CH_FM=" + mai1[2] + ", CHS_TT=" + mai1[3] / 100 + ", CHR_TT=" + mai1[4] / 100 + ",CWS_TT=" + mai1[5] / 100 + ",CWR_TT=" + mai1[6] / 100 + ",F01_DPT=" + mai1[7] / 100 +
                                                     ", F02_DPT=" + mai1[8] / 100 + ",CH_BV=" + mai1[9] / 100 + ",CHP_01_VFD=" + mai1[10] / 100 + ", CHP_02_VFD=" + mai1[11] / 100 + ",CHP_03_VFD=" + mai1[12] / 100 + ",CT_01_VFD=" + mai1[13] / 100 + ",CT_02_VFD=" + mai1[14] / 100 + ",CT_03_VFD=" + mai1[15] / 100 + ",CT_04_VFD=" + mai1[16] / 100 + ",CT_05_VFD=" + mai1[17] / 100 + ", CT_PH=" + mai1[18] / 100 +
                                                     ",CT_CM=" + mai1[19] / 10+",CH_01_HMI = " + mai[0] + ",CH_01_CH_HMI = " + mai[1] + ", CH_01_CW_HMI = " + mai[2]+ ", CH_02_HMI = " + mai[3] + ",CH_02_CH_HMI = " + mai[4] + ", CH_02_CW_HMI = " + mai[5] + ",CH_03_HMI = " + mai[6] + ",CH_03_CH_HMI = " + mai[7] + ",CH_03_CW_HMI = " + mai[8] +
                                                     ", CHP_01_HMI=" + mai[9] + ",CHP_01_DPS_HMI=" + mai[10] + ",CHP_02_HMI=" + mai[11] + ", CHP_02_DPS_HMI=" + mai[12] + ",CHP_03_HMI=" + mai[13] + ",CHP_03_DPS_HMI=" + mai[14] + ",CWP_01_HMI=" + mai[15] + ",CWP_01_DPS_HMI=" + mai[16] + ",CWP_02_HMI=" + mai[17] + ",CWP_02_DPS_HMI=" + mai[18] + ", CWP_03_HMI=" + mai[19] +
                                                     ",CWP_03_DPS_HMI=" + mai[20] + ",CT_01_HMI=" + mai[21] + ",CT_02_HMI=" + mai[22] + ",CT_03_HMI=" + mai[23] + ",CT_04_HMI=" + mai[24] + ",CT_05_HMI=" + mai[25] + ",CH_BV_HMI=" + mai[26] ; //更新資料
                                                try
                                                {
                                                    SqlCommand CmdInsertdata = new SqlCommand(DataInsert1, Conninsert);
                                                    SqlDataReader Insertdata = CmdInsertdata.ExecuteReader();
                                                    Insertdata.Close();
                                                    // 顯示數據
                                                    double OA_TT = mai1[0]/100;


                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.ToString());
                                                }
                                                Conninsert.Close();
                                            }

                                            Exidata.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString());
                                        }
                                    }
                                    */
                                    #endregion

                                    ConnTxt.Close();
                                }
                            }
                            mLastReadTime = DateTime.Now;
                        }
                        catch (Exception ex)
                        { ErrMsg._error("現場數據讀取", ex); }
                        #endregion
                    }
                }
                else
                {
                    TimeSpan DisconnectSpan = DateTime.Now.Subtract(mLastReadTime);
                    if (DisconnectSpan.TotalSeconds >= mDisconnectSpace)
                    if (DisconnectSpan.TotalSeconds >= mDisconnectSpace)
                    if (DisconnectSpan.TotalSeconds >= mDisconnectSpace)
                    if (DisconnectSpan.TotalSeconds >= mDisconnectSpace)
                    if (DisconnectSpan.TotalSeconds >= mDisconnectSpace)
                    if (DisconnectSpan.TotalSeconds >= mDisconnectSpace)
                    {
                        if (!mDisconnectFlog)
                        {
                            ConnectStateLabel.Text = "中斷";
                            ConnectStateLabel.BackColor = Color.Red;
                            ConnectStateLabel.ForeColor = Color.White;
                        }
                    }
                    try
                    {
                        myIpEndPoint = new IPEndPoint(mIp, mPort);
                        myTcpClient = new TcpClient();
                        myTcpClient.ReceiveTimeout = 1000;
                        myTcpClient.SendTimeout = 1000;
                        myTcpClient.Connect(myIpEndPoint);
                    }
                    catch (Exception)
                    { }

                }
            }
            myTcpClient.Close();                //關閉通訊埠
        }
        //畫面

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (DO0ON.Checked == true & DO0OFF.Checked == true) { }
            else
            {
                if (DO0ON.Checked == true)
                {
                    try
                    {
                        byte[] Cmd = new byte[14];
                        Cmd[0] = 0x00;
                        Cmd[1] = 0x00;
                        Cmd[2] = 0x00;
                        Cmd[3] = 0x00;
                        Cmd[4] = 0x00;
                        Cmd[5] = 0x06;
                        Cmd[6] = 0X01;
                        Cmd[7] = 0x05;
                        Cmd[8] = 0x00;
                        Cmd[9] = 0x00;
                        Cmd[10] = 0xFF;
                        Cmd[11] = 0x00;
                        myNetworkStream.Write(Cmd, 0, Cmd.Length);
                        byte[] Inbyte = new byte[1024];
                        try
                        {
                           myNetworkStream.Read(Inbyte, 0, Inbyte.Length);
                        }
                        catch (IOException) { }
                        if (Inbyte[6] == Cmd[6] && Inbyte[7] == Cmd[7])
                        {
                        }
                        mLastReadTime = DateTime.Now;
                    }
                    catch (Exception ex)
                    { ErrMsg._error("資訊讀取及解析異常", ex); }
                }
                if (DO0OFF.Checked == true)
                {
                    try
                    {
                        byte[] Cmd = new byte[14];
                        Cmd[0] = 0x00;
                        Cmd[1] = 0x00;
                        Cmd[2] = 0x00;
                        Cmd[3] = 0x00;
                        Cmd[4] = 0x00;
                        Cmd[5] = 0x06;
                        Cmd[6] = 0X01;
                        Cmd[7] = 0x05;
                        Cmd[8] = 0x00;
                        Cmd[9] = 0x00;
                        Cmd[10] = 0x00;
                        Cmd[11] = 0x00;

                        myNetworkStream.Write(Cmd, 0, Cmd.Length);
                        byte[] Inbyte = new byte[1024];
                        try
                        {
                           myNetworkStream.Read(Inbyte, 0, Inbyte.Length);
                        }
                        catch (IOException) { }
                        if (Inbyte[6] == Cmd[6] && Inbyte[7] == Cmd[7])
                        {
                        }
                        mLastReadTime = DateTime.Now;
                    }
                    catch (Exception ex)
                    { ErrMsg._error("資訊讀取及解析異常", ex); }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DO1ON.Checked == true & DO1OFF.Checked == true) { }
            else
            {
                if (DO1ON.Checked == true)
                {
                    try
                    {
                        byte[] Cmd = new byte[14];
                        Cmd[0] = 0x00;
                        Cmd[1] = 0x00;
                        Cmd[2] = 0x00;
                        Cmd[3] = 0x00;
                        Cmd[4] = 0x00;
                        Cmd[5] = 0x06;
                        Cmd[6] = 0X01;
                        Cmd[7] = 0x05;
                        Cmd[8] = 0x00;
                        Cmd[9] = 0x01;
                        Cmd[10] = 0xFF;
                        Cmd[11] = 0x00;
                        myNetworkStream.Write(Cmd, 0, Cmd.Length);
                        byte[] Inbyte = new byte[1024];
                        try
                        {
                            myNetworkStream.Read(Inbyte, 0, Inbyte.Length);
                        }
                        catch (IOException) { }
                        if (Inbyte[6] == Cmd[6] && Inbyte[7] == Cmd[7])
                        {
                        }
                        mLastReadTime = DateTime.Now;
                    }
                    catch (Exception ex)
                    { ErrMsg._error("資訊讀取及解析異常", ex); }
                }
                if (DO1OFF.Checked == true)
                {
                    try
                    {
                        byte[] Cmd = new byte[14];
                        Cmd[0] = 0x00;
                        Cmd[1] = 0x00;
                        Cmd[2] = 0x00;
                        Cmd[3] = 0x00;
                        Cmd[4] = 0x00;
                        Cmd[5] = 0x06;
                        Cmd[6] = 0X01;
                        Cmd[7] = 0x05;
                        Cmd[8] = 0x00;
                        Cmd[9] = 0x01;
                        Cmd[10] = 0x00;
                        Cmd[11] = 0x00;

                        myNetworkStream.Write(Cmd, 0, Cmd.Length);
                        byte[] Inbyte = new byte[1024];
                        try
                        {
                            myNetworkStream.Read(Inbyte, 0, Inbyte.Length);
                        }
                        catch (IOException) { }
                        if (Inbyte[6] == Cmd[6] && Inbyte[7] == Cmd[7])
                        {
                        }
                        mLastReadTime = DateTime.Now;
                    }
                    catch (Exception ex)
                    { ErrMsg._error("資訊讀取及解析異常", ex); }
                }
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            myWorkState = true;
            if (backgroundWorker1.IsBusy == false)
            {
                backgroundWorker1.RunWorkerAsync();  //HVAC
            }
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            myWorkState = false;
            if (backgroundWorker1.IsBusy == true)
            {
                backgroundWorker1.CancelAsync();  //HVAC
            }
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }
    }
}

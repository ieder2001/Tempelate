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
    public delegate String StrHandler(string t, double a0, double a1, double a2, double a3);
    public delegate String errorHandler(string state, Color b, Color f);

    public static class miningInfo
    {
        public static byte[] case1()
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
            return Cmd;
        }
    }

    public class DataClient
    {
        IPAddress mIp;
        int mPort;
        IPEndPoint myIpEndPoint;
        TcpClient myTcpClient = new TcpClient();
        MathClass Calculate = new MathClass();
        NetworkStream myNetworkStream;
        private string mWorkPath = Directory.GetCurrentDirectory();
        public int EditLongTime = 10;
        private DateTime mLastReadTime = DateTime.Parse("1900/01/01 00:00:00"); //最後一次讀取成功的時間
        public int mDisconnectSpace = 15; //斷線時間
        private bool mDisconnectFlog = false;
        public bool workState = false;
        public StrHandler inHandler;
        public errorHandler errorHandler;

        public DataClient(string ip, string port)
        {
            mPort = int.Parse(port);
            mIp = IPAddress.Parse(ip);
            myIpEndPoint = new IPEndPoint(mIp, mPort);
        }

        public void connect(StrHandler pHandler, errorHandler eHandler)
        {
            try
            {
                inHandler = pHandler;
                errorHandler = eHandler;
                myTcpClient.Connect(myIpEndPoint);
                myTcpClient.ReceiveTimeout = 1000;
                myTcpClient.SendTimeout = 1000;
                workState = true;
            }
            catch(Exception ex)
            { MessageBox.Show(ex.ToString());}

        }

        public void dataMining(byte[] m)
        {
            while (workState)
            {
                if (myTcpClient.Connected == true)
                {
                    myNetworkStream = myTcpClient.GetStream();
                    TimeSpan ReadTimeSpan = DateTime.Now.Subtract(mLastReadTime);
                    if (ReadTimeSpan.TotalSeconds >= 1)//單位秒
                    {
                        try
                        {
                            byte[] Cmd = m;
                            myNetworkStream.Write(Cmd, 0, Cmd.Length);
                            byte[] Inbyte = new byte[1024];
                            try
                            {
                                myNetworkStream.Read(Inbyte, 0, Inbyte.Length);
                            }
                            catch (IOException) { }
                            if (Inbyte[6] == Cmd[6] && Inbyte[7] == Cmd[7])
                            {
                                DateTime mNowTime = DateTime.Now;
                                string tDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                double[] mai1 = new double[4];
                                for (int i = 0; i < 4; i++)
                                {
                                    mai1[i] = Calculate.work16to10(Inbyte[9 + 2 * i], Inbyte[10 + 2 * i]);
                                }
                                double ao0 = Math.Round(mai1[0], 2);//小數點第二位
                                double ao1 = Math.Round(mai1[1], 2);
                                double ao2 = Math.Round(mai1[2], 2);
                                double ao3 = Math.Round(mai1[3], 2);
                                inHandler(tDateTime, ao0, ao1, ao2, ao3 );
                                SQLClient sqlClient = new SQLClient();
                                sqlClient.Connect();
                                sqlClient.saving(ao0, ao1, ao2, ao3);
                            }
                            mLastReadTime = DateTime.Now;
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.ToString()); }
                    }
                }
                else
                {
                    TimeSpan DisconnectSpan = DateTime.Now.Subtract(mLastReadTime);
                    if (DisconnectSpan.TotalSeconds >= mDisconnectSpace)
                    {
                        if (!mDisconnectFlog)
                        {
                            errorHandler("中斷", Color.Red, Color.White);
                            /*
                            ConnectStateLabel.Text = "中斷";
                            ConnectStateLabel.BackColor = Color.Red;
                            ConnectStateLabel.ForeColor = Color.White;
                            */
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
                    catch (Exception ex)
                    { MessageBox.Show(ex.ToString()); }
                }
            }
            myTcpClient.Close();                //關閉通訊埠
        }
    }

    public class SQLClient
    {
        string SQLServerIp, SQLDatabase, SQLUserId, SQLUserPwd;
        string ConnStrLog;
        SqlConnection ConnTxt;

        public SQLClient()
        {
            SQLServerIp = "127.0.0.1";
            SQLDatabase = "DBREMOTE";
            SQLUserId = "sa";
            SQLUserPwd = "k260881";
            //ConnStrLog = "server = 127.0.0.1; database=DBREMOTE; uid=sa; pwd=k260881";
            ConnStrLog = string.Format("server = {0}; database={1}; uid={2}; pwd={3}", SQLServerIp, SQLDatabase, SQLUserId, SQLUserPwd); //"server = 127.0.0.1; database=DBREMOTE; uid=sa; pwd=k260881";
        }

        public void Connect()
        {
            ConnTxt = new SqlConnection(ConnStrLog);
            if (ConnTxt.State == ConnectionState.Closed)
                try
                {
                    ConnTxt.Open();
                }
       
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        public void saving(double a1, double a2, double a3, double a4)
        {
            DateTime mNowTime = DateTime.Now;
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
                    string DataInsert = "INSERT INTO TEST(Time,AO0,AO1,AO2,AO3) VALUES (" + mNowTime.ToString("yyyyMMddHHmm") + "00" + "," + a1 + "," + a2 + "," + a3 + "," + a4 + ")";  //如果沒有則輸入資料
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
            ConnTxt.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using MathLibrary;

namespace Meter
{
    class DatabaseClass
    {
        ErrorMessageClass ErrMsg = new ErrorMessageClass();
        public string ConnStr;
        private string mWorkPath;               //資料路徑
        public string WorkPath
        {
            get { return mWorkPath; }
            set
            {
                if (WorkPath == "") value = Directory.GetCurrentDirectory();
                mWorkPath = value;
            }
        }

        public bool CheckDatabaseExistFunction(DateTime _time)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(ConnStr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string SelectCheckDatabaseExist = "SELECT * FROM sys.databases WHERE name = 'EMS_" + _time.ToString("yyyy") + "'";
            try
            {
                SqlCommand CmdCheckDatabaseExist = new SqlCommand(SelectCheckDatabaseExist, ConnTxt);
                SqlDataReader CheckDatabaseExist = CmdCheckDatabaseExist.ExecuteReader();
                if (!CheckDatabaseExist.HasRows)
                    RecordFlog = false;         //資料庫不存在
                else
                    RecordFlog = true;          //資料庫存在
                CheckDatabaseExist.Close();
            }
            catch (Exception ex)
            {
                ErrMsg._error(SelectCheckDatabaseExist, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool CreateDatabaseFunction(DateTime _time)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(ConnStr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string CreateDatabase = "CREATE DATABASE [EMS_" + _time.ToString("yyyy") + "]";
            try
            {
                SqlCommand CmdDatabase = new SqlCommand(CreateDatabase, ConnTxt);
                SqlDataReader Database = CmdDatabase.ExecuteReader();
                Database.Close();
                RecordFlog = true;
            }
            catch (Exception ex)
            {
                ErrMsg._error(CreateDatabase, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool CheckDataTableExistFunction(string _datatablename)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(ConnStr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string SelectCheckDataTableExist = "SELECT COUNT(*) AS tcount FROM sysobjects WHERE name = '" + _datatablename + "'";
            try
            {
                SqlCommand CmdCheckDataTableExist = new SqlCommand(SelectCheckDataTableExist, ConnTxt);
                SqlDataReader CheckDataTableExist = CmdCheckDataTableExist.ExecuteReader();
                if (CheckDataTableExist.HasRows)
                    if (CheckDataTableExist.Read())
                    {
                        int mTableCount = Convert.ToInt32(CheckDataTableExist["tcount"]);
                        if (mTableCount == 1)
                            RecordFlog = true;          //資料表存在
                        else
                            RecordFlog = false;         //資料表不存在
                    }
                    else
                    {
                        RecordFlog = false;             //資料表不存在
                    }
                else
                    RecordFlog = false;                 //資料表不存在
            }
            catch (Exception ex)
            {
                ErrMsg._error(SelectCheckDataTableExist, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool CheckDataTableExistFunction(string _datatablename, string _connstr)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(_connstr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string SelectCheckDataTableExist = "SELECT COUNT(*) AS tcount FROM sysobjects WHERE name = '" + _datatablename + "'";
            try
            {
                SqlCommand CmdCheckDataTableExist = new SqlCommand(SelectCheckDataTableExist, ConnTxt);
                SqlDataReader CheckDataTableExist = CmdCheckDataTableExist.ExecuteReader();
                if (CheckDataTableExist.HasRows)
                    if (CheckDataTableExist.Read())
                    {
                        int mTableCount = Convert.ToInt32(CheckDataTableExist["tcount"]);
                        if (mTableCount == 1)
                            RecordFlog = true;          //資料表存在
                        else
                            RecordFlog = false;         //資料表不存在
                    }
                    else
                    {
                        RecordFlog = false;             //資料表不存在
                    }
                else
                    RecordFlog = false;                 //資料表不存在
            }
            catch (Exception ex)
            {
                ErrMsg._error(SelectCheckDataTableExist, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool CreateDataTableFunction(string _datatablename, string _createcommand)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(ConnStr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string CreateDataTable = "CREATE TABLE [" + _datatablename + "](" + _createcommand + ")";
            try
            {
                SqlCommand CmdDataTable = new SqlCommand(CreateDataTable, ConnTxt);
                SqlDataReader DataTable = CmdDataTable.ExecuteReader();
                DataTable.Close();
                RecordFlog = false;
            }
            catch (Exception ex)
            {
                ErrMsg._error(CreateDataTable, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool CreateDataTableFunction(string _datatablename, string _createcommand, string _connstr)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(_connstr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string CreateDataTable = "CREATE TABLE [" + _datatablename + "](" + _createcommand + ")";
            try
            {
                SqlCommand CmdDataTable = new SqlCommand(CreateDataTable, ConnTxt);
                SqlDataReader DataTable = CmdDataTable.ExecuteReader();
                DataTable.Close();
                RecordFlog = false;
            }
            catch (Exception ex)
            {
                ErrMsg._error(CreateDataTable, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool CheckDataLogExistFunction(string _tablename, string _condition)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(ConnStr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string SelectCheckDataLog = "SELECT * FROM " + _tablename + " WHERE " + _condition;
            try
            {
                SqlCommand CmdCheckDataLog = new SqlCommand(SelectCheckDataLog, ConnTxt);
                SqlDataReader CheckDataLog = CmdCheckDataLog.ExecuteReader();
                if (CheckDataLog.HasRows)
                    RecordFlog = true;
                else
                    RecordFlog = false;
                CheckDataLog.Close();
            }
            catch (Exception ex)
            {
                ErrMsg._error(SelectCheckDataLog, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool CheckDataLogExistFunction(string _tablename, string _condition, string _connstr)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(_connstr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string SelectCheckDataLog = "SELECT * FROM " + _tablename + " WHERE " + _condition;
            try
            {
                SqlCommand CmdCheckDataLog = new SqlCommand(SelectCheckDataLog, ConnTxt);
                SqlDataReader CheckDataLog = CmdCheckDataLog.ExecuteReader();
                if (CheckDataLog.HasRows)
                    RecordFlog = true;
                else
                    RecordFlog = false;
                CheckDataLog.Close();
            }
            catch (Exception ex)
            {
                ErrMsg._error(SelectCheckDataLog, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool AddNewDataLogFunction(string _tablename, string _columns, string _data)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(ConnStr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string InsertNewDataLog = "INSERT INTO " + _tablename + "(" + _columns + ") VALUES (" + _data + ")";
            try
            {
                SqlCommand CmdNewDataLog = new SqlCommand(InsertNewDataLog, ConnTxt);
                int NewDataLog = CmdNewDataLog.ExecuteNonQuery();
                if (NewDataLog == 1)
                    RecordFlog = true;
                else
                    RecordFlog = false;
            }
            catch (Exception ex)
            {
                ErrMsg._error(InsertNewDataLog, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool AddNewDataLogFunction(string _tablename, string _columns, string _data, string _connstr)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(_connstr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string InsertNewDataLog = "INSERT INTO " + _tablename + "(" + _columns + ") VALUES (" + _data + ")";
            try
            {
                SqlCommand CmdNewDataLog = new SqlCommand(InsertNewDataLog, ConnTxt);
                int NewDataLog = CmdNewDataLog.ExecuteNonQuery();
                if (NewDataLog == 1)
                    RecordFlog = true;
                else
                    RecordFlog = false;
            }
            catch (Exception ex)
            {
                ErrMsg._error(InsertNewDataLog, ex);
                RecordFlog = false;
            }
            ConnTxt.Close();
            return RecordFlog;
        }

        public bool EditDataLogFunction(string _tablename, string _command, string _condition)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(ConnStr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string UpdateEditDataLog = "UPDATE [" + _tablename + "] SET " + _command + " WHERE " + _condition;
            try
            {
                SqlCommand CmdEditDataLog = new SqlCommand(UpdateEditDataLog, ConnTxt);
                int EditDataLog = CmdEditDataLog.ExecuteNonQuery();
                if (EditDataLog == 1)
                    RecordFlog = true;
                else
                    RecordFlog = false;
            }
            catch (Exception ex)
            {
                ErrMsg._error(UpdateEditDataLog, ex);
                RecordFlog = false;
            }

            ConnTxt.Close();
            return RecordFlog;
        }
        public bool EditDataLogFunction(string _tablename, string _command, string _condition, string _connstr)
        {
            bool RecordFlog = false;
            SqlConnection ConnTxt = new SqlConnection(_connstr);
            if (ConnTxt.State == ConnectionState.Closed)
                ConnTxt.Open();
            string UpdateEditDataLog = "UPDATE [" + _tablename + "] SET " + _command + " WHERE " + _condition;
            try
            {
                SqlCommand CmdEditDataLog = new SqlCommand(UpdateEditDataLog, ConnTxt);
                int EditDataLog = CmdEditDataLog.ExecuteNonQuery();
                if (EditDataLog == 1)
                    RecordFlog = true;
                else
                    RecordFlog = false;
            }
            catch (Exception ex)
            {
                ErrMsg._error(UpdateEditDataLog, ex);
                RecordFlog = false;
            }

            ConnTxt.Close();
            return RecordFlog;
        }
    }
}

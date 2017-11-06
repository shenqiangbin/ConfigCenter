using Ant.Service.Model;
using System.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using System;

namespace Ant.Service.ConfigCenter.core
{
    public class MySqlRepository
    {
        protected MySqlConnection GetConn()
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
            MySqlConnection conn = new MySqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            return conn;
        }

        public bool ExeTransaction(string sql)
        {
            var conn = GetConn();

            var tran = conn.BeginTransaction();
            try
            {
                conn.Execute(sql);
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                tran.Rollback();
                return false;
            }
            finally
            {
                conn.Dispose();
            }
        }
    }
}

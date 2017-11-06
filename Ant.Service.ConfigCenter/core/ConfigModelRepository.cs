using Ant.Service.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ant.Service.ConfigCenter.core
{
    public class ConfigModelRepository : MySqlRepository
    {
        public ConfigModel SelectBy(int Id)
        {
            using (var conn = GetConn())
            {
                string sql = $"select * from DefaultConfig where id = @id";
                var model = conn.QueryFirstOrDefault<ConfigModel>(sql);
                return model;
            }
        }

        public bool Add(string tableName, string key, string value, string comment)
        {
            using (var conn = GetConn())
            {
                string sql = $"insert {tableName}Config(ConfigKey,ConfigValue,Comment) Values (@Key,@Value,@Comment);";
                DynamicParameters para = new DynamicParameters();
                para.Add("@Key", key);
                para.Add("@Value", value);
                para.Add("@Comment", comment);

                int result = conn.Execute(sql, para);
                if (result == 0)
                    return false;
                return true;
            }
        }

        public void Init()
        {
            string sqlText = System.IO.File.ReadAllText("./sql/sql.txt");
            ExeTransaction(sqlText);
        }
    }
}

using Ant.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Ant.Service.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string doorUrl = ConfigHelper.GetByKey("doorUrl");
            System.Console.WriteLine(doorUrl);

            System.Console.ReadKey();
        }
    }

    public class ConfigHelper
    {
        public static string GetByKey(string key)
        {
            var server = GetConfigServer();
            var table = GetConfigTable();

            string content = NetHelper.Get($"{server}/GetConfigByKey?tableName={table}&key={key}");
            var response = JsonHelper.DeserializeJsonToObject<Response<ConfigModel>>(content);
            if (response.IsSuccess)
            {
                return response.Data.ConfigValue;
            }
            else
            {
                throw new Exception("获取配置失败");
            }
        }

        private static string GetConfigServer()
        {
            return ConfigurationManager.AppSettings["ConfigServer"];
        }

        private static string GetConfigTable()
        {
            return ConfigurationManager.AppSettings["ConfigTable"];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ant.Service.Model;
using Ant.Service.ConfigCenter.core;

namespace Ant.Service.ConfigCenter
{
    public class Config : IConfig
    {
        private ConfigModelRepository _repository = new ConfigModelRepository();

        public Response Add(string tableName, string key, string value, string comment)
        {
            if (string.IsNullOrEmpty(tableName))
                tableName = "Default";

            Response res = new Response();

            try
            {
                var configModel = _repository.GetConfigByKey(tableName, key);
                if(configModel!=null)
                {
                    res.Code = 502;
                    res.CodeMsg = $"配置【{key}】已存在";
                    return res;
                }

                var result = _repository.Add(tableName, key, value, comment);
                if (result == false)
                {
                    res.Code = 501;
                    res.CodeMsg = "新的配置新增失败";
                }
            }
            catch (Exception ex)
            {
                res.Code = 500;
                res.CodeMsg = "异常";
                Logger.Log(ex);
            }

            return res;
        }

        public Response<ConfigModel> GetConfigByKey(string tableName, string key)
        {
            if (string.IsNullOrEmpty(tableName))
                tableName = "Default";

            Response<ConfigModel> res = new Response<ConfigModel>();

            try
            {
                var result = _repository.GetConfigByKey(tableName, key);
                res.Data = result;
            }
            catch (Exception ex)
            {
                res.Code = 500;
                res.CodeMsg = "异常";
                Logger.Log(ex);
            }

            return res;
        }
    }
}

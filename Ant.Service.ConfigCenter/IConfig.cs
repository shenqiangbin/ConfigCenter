﻿using Ant.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Ant.Service.ConfigCenter
{
    [ServiceContract]
    public interface IConfig
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Add?tableName={tableName}&key={key}&value={value}&comment={comment}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Response Add(string tableName, string key, string value, string comment);
        //http://localhost:8023/Add?key=doorUrl&value=http://www.baidu.com&comment=门户地址
    }
}

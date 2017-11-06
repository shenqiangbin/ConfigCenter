using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Ant.Service.ConfigCenter
{
    public class Service
    {
        private ServiceHost _host = new ServiceHost(typeof(Config));
        public void Start()
        {
            Logger.Log("服务开启");            
            _host.Open();
        }

        public void Stop()
        {
            Logger.Log("服务停止");
            _host.Close();
        }
    }
}

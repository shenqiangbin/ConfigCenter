using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant.Service.ConfigCenter
{
    public class Service
    {
        public void Start()
        {
            Logger.Log("服务开启");
        }

        public void Stop()
        {
            Logger.Log("服务停止");
        }
    }
}

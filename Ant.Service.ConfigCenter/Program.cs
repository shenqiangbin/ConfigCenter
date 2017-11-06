using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Ant.Service.ConfigCenter
{
    class Program
    {
        static void Main(string[] args)
        {
           // ContainerBuilder builder = new ContainerBuilder();

            HostFactory.Run(x =>
            {
                x.Service<Service>(s =>
                {
                    s.ConstructUsing(name => new Service());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc =>
                    {
                        tc.Stop();
                        //_container.Dispose();
                    });
                });
                x.RunAsLocalSystem();

                x.SetDescription("配置中心，提供基础配置服务");
                x.SetDisplayName("Ant程序的配置中心");
                x.SetServiceName("Ant.Service.ConfigCenter");
                //x.UseAutofacContainer(_container);
            });
        }
    }
}

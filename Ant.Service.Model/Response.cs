using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant.Service.Model
{
    public class Response<T>
    {
        public int Code { get; set; }
        public string CodeMsg { get; set; }
        public T Data { get; set; }

        public Response()
        {
            this.Code = 200;
            this.CodeMsg = "success";
        }
    }

    public class Response
    {
        public int Code { get; set; }
        public string CodeMsg { get; set; }

        public Response()
        {
            this.Code = 200;
            this.CodeMsg = "success";
        }
    }
}

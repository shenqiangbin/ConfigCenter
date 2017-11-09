using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ant.Service.Test.Console
{
    public class NetHelper
    {
        public static string Get(string url)
        {
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;

                request.Method = "GET";
                WebResponse response = request.GetResponse();
                var stream = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = sr.ReadToEnd();
                    return content;
                }
            }
            catch (Exception ex)
            {
                
                return "异常";
            }
        }

        public static string Post(string url, object requestData)
        {
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;

                request.Method = "Post";
                request.ContentType = "application/Json; charset=UTF-8";

                string body = JsonHelper.SerializeObject(requestData);           

                byte[] bytes = Encoding.UTF8.GetBytes(body);
                request.GetRequestStream().Write(bytes, 0, bytes.Length);

                WebResponse response = request.GetResponse();
                var stream = response.GetResponseStream();
                using (StreamReader sr = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = sr.ReadToEnd();
                    return content;
                }
            }
            catch (Exception ex)
            {               
                return "异常";
            }
        }
    }
}

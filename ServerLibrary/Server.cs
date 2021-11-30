using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CommunicationEntities;
using Newtonsoft.Json;


namespace ServerLibrary
{
    public class Server
    {
        private HttpListener httpListener;

        public Server()
        {
            httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:21378/api/");
        }

        public void Start()
        {
            httpListener.Start();
        }

        public HttpListenerContext GetClientContext()
        {
            return httpListener.GetContext();
        }

        public static Request RecieveRequestFromClient(HttpListenerContext clientContext)
        {
            HttpListenerRequest requestContext = clientContext.Request;

            string data;

            using (StreamReader requestStream = new StreamReader(requestContext.InputStream, requestContext.ContentEncoding))
            {
                data = requestStream.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<Request>(data);
        }

        public static void SendResponseToClient(HttpListenerContext clientContext, Response response)
        {
            HttpListenerResponse responseContext = clientContext.Response;

            string data = JsonConvert.SerializeObject(response);

            byte[] bytes = Encoding.UTF8.GetBytes(data);

            responseContext.ContentLength64 = bytes.LongLength;

            using (Stream responseStream = responseContext.OutputStream)
            {
                responseStream.Write(bytes, 0, bytes.Length);
            }

        }
    }
}

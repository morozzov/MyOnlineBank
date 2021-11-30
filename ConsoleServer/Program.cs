using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ServerLibrary;
using CommunicationEntities;
using ExceptionEntities;
using ConsoleServer.Tools;

namespace ConsoleServer
{
    class Program
    {
        static void Log(string msg)
        {
            Console.WriteLine($"{DateTime.Now}: {msg}");
        }

        static void SendResponse(HttpListenerContext clientContext, Response response)
		{
			try
			{
                Log($"RESPONSE -- Status:{response.Status}, Data: {response.Data}");

                Server.SendResponseToClient(clientContext, response);
			}
			catch (Exception e)
			{
                Log($"Response failed: {e.Message}");
			}
		}

        static void ProcessClient(HttpListenerContext clientContext)
        {
            Log("CLIENT ENTERED");

            Request request = null;
            Response response = null;

			try
			{
                request = Server.RecieveRequestFromClient(clientContext);

                Log($"REQUEST -- Command: {request.Command}, Params: {request.Parameters}");
			}
			catch (Exception e)
			{
                response = new Response()
                {
                    Status = Response.StatusList.ERROR,
                    Data = e.Message
                };

                Log($"Request failed: {e.Message}");

                SendResponse(clientContext, response);

                return;
			}

			try
			{
				if (request.APIKey != "228papichNNN1337")
				{
                    throw new WrongAPIKeyException();
				}

                response = Router.ProccessCommand(request);

                SendResponse(clientContext, response);
			}
			catch (Exception e)
			{
                //TODO Напомнить Алексею поставить урок на запись
                //TODO инкапсулировать
                response = new Response()
                {
                    Status = Response.StatusList.ERROR,
                    Data = e.Message
                };

                Log($"Request failed: {e.Message}");

                SendResponse(clientContext, response);

                return;
            }
        }

        static void Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server();
                server.Start();
                Log("Server started");
            }
            catch (Exception e)
            {
                Log($"CRITICAL ERROR: {e.Message}\n Programm will be aborted");
                Console.ReadKey();
                Environment.Exit(0);
            }

            while (true)
            {
                try
                {
                    HttpListenerContext clientContext = server.GetClientContext();

                    Task.Run(() => { ProcessClient(clientContext); });
                }
                catch (Exception e)
                {
                    Log($"Client connection exceprion: {e.Message}");
                }
            }
        }
    }
}

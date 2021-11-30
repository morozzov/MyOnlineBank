using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicationEntities;
using System.Reflection;

namespace ConsoleServer.Tools
{
	public class Router
	{
		public static Response ProccessCommand(Request request)
		{
			string[] requestParts = request.Command.Split('.');
			string className = requestParts[0];
			string methodName = requestParts[1];

			Type type = Type.GetType($"ConsoleServer.Controllers.{className}Controller");

			Response response = null;

			if (request.Parameters != "{}")
			{
				//TODO проверить на точке остановы что в request.Parameters
				response = (Response)type.InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, new object[] { request.Parameters });
			}
			else
			{
				response = (Response)type.InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, null, null);

			}
			return response;
		}
	}
}

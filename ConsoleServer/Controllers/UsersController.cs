using DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DbWorker;
using CommunicationEntities;

namespace ConsoleServer.Controllers
{
    public class UsersController
    {
        public static Response GetUserByLoginPassword(string parameters)
        {
            Dictionary<string, string> UsersParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameters);

            string login = UsersParameters["login"];
            string password = UsersParameters["password"];

            User user = DbManager.GetInstance().TableUsers.GetUserByLoginPassword(login, password);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(user)
            };
        }

        public static Response GetUserByLogin(string parameters)
        {
            string login = parameters;

            bool isUser = DbManager.GetInstance().TableUsers.GetUserByLogin(login);

            if (isUser)
            {
                return new Response()
                {
                    Status = Response.StatusList.OK
                };
            }
            else
            {
                return new Response()
                {
                    Status = Response.StatusList.ERROR
                };
            }
        }

        public static Response CreateUser(string parameters)
        {
            Dictionary<string, string> UsersParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(parameters);

            string name = UsersParameters["name"];
            string login = UsersParameters["login"];
            string password = UsersParameters["password"];

            DbManager.GetInstance().TableUsers.CreateUser(name, login, password);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommunicationEntities;
using DbWorker;
using DBEntities;
using Newtonsoft.Json;

namespace ServerWebApi.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public Response GetUserByLoginPassword([FromBody]Request request)
        {
            Dictionary<string, string> UsersParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.Parameters);

            string login = UsersParameters["login"];
            string password = UsersParameters["password"];

            User user = DbManager.GetInstance().TableUsers.GetUserByLoginPassword(login, password);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(user)
            };
        }

        [HttpPost]
        public Response GetUserByLogin([FromBody]Request request)
        {
            string login = request.Parameters;

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

        [HttpPost]
        public Response CreateUser([FromBody]Request request)
        {
            Dictionary<string, string> UsersParameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.Parameters);

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

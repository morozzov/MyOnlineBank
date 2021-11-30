using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClientLibrary;
using CommunicationEntities;

namespace WFClient.Model
{
    public class APIWorker
    {
        private static APIWorker instance = null;
        private Client client = null;
        private string APIKey;
        public static APIWorker GetInstance()
        {
            if (instance == null)
            {
                instance = new APIWorker();
            }
            return instance;
        }
        public APIWorker()
        {
            client = new Client();
            APIKey = "228papichNNN1337";
        }

        public Task<Response> UsersGetUserByLoginPasswordAsync(string login, string password)
        {
            Dictionary<string, string> userParams = new Dictionary<string, string>();
            userParams["login"] = login;
            userParams["password"] = password;

            Request request = new Request()
            {
                Command = "Users.GetUserByLoginPassword",
                Parameters = JsonConvert.SerializeObject(userParams),
                APIKey = APIKey
            };

            //return client.RecieveServerResponseAsync(request);
            return client.RecieveServerResponseAsyncNew(request, "Users/GetUserByLoginPassword");
        }

        public Task<Response> CardsGetCardsByUserId(int userID)
        {
            Request request = new Request()
            {
                Command = "Cards.GetCardsByUserId",
                Parameters = userID.ToString(),
                APIKey = APIKey
            };

            //return client.RecieveServerResponseAsync(request);
            return client.RecieveServerResponseAsyncNew(request, "Cards/GetCardsByUserId");
        }

        public Task<Response> SendMoney(int numberCardFrom, int numberCardTo, int moneyCount)
        {
            Request request = new Request()
            {
                Command = "Cards.SendMoney",
                Parameters = $"{numberCardFrom},{numberCardTo},{moneyCount}",
                APIKey = APIKey
            };

            //return client.RecieveServerResponseAsync(request);
            return client.RecieveServerResponseAsyncNew(request, "Cards/SendMoney");
        }

        public Task<Response> CreateNewCard(int number, int userId)
        {
            Request request = new Request()
            {
                Command = "Cards.CreateNewCard",
                Parameters = $"{number},{userId}",
                APIKey = APIKey
            };

            //return client.RecieveServerResponseAsync(request);
            return client.RecieveServerResponseAsyncNew(request, "Cards/CreateNewCard");
        }

        public Task<Response> GetCardByNumber(int number)
        {
            Request request = new Request()
            {
                Command = "Cards.GetCardByNumber",
                Parameters = number.ToString(),
                APIKey = APIKey
            };

            //return client.RecieveServerResponseAsync(request);
            return client.RecieveServerResponseAsyncNew(request, "Cards/GetCardByNumber");
        }

        public Task<Response> AddMoney(int number, int moneyCount)
        {
            Request request = new Request()
            {
                Command = "Cards.AddMoney",
                Parameters = $"{number},{moneyCount}",
                APIKey = APIKey
            };

            //return client.RecieveServerResponseAsync(request);
            return client.RecieveServerResponseAsyncNew(request, "Cards/AddMoney");
        }

        public Task<Response> UsersGetUserByLoginAsync(string login)
        {
            Request request = new Request()
            {
                Command = "Users.GetUserByLogin",
                Parameters = login,
                APIKey = APIKey
            };

            //return client.RecieveServerResponseAsync(request);
            return client.RecieveServerResponseAsyncNew(request, "Users/GetUserByLogin");
        }

        public Task<Response> CreateUser(string name, string login, string password)
        {
            Dictionary<string, string> userParams = new Dictionary<string, string>();
            userParams["name"] = name;
            userParams["login"] = login;
            userParams["password"] = password;

            Request request = new Request()
            {
                Command = "Users.CreateUser",
                Parameters = JsonConvert.SerializeObject(userParams),
                APIKey = APIKey
            };

            //return client.RecieveServerResponseAsync(request);
            return client.RecieveServerResponseAsyncNew(request, "Users/CreateUser");
        }
    }
}


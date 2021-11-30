using CommunicationEntities;
using DBEntities;
using DbWorker;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleServer.Controllers
{
    public class CardsController
    {

        public static Response GetCardsByUserId(string parameters)
        {
            int userID = int.Parse(parameters);

            List<Card> cards = DbManager.GetInstance().TableCards.GetCardsByUserId(userID);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(cards)
            };
        }

        public static Response SendMoney(string parameters)
        {
            int numberCardFrom = int.Parse(parameters.Split(',')[0]);
            int numberCardTo = int.Parse(parameters.Split(',')[1]);
            int moneyCount = int.Parse(parameters.Split(',')[2]);

            DbManager.GetInstance().TableCards.SendMoney(numberCardFrom, numberCardTo, moneyCount);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }

        public static Response CreateNewCard(string parameters)
        {
            int number = int.Parse(parameters.Split(',')[0]);
            int userId = int.Parse(parameters.Split(',')[1]);

            DbManager.GetInstance().TableCards.CreateNewCard(number, userId);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }

        public static Response GetCardByNumber(string parameters)
        {
            int number = int.Parse(parameters);

            DbManager.GetInstance().TableCards.GetCardByNumber(number);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }

        public static Response AddMoney(string parameters)
        {
            // массивы
            int number = int.Parse(parameters.Split(',')[0]);
            int moneyCount = int.Parse(parameters.Split(',')[1]);

            DbManager.GetInstance().TableCards.AddMoney(number, moneyCount);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }
    }
}

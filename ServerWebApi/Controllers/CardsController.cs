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
    public class CardsController : ApiController
    {
        [HttpPost]
        public Response GetCardsByUserId([FromBody]Request request)
        {
            int userID = int.Parse(request.Parameters);

            List<Card> cards = DbManager.GetInstance().TableCards.GetCardsByUserId(userID);

            return new Response()
            {
                Status = Response.StatusList.OK,
                Data = JsonConvert.SerializeObject(cards)
            };
        }

        [HttpPost]
        public Response SendMoney([FromBody]Request request)
        {
            int numberCardFrom = int.Parse(request.Parameters.Split(',')[0]);
            int numberCardTo = int.Parse(request.Parameters.Split(',')[1]);
            int moneyCount = int.Parse(request.Parameters.Split(',')[2]);

            DbManager.GetInstance().TableCards.SendMoney(numberCardFrom, numberCardTo, moneyCount);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }

        [HttpPost]
        public Response CreateNewCard([FromBody]Request request)
        {
            int number = int.Parse(request.Parameters.Split(',')[0]);
            int userId = int.Parse(request.Parameters.Split(',')[1]);

            DbManager.GetInstance().TableCards.CreateNewCard(number, userId);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }

        [HttpPost]
        public Response GetCardByNumber([FromBody]Request request)
        {
            int number = int.Parse(request.Parameters);

            try
            {
                DbManager.GetInstance().TableCards.GetCardByNumber(number);

                return new Response()
                {
                    Status = Response.StatusList.OK
                };
            }
            catch (Exception e)
            {
                return new Response()
                {
                    Status = Response.StatusList.ERROR,
                    Data = e.Message
                };
            }

        }

        [HttpPost]
        public Response AddMoney([FromBody]Request request)
        {
            // массивы
            int number = int.Parse(request.Parameters.Split(',')[0]);
            int moneyCount = int.Parse(request.Parameters.Split(',')[1]);

            DbManager.GetInstance().TableCards.AddMoney(number, moneyCount);

            return new Response()
            {
                Status = Response.StatusList.OK
            };
        }
    }
}

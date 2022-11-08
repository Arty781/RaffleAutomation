using Newtonsoft.Json;
using RaffleAutomationTests.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web
{
    public class WeeklyPrizesRequestWeb
    {
        public static CreateWeeklyPrizeOrderRequest RequestBuilder(string id)
        {
            CreateWeeklyPrizeOrderRequest req = new()
            {
                NumOfTickets = RandomHelper.RandomNumber(),
                PrizeType = "prize",
                PrizeId = id,
                TotalCost = 10
            };

            return req;
        }


        public static CreateWeeklyPrizeOrderResponse? AddWeeklyPrizes(SignInResponseModelWeb SignIn, WeeklyPrizesResponseModelWeb WeeklyId)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/orders", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");
            request.AddJsonBody(RequestBuilder(WeeklyId.Prizes[RandomHelper.RandomWPId(WeeklyId)].Id));

            var response = restDriver.Execute(request);
            var content = response.Content;
            var countdownResponse = JsonConvert.DeserializeObject<CreateWeeklyPrizeOrderResponse>(content);

            return countdownResponse;
        }
    }
}

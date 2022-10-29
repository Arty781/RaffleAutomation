using Newtonsoft.Json;
using RaffleAutomationTests.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb
{
    public class FixedOddsRequest
    {
        public static CreateFixedOddsOrderRequest RequestBuilder(string id)
        {
            CreateFixedOddsOrderRequest req = new()
            {
                NumOfTickets = RandomHelper.RandomNumber(),
                PrizeType = "fixedOdds",
                PrizeId = id,
                TotalCost = 10
            };

            return req;
        }

        public static GetFixedOddsOrderResponse GetFixedOddsPrizes()
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/fixedOdds", Method.Get);
            request.AddHeaders(headers: Headers.COMMON);

            var response = restDriver.Execute(request);
            var content = response.Content;
            var countdownResponse = JsonConvert.DeserializeObject<GetFixedOddsOrderResponse>(content);

            return countdownResponse;
        }

        public static GetFixedOddsOrderResponse AddFixedOddsPrizes(SignInResponseModelWeb SignIn, GetFixedOddsOrderResponse fixedPrizesId)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/orders", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");
            request.AddJsonBody(RequestBuilder(fixedPrizesId.FixedOdds[RandomHelper.RandomPrizeId(fixedPrizesId)].Id));

            var response = restDriver.Execute(request);
            var content = response.Content;
            var countdownResponse = JsonConvert.DeserializeObject<GetFixedOddsOrderResponse>(content);

            return countdownResponse;
        }
    }
}

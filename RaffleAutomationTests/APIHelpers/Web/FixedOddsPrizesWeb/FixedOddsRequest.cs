namespace RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb
{
    public class FixedOddsRequest
    {
        public static CreateFixedOddsOrderRequest RequestBuilder(string id)
        {
            CreateFixedOddsOrderRequest req = new()
            {
                NumOfTickets = "1",
                PrizeType = "fixedOdds",
                PrizeId = id,
                TotalCost = 10
            };

            return req;
        }

        public static List<string>? GetFixedOddsPrizes()
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest request = new RestRequest("/api/fixedOdds", Method.Get);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("applicationid", "WppJsNsSvr");

            var response = restDriver.Execute(request);
            var content = response.Content;
            var countdownResponse = JsonConvert.DeserializeObject<GetFixedOddsOrderResponse>(content);
            return (from fixedPrize in countdownResponse.FixedOdds
                    where (fixedPrize.MaxTickets - fixedPrize.TicketsBought) > 0
                    select fixedPrize.Id).ToList();
        }

        public static GetFixedOddsOrderResponse? AddFixedOddsPrizes(SignInResponseModelWeb SignIn, List<string> fixedPrizesId)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/orders", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");
            request.AddHeader("applicationid", "WppJsNsSvr");
            request.AddJsonBody(RequestBuilder(fixedPrizesId[RandomHelper.RandomFPId(fixedPrizesId)]));

            var response = restDriver.Execute(request);
            var content = response.Content;
            var countdownResponse = JsonConvert.DeserializeObject<GetFixedOddsOrderResponse>(content);

            return countdownResponse;
        }
    }
}

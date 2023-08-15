using RaffleAutomationTests.APIHelpers.Web.Basket;

namespace RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb
{
    public class FixedOddsRequest
    {
        public static string RequestBuilder(string id)
        {
            CreateFixedOddsOrderRequest req = new()
            {
                NumOfTickets = "1",
                PrizeType = "fixedOdds",
                PrizeId = id,
                TotalCost = 10
            };

            return JsonConvert.SerializeObject(req);
        }

        public static List<string>? GetFixedOddsPrizes()
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = "/api/fixedOdds",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            var countdownResponse = JsonConvert.DeserializeObject<GetFixedOddsOrderResponse>(resp.BodyStr);

            return (from fixedPrize in countdownResponse.FixedOdds
                    where (fixedPrize.MaxTickets - fixedPrize.TicketsBought) > 0
                    select fixedPrize.Id).ToList();
        }

        public static GetFixedOddsOrderResponse? AddFixedOddsPrizes(SignInResponseModelWeb SignIn, List<string> fixedPrizesId)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/orders",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.AddHeader("authorization", $"Bearer {SignIn.Token}");
            req.LoadBodyFromString(RequestBuilder(fixedPrizesId[RandomHelper.RandomFPId(fixedPrizesId)]), charset: "utf-8");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            var countdownResponse = JsonConvert.DeserializeObject<GetFixedOddsOrderResponse>(resp.BodyStr);

            return countdownResponse;
        }
    }
}

using RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb;

namespace RaffleAutomationTests.APIHelpers.Web.Weekly
{
    public class WeeklyPrizesRequestWeb
    {
        public static string RequestBuilder(string id, string number)
        {
            CreateWeeklyPrizeOrderRequest req = new()
            {
                NumOfTickets = number,
                PrizeType = "prize",
                PrizeId = id,
                TotalCost = 10
            };

            return JsonConvert.SerializeObject(req);
        }


        public static CreateWeeklyPrizeOrderResponse? AddWeeklyPrizes(SignInResponseModelWeb SignIn, WeeklyPrizesResponseModelWeb WeeklyId, string numOfTickets)
        {
            List<Prize> prizeId = (from prize in WeeklyId.Prizes where (prize.Title == "2 Night Yoga Retreat") select prize).ToList();

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
            req.LoadBodyFromString(RequestBuilder(prizeId.First().Id, numOfTickets), charset: "utf-8");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Console.WriteLine(http.LastErrorText);
            }
            var countdownResponse = JsonConvert.DeserializeObject<CreateWeeklyPrizeOrderResponse>(resp.BodyStr);

            return countdownResponse;
        }
    }
}

namespace RaffleAutomationTests.APIHelpers.Web.Weekly
{
    public class WeeklyPrizesRequestWeb
    {
        public static CreateWeeklyPrizeOrderRequest RequestBuilder(string id, string number)
        {
            CreateWeeklyPrizeOrderRequest req = new()
            {
                NumOfTickets = number,
                PrizeType = "prize",
                PrizeId = id,
                TotalCost = 10
            };

            return req;
        }


        public static CreateWeeklyPrizeOrderResponse? AddWeeklyPrizes(SignInResponseModelWeb SignIn, WeeklyPrizesResponseModelWeb WeeklyId, string numOfTickets)
        {
            List<Prize> prizeId = (from prize in WeeklyId.Prizes where (prize.Title == "2 Night Yoga Retreat") select prize).ToList();

            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/orders", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("applicationid", "WppJsNsSvr");
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");
            request.AddJsonBody(RequestBuilder(prizeId.First().Id, numOfTickets));

            var response = restDriver.Execute(request);
            var content = response.Content;
            var countdownResponse = JsonConvert.DeserializeObject<CreateWeeklyPrizeOrderResponse>(content);

            return countdownResponse;
        }
    }
}

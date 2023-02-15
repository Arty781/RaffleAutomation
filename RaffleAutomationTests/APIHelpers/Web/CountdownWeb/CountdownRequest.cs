namespace RaffleAutomationTests.APIHelpers.Web
{
    public class CountdownRequestWeb
    {
        public static List<CountdownResponseModelDreamHomeWeb?>? GetDreamHomeCountdown(SignInResponseModelWeb SignIn)
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"/api/raffles/active/countdowns/",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {SignIn.Token}");
            Http http = new();
            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
            var response = JsonConvert.DeserializeObject<List<CountdownResponseModelDreamHomeWeb?>>(resp.BodyStr);
            return response;
        }

        #region Weekly

        public static List<CompetitionResponseModelWeb>? GetWeeklyPrizesCompetitionId(SignInResponseModelWeb SignIn)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/competitions/countdowns", Method.Get);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");

            var response = restDriver.Execute(request);
            var content = response.Content;
            var countdownResponse = JsonConvert.DeserializeObject<List<CompetitionResponseModelWeb>>(content);

            return countdownResponse;
        }

        public static WeeklyPrizesRequest RequestBuilder(string id, int i)
        {
            WeeklyPrizesRequest req = new()
            {
                PageNumber = i,
                PageCount = 100,
                CategoryId = "",
                SubCategoryId = "[]",
                Sort = "0",
                Id = id
            };

            return req;
        }


        public static WeeklyPrizesResponseModelWeb? GetWeeklyPrizes(SignInResponseModelWeb SignIn, string WeeklyId)
        {
            WeeklyPrizesResponseModelWeb? countdownResponse = null;
            for (int i = 0; i < 2; i++)
            {
                var restDriver = new RestClient(ApiEndpoints.API);
                RestRequest? request = new RestRequest("/api/prizes/web", Method.Post);
                request.AddHeaders(headers: Headers.COMMON);
                request.AddHeader("authorization", $"Bearer {SignIn.Token}");
                request.AddJsonBody(RequestBuilder(WeeklyId, i));

                var response = restDriver.Execute(request);
                var content = response.Content;
                countdownResponse = JsonConvert.DeserializeObject<WeeklyPrizesResponseModelWeb>(content);



            }


            return countdownResponse;
        }

        #endregion
    }
}

using RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb;

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
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {SignIn.Token}");
            Http http = new();
            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
            var response = JsonConvert.DeserializeObject<List<CountdownResponseModelDreamHomeWeb?>>(resp.BodyStr);
            return response;
        }

        #region Weekly

        public static List<CompetitionResponseModelWeb>? GetWeeklyPrizesCompetitionId(SignInResponseModelWeb SignIn)
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"/api/competitions/countdowns",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {SignIn.Token}");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            var countdownResponse = JsonConvert.DeserializeObject<List<CompetitionResponseModelWeb>>(resp.BodyStr);

            return countdownResponse;
        }

        public static string RequestBuilder(string id, int i)
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

            return JsonConvert.SerializeObject(req);
        }


        public static WeeklyPrizesResponseModelWeb? GetWeeklyPrizes(SignInResponseModelWeb SignIn, string WeeklyId)
        {
            WeeklyPrizesResponseModelWeb? countdownResponse = null;
            for (int i = 0; i < 2; i++)
            {
                HttpRequest req = new()
                {
                    HttpVerb = "POST",
                    Path = "/api/prizes/web",
                };

                req.AddHeader("connection", "Keep-Alive");
                req.AddHeader("accept-encoding", "gzip, deflate, br");
                req.AddHeader("applicationid", "WppJsNsSvr");
                req.AddHeader("accept", "application/json, text/plain, */*");
                req.AddHeader("content-type", "application/json");
                req.AddHeader("authorization", $"Bearer {SignIn.Token}");
                req.LoadBodyFromString(RequestBuilder(WeeklyId, i), charset: "utf-8");

                Http http = new Http();

                HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
                if (http.LastMethodSuccess != true)
                {
                    throw new ArgumentException(http.LastErrorText);
                }
                countdownResponse = JsonConvert.DeserializeObject<WeeklyPrizesResponseModelWeb>(resp.BodyStr);

            }


            return countdownResponse;
        }

        #endregion
    }
}

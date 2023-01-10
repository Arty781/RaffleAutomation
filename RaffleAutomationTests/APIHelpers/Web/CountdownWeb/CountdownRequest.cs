using Newtonsoft.Json;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.Helpers;
using RestSharp;
using System.Collections.Generic;

namespace RaffleAutomationTests.APIHelpers.Web
{
    public class CountdownRequestWeb
    {
        public static CountdownResponseModelDreamHomeWeb? GetDreamHomeCountdown(SignInResponseModelWeb SignIn)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("api/raffles/active/countdowns/", Method.Get);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");

            RestResponse response = restDriver.Execute(request);
            string content = response.Content.Replace("[{", "{").Replace("}]", "}");
            var countdownResponse = JsonConvert.DeserializeObject<CountdownResponseModelDreamHomeWeb>(content);

            return countdownResponse;
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

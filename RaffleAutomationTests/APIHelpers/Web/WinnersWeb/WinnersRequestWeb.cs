namespace RaffleAutomationTests.APIHelpers.Web.WinnersWeb
{
    public partial class WinnersRequest
    {
        public static WinnerResponse? GetAllWinners()
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"api/winners/web?pageNumber=1&pageCount=1000&year="
            };

            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            var response = JsonConvert.DeserializeObject<WinnerResponse>(resp.BodyStr);
            return response;
        }

        public static WinnerResponse? GetAllWinnersByYear(int year)
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"api/winners/web?pageNumber=1&pageCount=1000&year={year}"
            };

            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            var response = JsonConvert.DeserializeObject<WinnerResponse>(resp.BodyStr);
            return response;
        }
    }
}

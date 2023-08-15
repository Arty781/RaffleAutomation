using RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb;

namespace RaffleAutomationTests.APIHelpers.Web
{
    public class EmailRequest
    {
        public static EmailRequest? AddDreamhomeTickets(string email)
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = "/api/orders",
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
            var response = JsonConvert.DeserializeObject<EmailRequest>(resp.BodyStr);

            return response;
        }
    }
}

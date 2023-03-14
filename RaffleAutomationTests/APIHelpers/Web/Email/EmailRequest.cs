namespace RaffleAutomationTests.APIHelpers.Web
{
    public class EmailRequest
    {
        public static EmailRequest? AddDreamhomeTickets(string email)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/orders", Method.Get);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("applicationid", "WppJsNsSvr");


            var r = restDriver.Execute(request);
            var content = r.Content;

            var response = JsonConvert.DeserializeObject<EmailRequest>(content);

            return response;
        }
    }
}

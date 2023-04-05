using RaffleAutomationTests.APIHelpers.Admin.DreamHomePage;
using RaffleAutomationTests.APIHelpers.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web.Subscriptions
{
    public class SubscriptionsRequest
    {
        public static SubsriptionsResponse.Subscriptions? GetActiveSubscriptions()
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"/api/subscription-models/active",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            var response = JsonConvert.DeserializeObject<SubsriptionsResponse.Subscriptions> (resp.BodyStr);
            return response;
        }
    }
}

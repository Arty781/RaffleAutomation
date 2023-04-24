using RaffleAutomationTests.APIHelpers.Admin.DreamHomePage;
using RaffleAutomationTests.APIHelpers.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RaffleAutomationTests.Helpers.AppDbHelper;
using System.Threading;

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

        public static void CheckStatusFor17Minutes(DbModels.Subscriptions userSub, DbModels.User user)
        {
            DateTime startTime = DateTime.Now;
            int checkInterval = 60000; // in milliseconds
            bool statusChanged = false;
            int minutes = 17;

            while (DateTime.Now - startTime < TimeSpan.FromMinutes(minutes)) // loop for 15 minutes
            {
                if (userSub.Status != "FINISHED")
                {
                    Thread.Sleep(checkInterval); // wait for 60 seconds before checking again
                    userSub = AppDbHelper.Subscriptions.GetSubscriptionByUserId(user);
                }
                else
                {
                    statusChanged = true;
                    Console.WriteLine("Subscription status is FINISHED.");
                    break; // exit the loop since the status has changed
                }
            }

            if (!statusChanged)
            {
                throw new Exception($"Subscription status did not change within {minutes} minutes.");
            }
        }
    }
}

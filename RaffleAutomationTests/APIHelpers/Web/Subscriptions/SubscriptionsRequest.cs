using System.Threading;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;
using System.Linq;
using static RaffleAutomationTests.APIHelpers.Web.Subscriptions.SubsriptionsResponse;

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
                throw new ArgumentException(http.LastErrorText);
            }
            
            var response = JsonConvert.DeserializeObject<SubsriptionsResponse.Subscriptions> (resp.BodyStr);
            return response;
        }

        public static SubsriptionsResponse.EmailsList? GetEmailsCount(string email)
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"/{email.Substring(0, email.IndexOf('@'))}/requests_count",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("putsbox.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }

            // Split the input string into event and data parts
            string[] parts = resp.BodyStr.Split('\n');
            string eventData = parts[1].Substring("data: ".Length);

            // Parse the JSON data using Newtonsoft.Json
            JObject data = JObject.Parse(eventData);

            // Create a new JObject for the final result
            JObject result = new JObject();
            result["event"] = parts[0].Substring("event: ".Length);
            result["data"] = data;

            // Convert the JObject to JSON string
            string json = JsonConvert.SerializeObject(result, Formatting.Indented);
            var response = JsonConvert.DeserializeObject<SubsriptionsResponse.EmailsList>(json);
            return response;
        }

        public static void CheckStatusFor17Minutes(DbModels.Subscriptions userSub, DbModels.UserResponse user)
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

        public static void CheckEmailsCountFor35Minutes(List<PutsboxEmail>? userEmails, string email)
        {
            DateTime startTime = DateTime.Now;
            int checkInterval = 30000; // in milliseconds
            bool statusChanged = false;
            int minutes = 35;

            while (DateTime.Now - startTime < TimeSpan.FromMinutes(minutes)) // loop for 15 minutes
            {
                switch (userEmails.Any(x => x != null && !x.subject.Contains("How many stars would you give")))
                {
                    case false:
                        Thread.Sleep(checkInterval); // wait for 30 seconds before checking again
                        PutsBox.GetAllEmails(email, out userEmails);
                        break;

                    case true:
                        statusChanged = true;
                        goto LoopExit; // exit the loop since the status has changed

                }

            
            }
            LoopExit:
            // Continue with the rest of the code outside the switch statement            
            if (!statusChanged)
            {
                throw new Exception($"Subscription status did not change within {minutes} minutes.");
            }
        }

        public static void ParseHTML(string html)
        {
            // Load the HTML document from a string
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Create a JSON object
            dynamic jsonObj = new Newtonsoft.Json.Linq.JObject();

            // Traverse the HTML document and add nodes to the JSON object
            HtmlNode root = doc.DocumentNode;
            TraverseNodes(root, jsonObj);

            // Convert the JSON object to a string
            string jsonStr = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            Console.WriteLine(jsonStr);

            // Helper method to traverse HTML nodes and add them to the JSON object
            void TraverseNodes(HtmlNode node, dynamic obj)
            {
                switch (node.NodeType)
                {
                    case HtmlNodeType.Document:
                        TraverseNodes(node, obj);
                        break;
                    case HtmlNodeType.Element:
                        dynamic elemObj = new Newtonsoft.Json.Linq.JObject();
                        obj[node.Name] = elemObj;
                        foreach (var attr in node.Attributes)
                        {
                            elemObj[attr.Name] = attr.Value;
                        }
                        foreach (var childNode in node.ChildNodes)
                        {
                            TraverseNodes(childNode, elemObj);
                        }
                        break;
                    case HtmlNodeType.Text:
                        obj["text"] = node.InnerText;
                        break;
                    case HtmlNodeType.Comment:
                        obj["comment"] = node.InnerText;
                        break;
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web.Subscriptions
{
    public class SubsriptionsResponse
    {

        public partial class Subscriptions
        {
            [JsonProperty("subscriptionModels")]
            public List<SubscriptionModel> SubscriptionModels { get; set; }
        }

        public partial class SubscriptionModel
        {
            [JsonProperty("totalCost")]
            public int? TotalCost { get; set; }

            [JsonProperty("isActive")]
            public bool? IsActive { get; set; }

            [JsonProperty("createdAt")]
            public DateTimeOffset? CreatedAt { get; set; }

            [JsonProperty("_id")]
            public string? Id { get; set; }

            [JsonProperty("numOfTickets")]
            public int? NumOfTickets { get; set; }

            [JsonProperty("extra")]
            public int? Extra { get; set; }

            [JsonProperty("__v")]
            public int? V { get; set; }
        }

        public partial class EmailsList
        {
            [JsonProperty("event")]
            public string Event { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public partial class Data
        {
            [JsonProperty("emails_count")]
            public long EmailsCount { get; set; }

            [JsonProperty("emails")]
            public List<Email>? Emails { get; set; }
        }

        public class Email
        {
            public string? id { get; set; }
            public string? from_email { get; set; }
            public string? from_name { get; set; }
            public List<string>? to { get; set; }
            public string? email { get; set; }
            public string? subject { get; set; }
            public DateTime? created_at { get; set; }
        }

    }
}

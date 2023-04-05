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
    }
}

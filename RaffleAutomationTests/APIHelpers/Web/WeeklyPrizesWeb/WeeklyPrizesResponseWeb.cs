using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web
{
    public partial class CreateWeeklyPrizeOrderRequest
    {
        [JsonProperty("numOfTickets")]
        public string NumOfTickets { get; set; }

        [JsonProperty("prizeType")]
        public string PrizeType { get; set; }

        [JsonProperty("prizeId")]
        public string PrizeId { get; set; }

        [JsonProperty("totalCost")]
        public double TotalCost { get; set; }
    }

    public partial class CreateWeeklyPrizeOrderResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }
    }

}

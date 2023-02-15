namespace RaffleAutomationTests.APIHelpers.Web
{

    public class DreamHomeOrderRequestModel
    {
        [JsonProperty("numOfTickets")]
        public string NumOfTickets { get; set; }

        [JsonProperty("prizeType")]
        public string PrizeType { get; set; }

        [JsonProperty("prizeId")]
        public string PrizeId { get; set; }
    }

    public class DreamHomeOrderResponseModelWeb
    {

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }
    }
}


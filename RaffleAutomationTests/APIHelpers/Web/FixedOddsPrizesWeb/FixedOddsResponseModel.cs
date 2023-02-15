namespace RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb
{

    public partial class CreateFixedOddsOrderRequest
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


    public partial class GetFixedOddsOrderResponse
    {
        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("fixedOdds")]
        public List<FixedOdd> FixedOdds { get; set; }

        [JsonProperty("oddsEndsAt")]
        public DateTimeOffset OddsEndsAt { get; set; }

        [JsonProperty("popularAndTrendingFixOdds")]
        public List<PopularAndTrendingFixOdd> PopularAndTrendingFixOdds { get; set; }

        [JsonProperty("allCount")]
        public long AllCount { get; set; }
    }

    [JsonObject]
    public partial class FixedOdd
    {
        [JsonProperty("photoUrlKeys")]
        public List<string> PhotoUrlKeys { get; set; }

        [JsonProperty("photoUrlKeysMobile")]
        public List<string> PhotoUrlKeysMobile { get; set; }

        [JsonProperty("ticketsBought")]
        public long TicketsBought { get; set; }

        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("discountTicket")]
        public DiscountTicket DiscountTicket { get; set; }

        [JsonProperty("maxTickets")]
        public long MaxTickets { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }

        [JsonProperty("activatedDate")]
        public DateTimeOffset ActivatedDate { get; set; }
    }

    public partial class DiscountTicket
    {
        [JsonProperty("percent")]
        public long Percent { get; set; }

        [JsonProperty("newPrice")]
        public long NewPrice { get; set; }
    }

    public partial class PopularAndTrendingFixOdd
    {
        [JsonProperty("photoUrlKeys")]
        public List<string> PhotoUrlKeys { get; set; }

        [JsonProperty("photoUrlKeysMobile")]
        public List<string> PhotoUrlKeysMobile { get; set; }

        [JsonProperty("discountRates")]
        public List<object> DiscountRates { get; set; }

        [JsonProperty("isPopular")]
        public bool IsPopular { get; set; }

        [JsonProperty("ticketsBought")]
        public long TicketsBought { get; set; }

        [JsonProperty("isTrending")]
        public bool IsTrending { get; set; }

        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("isDiscountRates")]
        public bool IsDiscountRates { get; set; }

        [JsonProperty("creditsRates")]
        public List<CreditsRate> CreditsRates { get; set; }

        [JsonProperty("isCreditsActive")]
        public bool IsCreditsActive { get; set; }

        [JsonProperty("isRemoved")]
        public bool IsRemoved { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("discountCategory")]
        public string DiscountCategory { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("defaultTickets")]
        public long DefaultTickets { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("discountTicket")]
        public DiscountTicket DiscountTicket { get; set; }

        [JsonProperty("maxTickets")]
        public long MaxTickets { get; set; }

        [JsonProperty("creditsEndDate")]
        public DateTimeOffset CreditsEndDate { get; set; }

        [JsonProperty("creditsStartDate")]
        public DateTimeOffset CreditsStartDate { get; set; }

        [JsonProperty("isCreditsPermanent")]
        public bool IsCreditsPermanent { get; set; }

        [JsonProperty("startAt")]
        public DateTimeOffset StartAt { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }

        [JsonProperty("activatedDate")]
        public DateTimeOffset ActivatedDate { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("metaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("metaTitle")]
        public string MetaTitle { get; set; }
    }

    public partial class CreditsRate
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("percent")]
        public long Percent { get; set; }
    }

    public partial class GetFixedOddsOrderResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }
    }

}

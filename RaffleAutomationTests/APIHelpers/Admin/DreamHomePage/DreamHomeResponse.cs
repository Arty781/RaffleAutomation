namespace RaffleAutomationTests.APIHelpers.Admin.DreamHomePage
{
    [JsonObject]
    public class CreateDreamHomeRequestModel
    {
        [JsonProperty("stepperCountdown")]
        public StepperCountdown StepperCountdown { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("isPopular")]
        public bool IsPopular { get; set; }

        [JsonProperty("isTrending")]
        public bool IsTrending { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }

        [JsonProperty("startAt")]
        public DateTimeOffset StartAt { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("defaultTickets")]
        public long DefaultTickets { get; set; }

        [JsonProperty("isDiscountRates")]
        public bool IsDiscountRates { get; set; }

        [JsonProperty("creditsRates")]
        public List<CreditsRate> CreditsRates { get; set; }

        //[JsonProperty("creditsEndDate")]
        //public DateTimeOffset CreditsEndDate { get; set; }

        //[JsonProperty("creditsStartDate")]
        //public DateTimeOffset CreditsStartDate { get; set; }

        [JsonProperty("isCreditsActive")]
        public bool IsCreditsActive { get; set; }

        //[JsonProperty("isCreditsPermanent")]
        //public bool IsCreditsPermanent { get; set; }

        [JsonProperty("discountRates")]
        public List<DiscountRate> DiscountRates { get; set; }

        [JsonProperty("discountTicket")]
        public DiscountTicket DiscountTicket { get; set; }

        [JsonProperty("discountCategory")]
        public string DiscountCategory { get; set; }

        [JsonProperty("freeTicketsRates")]
        public List<object> FreeTicketsRates { get; set; }

        [JsonProperty("isFreeTicketsRates")]
        public bool IsFreeTicketsRates { get; set; }

        [JsonProperty("ticketsBundles")]
        public List<long> TicketsBundles { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("metaTitle")]
        public string MetaTitle { get; set; }

        [JsonProperty("metaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("property")]
        public string? Property { get; set; }
    }

    [JsonObject]
    public class DreamHomeRequestModel
    {
        [JsonProperty("stepperCountdown")]
        public StepperCountdown StepperCountdown { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("isPopular")]
        public bool IsPopular { get; set; }

        [JsonProperty("isTrending")]
        public bool IsTrending { get; set; }

        [JsonProperty("endsAt")]
        public string EndsAt { get; set; }

        [JsonProperty("startAt")]
        public string StartAt { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("defaultTickets")]
        public long DefaultTickets { get; set; }

        [JsonProperty("isDiscountRates")]
        public bool IsDiscountRates { get; set; }

        [JsonProperty("creditsRates")]
        public List<CreditsRate> CreditsRates { get; set; }

        [JsonProperty("creditsEndDate")]
        public string CreditsEndDate { get; set; }

        [JsonProperty("creditsStartDate")]
        public string CreditsStartDate { get; set; }

        [JsonProperty("isCreditsActive")]
        public bool IsCreditsActive { get; set; }

        [JsonProperty("isCreditsPermanent")]
        public bool IsCreditsPermanent { get; set; }

        [JsonProperty("discountRates")]
        public List<DiscountRate>? DiscountRates { get; set; }

        [JsonProperty("discountTicket")]
        public DiscountTicket DiscountTicket { get; set; }

        [JsonProperty("discountCategory")]
        public string DiscountCategory { get; set; }

        [JsonProperty("freeTicketsRates")]
        public string[] FreeTicketsRates { get; set; }

        [JsonProperty("isFreeTicketsRates")]
        public bool IsFreeTicketsRates { get; set; }

        [JsonProperty("ticketsBundles")]
        public List<long>? TicketsBundles { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("metaTitle")]
        public string MetaTitle { get; set; }

        [JsonProperty("metaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("isClosed")]
        public bool IsClosed { get; set; }
    }


    [JsonObject]
    public class DreamHomeResponse
    {
        [JsonProperty("raffles")]
        public List<Raffle> Raffles { get; set; }
    }


    public class Raffle
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("defaultTickets")]
        public long DefaultTickets { get; set; }

        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("isDiscountRates")]
        public bool IsDiscountRates { get; set; }

        [JsonProperty("isClosed")]
        public bool IsClosed { get; set; }

        [JsonProperty("isPopular")]
        public bool IsPopular { get; set; }

        [JsonProperty("isTrending")]
        public bool IsTrending { get; set; }

        [JsonProperty("isRemoved")]
        public bool IsRemoved { get; set; }

        [JsonProperty("creditsRates")]
        public List<CreditsRate>? CreditsRates { get; set; }

        [JsonProperty("isCreditsActive")]
        public bool IsCreditsActive { get; set; }

        [JsonProperty("discountRates")]
        public List<DiscountRate>? DiscountRates { get; set; }

        [JsonProperty("freeTicketsRates")]
        public List<object> FreeTicketsRates { get; set; }

        [JsonProperty("isFreeTicketsRates")]
        public bool IsFreeTicketsRates { get; set; }

        [JsonProperty("ticketsBundles")]
        public List<long>? TicketsBundles { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }

        [JsonProperty("startAt")]
        public DateTimeOffset StartAt { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("property")]
        public Property Property { get; set; }

        [JsonProperty("creditsEndDate")]
        public DateTimeOffset CreditsEndDate { get; set; }

        [JsonProperty("creditsStartDate")]
        public DateTimeOffset CreditsStartDate { get; set; }

        [JsonProperty("isCreditsPermanent")]
        public bool IsCreditsPermanent { get; set; }

        [JsonProperty("discountTicket")]
        public DiscountTicket DiscountTicket { get; set; }

        [JsonProperty("discountCategory")]
        public string DiscountCategory { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("metaTitle")]
        public string MetaTitle { get; set; }

        [JsonProperty("metaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    public class RaffleResponse
    {
        [JsonProperty("raffles")]
        public List<Raffles> Raffles { get; set; }
    }

    public class Raffles
    {

        [JsonProperty("stepperCountdown")]
        public StepperCountdown StepperCountdown { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("defaultTickets")]
        public long DefaultTickets { get; set; }

        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("isDiscountRates")]
        public bool IsDiscountRates { get; set; }

        [JsonProperty("isClosed")]
        public bool IsClosed { get; set; }

        [JsonProperty("isPopular")]
        public bool IsPopular { get; set; }

        [JsonProperty("isTrending")]
        public bool IsTrending { get; set; }

        [JsonProperty("isRemoved")]
        public bool IsRemoved { get; set; }

        [JsonProperty("creditsRates")]
        public List<CreditsRate>? CreditsRates { get; set; }

        [JsonProperty("isCreditsActive")]
        public bool IsCreditsActive { get; set; }

        [JsonProperty("discountRates")]
        public List<DiscountRate>? DiscountRates { get; set; }

        [JsonProperty("freeTicketsRates")]
        public List<object> FreeTicketsRates { get; set; }

        [JsonProperty("isFreeTicketsRates")]
        public bool IsFreeTicketsRates { get; set; }

        [JsonProperty("ticketsBundles")]
        public List<long>? TicketsBundles { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("endsAt")]
        public DateTime EndsAt { get; set; }

        [JsonProperty("startAt")]
        public DateTime StartAt { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("creditsEndDate")]
        public DateTime CreditsEndDate { get; set; }

        [JsonProperty("creditsStartDate")]
        public DateTime CreditsStartDate { get; set; }

        [JsonProperty("isCreditsPermanent")]
        public bool IsCreditsPermanent { get; set; }

        [JsonProperty("discountTicket")]
        public DiscountTicket DiscountTicket { get; set; }

        [JsonProperty("discountCategory")]
        public string DiscountCategory { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("metaTitle")]
        public string MetaTitle { get; set; }

        [JsonProperty("metaDescription")]
        public string MetaDescription { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }


    public class StepperCountdown
    {
        [JsonProperty("isActive")]
        public bool isActive { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("startAt")]
        public DateTime startAt { get; set; }

        [JsonProperty("endsAt")]
        public DateTime endsAt { get; set; }
    }

    public class CreditsRate
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("count")]
        public long? Count { get; set; }

        [JsonProperty("percent")]
        public long? Percent { get; set; }
    }

    public class DiscountRate
    {
        [JsonProperty("amountTickets")]
        public long AmountTickets { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }

        [JsonProperty("newPrice")]
        public double NewPrice { get; set; }
    }

    public class DiscountTicket
    {
        [JsonProperty("percent")]
        public long Percent { get; set; }

        [JsonProperty("newPrice")]
        public long NewPrice { get; set; }
    }

    public class Property
    {
        [JsonProperty("galleryImages")]
        public List<string>? GalleryImages { get; set; }

        [JsonProperty("galleryImagesMobile")]
        public List<string>? GalleryImagesMobile { get; set; }

        [JsonProperty("overview")]
        public List<Overview> Overview { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("floorPlanImage")]
        public string FloorPlanImage { get; set; }

        [JsonProperty("badroomImage")]
        public string BadroomImage { get; set; }

        [JsonProperty("bathroomImage")]
        public string BathroomImage { get; set; }

        [JsonProperty("outspaceImage")]
        public string OutspaceImage { get; set; }

        [JsonProperty("cardImage")]
        public string CardImage { get; set; }

        [JsonProperty("bathroomText")]
        public string BathroomText { get; set; }

        [JsonProperty("bedroomText")]
        public string BedroomText { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("outspaceText")]
        public string OutspaceText { get; set; }

        [JsonProperty("pixangleSource")]
        public string PixangleSource { get; set; }

        [JsonProperty("generalText")]
        public string GeneralText { get; set; }

        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("tourLink")]
        public string TourLink { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    public class Overview
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public partial class PropertyResponse
    {
        [JsonProperty("galleryImages")]
        public List<string>? GalleryImages { get; set; }

        [JsonProperty("galleryImagesMobile")]
        public List<string>? GalleryImagesMobile { get; set; }

        [JsonProperty("overview")]
        public List<Overview> Overview { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("floorPlanImage")]
        public string? FloorPlanImage { get; set; }

        [JsonProperty("badroomImage")]
        public string? BadroomImage { get; set; }

        [JsonProperty("bathroomImage")]
        public string? BathroomImage { get; set; }

        [JsonProperty("outspaceImage")]
        public string? OutspaceImage { get; set; }

        [JsonProperty("cardImage")]
        public string? CardImage { get; set; }

        [JsonProperty("bathroomText")]
        public string BathroomText { get; set; }

        [JsonProperty("bedroomText")]
        public string BedroomText { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("outspaceText")]
        public string OutspaceText { get; set; }

        [JsonProperty("pixangleSource")]
        public string? PixangleSource { get; set; }

        [JsonProperty("generalText")]
        public string GeneralText { get; set; }

        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("tourLink")]
        public string? TourLink { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    [JsonObject]
    public class PropertyRequest
    {
        [JsonProperty("galleryImages")]
        public List<string>? GalleryImages { get; set; }

        [JsonProperty("galleryImagesMobile")]
        public List<string>? GalleryImagesMobile { get; set; }

        [JsonProperty("overview")]
        public List<Overview> Overview { get; set; }

        [JsonProperty("floorPlanImage")]
        public string FloorPlanImage { get; set; }

        [JsonProperty("badroomImage")]
        public string BadroomImage { get; set; }

        [JsonProperty("bathroomImage")]
        public string BathroomImage { get; set; }

        [JsonProperty("outspaceImage")]
        public string OutspaceImage { get; set; }

        [JsonProperty("cardImage")]
        public string CardImage { get; set; }

        [JsonProperty("bathroomText")]
        public string BathroomText { get; set; }

        [JsonProperty("bedroomText")]
        public string BedroomText { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("outspaceText")]
        public string OutspaceText { get; set; }

        [JsonProperty("pixangleSource")]
        public string PixangleSource { get; set; }

        [JsonProperty("generalText")]
        public string GeneralText { get; set; }

        [JsonProperty("heading")]
        public string Heading { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("tourLink")]
        public string TourLink { get; set; }
    }
}

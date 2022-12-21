using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web.Basket
{
    public class GetBasketOrdersRequest
    {
        [JsonProperty("couponId")]
        public object CouponId { get; set; }

        [JsonProperty("isApplyCredit")]
        public bool IsApplyCredit { get; set; }
    }

    public class CreateBasketRequest
    {
       [JsonProperty("order")]
       public string Order { get; set; }
    }

    public class CreateBasketResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }


    public partial class GetBasketOrdersResponse
    {
        [JsonProperty("basketOrders")]
        public List<BasketOrder> BasketOrders { get; set; }

        [JsonProperty("availableUserCreditsNumber")]
        public double AvailableUserCreditsNumber { get; set; }

        [JsonProperty("generalSettings")]
        public GeneralSettings GeneralSettings { get; set; }

        [JsonProperty("basketTotalCost")]
        public double BasketTotalCost { get; set; }

        [JsonProperty("earnedCredits")]
        public long EarnedCredits { get; set; }

        [JsonProperty("coupon")]
        public object Coupon { get; set; }

        [JsonProperty("totalSaving")]
        public long TotalSaving { get; set; }

        [JsonProperty("spentCredits")]
        public long SpentCredits { get; set; }

        [JsonProperty("bannerWeeklyPrize")]
        public BannerWeeklyPrize BannerWeeklyPrize { get; set; }
    }

    public partial class BannerWeeklyPrize
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("ticketPrice")]
        public long TicketPrice { get; set; }
    }

    public partial class BasketOrder
    {
        [JsonProperty("raffleTicketPrice")]
        public double RaffleTicketPrice { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("totalCost")]
        public long TotalCost { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("numberOfTickets")]
        public long NumberOfTickets { get; set; }

        [JsonProperty("prizeType")]
        public string PrizeType { get; set; }

        [JsonProperty("photoUrlKey")]
        public string PhotoUrlKey { get; set; }

        [JsonProperty("bonusTickets")]
        public long BonusTickets { get; set; }

        [JsonProperty("prize")]
        public Prize Prize { get; set; }
    }

    public partial class Prize
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("photoUrlKeys", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PhotoUrlKeys { get; set; }

        [JsonProperty("photoUrlKeysMobile", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PhotoUrlKeysMobile { get; set; }

        [JsonProperty("discountRates")]
        public List<DiscountRate> DiscountRates { get; set; }

        [JsonProperty("isPopular")]
        public bool IsPopular { get; set; }

        [JsonProperty("ticketsBought", NullValueHandling = NullValueHandling.Ignore)]
        public long? TicketsBought { get; set; }

        [JsonProperty("isTrending")]
        public bool IsTrending { get; set; }

        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("isDiscountRates")]
        public bool IsDiscountRates { get; set; }

        [JsonProperty("creditsRates")]
        public List<PrizeCreditsRate> CreditsRates { get; set; }

        [JsonProperty("isCreditsActive")]
        public bool IsCreditsActive { get; set; }

        [JsonProperty("isRemoved")]
        public bool IsRemoved { get; set; }

        [JsonProperty("discountCategory")]
        public string DiscountCategory { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("defaultTickets")]
        public long DefaultTickets { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("discountTicket")]
        public DiscountTicket DiscountTicket { get; set; }

        [JsonProperty("maxTickets", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxTickets { get; set; }

        [JsonProperty("creditsEndDate")]
        public DateTimeOffset CreditsEndDate { get; set; }

        [JsonProperty("creditsStartDate")]
        public DateTimeOffset CreditsStartDate { get; set; }

        [JsonProperty("isCreditsPermanent")]
        public bool IsCreditsPermanent { get; set; }

        [JsonProperty("startAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartAt { get; set; }

        [JsonProperty("endsAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EndsAt { get; set; }

        [JsonProperty("activatedDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ActivatedDate { get; set; }

        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public string Subtitle { get; set; }

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

        [JsonProperty("isClosed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsClosed { get; set; }

        [JsonProperty("freeTicketsRates", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> FreeTicketsRates { get; set; }

        [JsonProperty("isFreeTicketsRates", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsFreeTicketsRates { get; set; }

        [JsonProperty("ticketsBundles", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> TicketsBundles { get; set; }

        [JsonProperty("property", NullValueHandling = NullValueHandling.Ignore)]
        public Property Property { get; set; }

        [JsonProperty("prizeCategory", NullValueHandling = NullValueHandling.Ignore)]
        public string PrizeCategory { get; set; }

        [JsonProperty("subCategory", NullValueHandling = NullValueHandling.Ignore)]
        public string SubCategory { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Overview { get; set; }
    }

    public partial class PrizeCreditsRate
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("percent")]
        public long Percent { get; set; }
    }

    public partial class DiscountRate
    {
        [JsonProperty("amountTickets")]
        public long AmountTickets { get; set; }

        [JsonProperty("percent")]
        public double Percent { get; set; }

        [JsonProperty("newPrice")]
        public double NewPrice { get; set; }
    }

    public partial class DiscountTicket
    {
        [JsonProperty("percent")]
        public long Percent { get; set; }

        [JsonProperty("newPrice")]
        public double NewPrice { get; set; }
    }

    public partial class Property
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("galleryImages")]
        public List<string> GalleryImages { get; set; }

        [JsonProperty("galleryImagesMobile")]
        public List<string> GalleryImagesMobile { get; set; }

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
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("tourLink")]
        public Uri TourLink { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    public partial class Overview
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public partial class GeneralSettings
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("creditsRates")]
        public List<GeneralSettingsCreditsRate> CreditsRates { get; set; }

        [JsonProperty("discountRates")]
        public DiscountRates DiscountRates { get; set; }

        [JsonProperty("isDiscountRates")]
        public IsDiscountRates IsDiscountRates { get; set; }

        [JsonProperty("isCreditsRates")]
        public bool IsCreditsRates { get; set; }

        [JsonProperty("freeTicketsRates")]
        public List<FreeTicketsRate> FreeTicketsRates { get; set; }

        [JsonProperty("isFreeTicketsRates")]
        public bool IsFreeTicketsRates { get; set; }
    }

    public partial class GeneralSettingsCreditsRate
    {
        [JsonProperty("count")]
        public double Count { get; set; }

        [JsonProperty("percent")]
        public long Percent { get; set; }
    }

    public partial class DiscountRates
    {
        [JsonProperty("raffle")]
        public List<object> Raffle { get; set; }

        [JsonProperty("prize")]
        public List<FixedOdd> Prize { get; set; }

        [JsonProperty("fixedOdds")]
        public List<FixedOdd> FixedOdds { get; set; }
    }

    public partial class FixedOdd
    {
        [JsonProperty("amountTickets")]
        public long AmountTickets { get; set; }

        [JsonProperty("percent")]
        public long Percent { get; set; }
    }

    public partial class FreeTicketsRate
    {
        [JsonProperty("tickets")]
        public long Tickets { get; set; }

        [JsonProperty("extra")]
        public long Extra { get; set; }
    }

    public partial class IsDiscountRates
    {
        [JsonProperty("raffle")]
        public bool Raffle { get; set; }

        [JsonProperty("prize")]
        public bool Prize { get; set; }

        [JsonProperty("fixedOdds")]
        public bool FixedOdds { get; set; }
    }
}
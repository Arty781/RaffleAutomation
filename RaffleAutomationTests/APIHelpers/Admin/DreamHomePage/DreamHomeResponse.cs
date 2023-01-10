using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RaffleAutomationTests.APIHelpers.Admin.DreamHomePage
{
    [JsonObject]
    public class DreamHomeRequestModel
    {
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

        [JsonProperty("creditsEndDate")]
        public DateTimeOffset CreditsEndDate { get; set; }

        [JsonProperty("creditsStartDate")]
        public DateTimeOffset CreditsStartDate { get; set; }

        [JsonProperty("isCreditsActive")]
        public bool IsCreditsActive { get; set; }

        [JsonProperty("isCreditsPermanent")]
        public bool IsCreditsPermanent { get; set; }

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
    }


    [JsonObject]
    public class DreamHomeResponse
    {
        [JsonProperty("raffles")]
        public List<Raffle> Raffles { get; set; }
    }

    [JsonObject]
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
        public List<CreditsRate> CreditsRates { get; set; }

        [JsonProperty("isCreditsActive")]
        public bool IsCreditsActive { get; set; }

        [JsonProperty("discountRates")]
        public List<DiscountRate> DiscountRates { get; set; }

        [JsonProperty("freeTicketsRates")]
        public List<object> FreeTicketsRates { get; set; }

        [JsonProperty("isFreeTicketsRates")]
        public bool IsFreeTicketsRates { get; set; }

        [JsonProperty("ticketsBundles")]
        public List<long> TicketsBundles { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }

        [JsonProperty("startAt")]
        public DateTimeOffset StartAt { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("property")]
        public string Property { get; set; }

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

    public class CreditsRate
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("percent")]
        public long Percent { get; set; }
    }

    [JsonObject]
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
}

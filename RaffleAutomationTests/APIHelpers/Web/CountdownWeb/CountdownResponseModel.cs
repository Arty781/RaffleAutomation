using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RaffleAutomationTests.APIHelpers.Web
{
    #region Dreamhome
    public partial class CountdownResponseModelDreamHomeWeb
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }

        [JsonProperty("property")]
        public PropertyDreamHome Property { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
    public partial class PropertyDreamHome
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("galleryImages")]
        public List<string> GalleryImages { get; set; }

        [JsonProperty("galleryImagesMobile")]
        public List<string> GalleryImagesMobile { get; set; }

        [JsonProperty("cardImage")]
        public string CardImage { get; set; }
    }

    #endregion

    #region Weekly prizes


    [JsonObject]
    public partial class CompetitionResponseModelWeb
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("startAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? StartAt { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }

        [JsonProperty("isHasDiscount")]
        public bool IsHasDiscount { get; set; }

        [JsonProperty("competitionType")]
        public string CompetitionType { get; set; }

        [JsonProperty("ordersCount")]
        public long OrdersCount { get; set; }

        [JsonProperty("ticketsBought", NullValueHandling = NullValueHandling.Ignore)]
        public long? TicketsBought { get; set; }

        [JsonProperty("maxTickets", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxTickets { get; set; }
    }

    public partial class WeeklyPrizesRequest
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [JsonProperty("subCategoryId")]
        public string SubCategoryId { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    #region Full response
    [JsonObject]
    public partial class WeeklyPrizesResponseModelWeb
    {
        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("subCategories")]
        public SubCategories SubCategories { get; set; }

        [JsonProperty("prizes")]
        public List<Prize> Prizes { get; set; }

        [JsonProperty("competitions")]
        public Competitions Competitions { get; set; }

        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }
    }

    [JsonObject]
    public partial class Category
    {
        [JsonProperty("subCategory", NullValueHandling = NullValueHandling.Ignore)]
        public string[] SubCategory { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("photoUrlKey")]
        public Guid PhotoUrlKey { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }

        [JsonProperty("activeDiscount")]
        public long ActiveDiscount { get; set; }

        [JsonProperty("prizes", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Prizes { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryCategory { get; set; }
    }

    [JsonObject]
    public partial class Competitions
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }
    }

    [JsonObject]
    public partial class Prize
    {
        [JsonProperty("photoUrlKeys")]
        public string[] PhotoUrlKeys { get; set; }

        [JsonProperty("photoUrlKeysMobile")]
        public string[] PhotoUrlKeysMobile { get; set; }

        [JsonProperty("isActiveDiscount")]
        public bool IsActiveDiscount { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("ticketPrice")]
        public double TicketPrice { get; set; }

        [JsonProperty("discountTicket")]
        public DiscountTicket DiscountTicket { get; set; }
    }

    [JsonObject]
    public partial class DiscountTicket
    {
        [JsonProperty("percent")]
        public long Percent { get; set; }

        [JsonProperty("newPrice")]
        public long NewPrice { get; set; }
    }

    [JsonObject]
    public partial class SubCategories
    {
        [JsonProperty("subcategories")]
        public Category[] Subcategories { get; set; }
    }

    #endregion



    #endregion
}

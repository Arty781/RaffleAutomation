using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RaffleAutomationTests.APIHelpers.Admin.UsersPage
{
    public class UsersRequestModel
    {
        [JsonProperty("filter")]
        public Filter Filter { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("sort")]
        public Sort Sort { get; set; }
    }

    public class Filter
    {
        [JsonProperty("blocked")]
        public string Blocked { get; set; }

        [JsonProperty("searchName")]
        public string SearchName { get; set; }

        [JsonProperty("searchSurname")]
        public string SearchSurname { get; set; }

        [JsonProperty("searchEmail")]
        public string SearchEmail { get; set; }

        [JsonProperty("searchPhone")]
        public string SearchPhone { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("perPage")]
        public long PerPage { get; set; }
    }

    public class Sort
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }
    }

    public class UsersResponse
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        [JsonProperty("allCount")]
        public int AllCount { get; set; }
    }

    public class User
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("isManager")]
        public bool IsManager { get; set; }

        [JsonProperty("isVerified")]
        public bool IsVerified { get; set; }

        [JsonProperty("freeEntries")]
        public long FreeEntries { get; set; }

        [JsonProperty("successfullReferralCount")]
        public long SuccessfullReferralCount { get; set; }

        [JsonProperty("totalTicketsBought")]
        public long TotalTicketsBought { get; set; }

        [JsonProperty("emailCommunication")]
        public bool EmailCommunication { get; set; }

        [JsonProperty("registerReferrals")]
        public List<object> RegisterReferrals { get; set; }

        [JsonProperty("freeTickets")]
        public long FreeTickets { get; set; }

        [JsonProperty("isSocialRegistration")]
        public bool IsSocialRegistration { get; set; }

        [JsonProperty("isBlocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("notifications")]
        public Notifications Notifications { get; set; }

        [JsonProperty("spentMoney")]
        public long SpentMoney { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("registerRaffle")]
        public string RegisterRaffle { get; set; }

        [JsonProperty("referralKey")]
        public Guid ReferralKey { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }

        [JsonProperty("googleAccountId", NullValueHandling = NullValueHandling.Ignore)]
        public string GoogleAccountId { get; set; }

        [JsonProperty("facebookAccountId", NullValueHandling = NullValueHandling.Ignore)]
        public string FacebookAccountId { get; set; }

        [JsonProperty("neededSpend", NullValueHandling = NullValueHandling.Ignore)]
        public long? NeededSpend { get; set; }

        [JsonProperty("referralCredits", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReferralCredits { get; set; }

        [JsonProperty("referredBy", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferredBy { get; set; }

        [JsonProperty("emailMarketingSentDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? EmailMarketingSentDate { get; set; }

        [JsonProperty("isEmailValid")]
        public bool IsEmailValid { get; set; }

        [JsonProperty("boughtDHafterMailing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BoughtDHafterMailing { get; set; }

        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("corporateNotification", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CorporateNotification { get; set; }

        [JsonProperty("mobileEntry", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MobileEntry { get; set; }

        [JsonProperty("spentMobile", NullValueHandling = NullValueHandling.Ignore)]
        public long? SpentMobile { get; set; }
    }

    public class Notifications
    {
        [JsonProperty("dreamHome")]
        public bool? DreamHome { get; set; }

        [JsonProperty("lifestyle")]
        public bool? Lifestyle { get; set; }

        [JsonProperty("fixedOdds")]
        public bool? FixedOdds { get; set; }

        [JsonProperty("myCompetitions")]
        public bool? MyCompetitions { get; set; }

        [JsonProperty("newPrizes")]
        public bool? NewPrizes { get; set; }

        [JsonProperty("all")]
        public bool? All { get; set; }
    }

    public class UserOrdersRequestModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("sort")]
        public Sort Sort { get; set; }

        [JsonProperty("filter")]
        public FilterUserOrders Filter { get; set; }
    }

    public class FilterUserOrders
    {
        [JsonProperty("competitions")]
        public List<object> Competitions { get; set; }

        [JsonProperty("searchString")]
        public string SearchString { get; set; }

        [JsonProperty("searchField")]
        public string SearchField { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }
    }

    public class AddTicketsRequestModel
    {
        [JsonProperty("ticketsCount")]
        public int TicketsCount { get; set; }

        [JsonProperty("competition")]
        public string Competition { get; set; }

        [JsonProperty("prizeId")]
        public string PrizeId { get; set; }
    }

    public class AddTicketsResponseModel
    {
        [JsonProperty("spentCredits")]
        public int SpentCredits { get; set; }

        [JsonProperty("appliedCredits")]
        public List<object> AppliedCredits { get; set; }

        [JsonProperty("isArchive")]
        public bool IsArchive { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("competitionDate")]
        public DateTimeOffset CompetitionDate { get; set; }

        [JsonProperty("competitionId")]
        public string CompetitionId { get; set; }

        [JsonProperty("totalCost")]
        public int TotalCost { get; set; }

        [JsonProperty("tickets")]
        public List<Ticket> Tickets { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("raffle")]
        public string Raffle { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("paymentStatus")]
        public string PaymentStatus { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    public class Ticket
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("bonus")]
        public bool Bonus { get; set; }
    }

    public class OrdersResponseModel
    {
        [JsonProperty("orders")]
        public List<Order> Orders { get; set; }

        [JsonProperty("allCount")]
        public long AllCount { get; set; }
    }

    public class Order
    {
        [JsonProperty("_id")]
        public Id Id { get; set; }

        [JsonProperty("ordersIds")]
        public List<string> OrdersIds { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("prizeId")]
        public string PrizeId { get; set; }

        [JsonProperty("competitionId")]
        public string CompetitionId { get; set; }

        [JsonProperty("tickets")]
        public List<List<Ticket>> Tickets { get; set; }

        [JsonProperty("drawDate")]
        public DateTimeOffset DrawDate { get; set; }

        [JsonProperty("competition")]
        public string Competition { get; set; }

        [JsonProperty("ticketsCount")]
        public long TicketsCount { get; set; }
    }

    public class Id
    {
        [JsonProperty("competitionId")]
        public string CompetitionId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("_id")]
        public object IdId { get; set; }

        [JsonProperty("myCount")]
        public long MyCount { get; set; }
    }

    public class DeleteOrdersRequestModel
    {
        [JsonProperty("ids")]
        public List<string> Ids { get; set; }
    }

    #region Credits
    public class AddCreditsRequestModel
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        [JsonProperty("expiredDate")]
        public string ExpiredDate { get; set; }
    }

    public class AddCreditsResponseModel
    {
        [JsonProperty("holdAmount")]
        public long HoldAmount { get; set; }

        [JsonProperty("spent")]
        public long Spent { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("createdDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("expiredDate")]
        public DateTimeOffset ExpiredDate { get; set; }

        [JsonProperty("arrival")]
        public string Arrival { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    #endregion

}

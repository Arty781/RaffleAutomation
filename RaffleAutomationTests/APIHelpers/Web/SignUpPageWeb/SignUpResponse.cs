using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb
{
    public class SignUpRequestModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("emailCommunication")]
        public bool EmailCommunication { get; set; }

        [JsonProperty("notifications")]
        public Notifications Notifications { get; set; }

    }

    public class SignUpReferralRequestModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("emailCommunication")]
        public bool EmailCommunication { get; set; }

        [JsonProperty("notifications")]
        public Notifications Notifications { get; set; }

        [JsonProperty("referralKey")]
        public string ReferralKey { get; set; }
    }
    public class SignUpResponse
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }
    public partial class User
    {
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

        [JsonProperty("corporateNotification")]
        public bool CorporateNotification { get; set; }

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

        [JsonProperty("mobileEntry")]
        public bool MobileEntry { get; set; }

        [JsonProperty("spentMobile")]
        public long SpentMobile { get; set; }

        [JsonProperty("spentMoney")]
        public long SpentMoney { get; set; }

        [JsonProperty("referralCredits")]
        public long ReferralCredits { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("registerRaffle")]
        public string? RegisterRaffle { get; set; }

        [JsonProperty("referralKey")]
        public string? ReferralKey { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    public partial class Notifications
    {
        [JsonProperty("dreamHome")]
        public bool DreamHome { get; set; }

        [JsonProperty("lifestyle")]
        public bool Lifestyle { get; set; }

        [JsonProperty("fixedOdds")]
        public bool FixedOdds { get; set; }

        [JsonProperty("myCompetitions")]
        public bool MyCompetitions { get; set; }

        [JsonProperty("newPrizes")]
        public bool NewPrizes { get; set; }

        [JsonProperty("all")]
        public bool All { get; set; }
    }

}
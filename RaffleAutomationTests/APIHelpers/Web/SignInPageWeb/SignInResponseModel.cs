namespace RaffleAutomationTests.APIHelpers.Web.SignIn
{
    public class SignInRequestModelWeb
    {

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public partial class SignInResponseModelWeb
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public partial class User
    {
        [JsonProperty("freeEntries")]
        public long FreeEntries { get; set; }

        [JsonProperty("emailCommunication")]
        public bool EmailCommunication { get; set; }

        [JsonProperty("isSocialRegistration")]
        public bool IsSocialRegistration { get; set; }

        [JsonProperty("isBlocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("notifications")]
        public Notifications Notifications { get; set; }

        [JsonProperty("mobileEntry")]
        public bool MobileEntry { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("referralKey")]
        public Guid ReferralKey { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
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

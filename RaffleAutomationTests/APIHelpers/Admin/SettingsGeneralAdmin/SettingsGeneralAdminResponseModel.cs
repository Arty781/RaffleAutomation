using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Admin
{
    public partial class SettingsGeneralAdminResponseModel
    {
        [JsonProperty("discountRates")]
        public DiscountRates DiscountRates { get; set; }

        [JsonProperty("isDiscountRates")]
        public IsDiscountRates IsDiscountRates { get; set; }

        [JsonProperty("emailCountdowns")]
        public EmailCountdowns EmailCountdowns { get; set; }

        [JsonProperty("creditsRates")]
        public List<CreditsRate> CreditsRates { get; set; }

        [JsonProperty("isCreditsRates")]
        public bool IsCreditsRates { get; set; }

        [JsonProperty("referralDefaultValue")]
        public long ReferralDefaultValue { get; set; }

        [JsonProperty("referralCreditDefault")]
        public long ReferralCreditDefault { get; set; }

        [JsonProperty("freeTicketsRates")]
        public List<FreeTicketsRate> FreeTicketsRates { get; set; }

        [JsonProperty("isFreeTicketsRates")]
        public bool IsFreeTicketsRates { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }

        [JsonProperty("conditions")]
        public string Conditions { get; set; }

        [JsonProperty("policy")]
        public string Policy { get; set; }

        [JsonProperty("statistic")]
        public Statistic Statistic { get; set; }
    }

    public partial class CreditsRate
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

    public partial class EmailCountdowns
    {
        [JsonProperty("raffle")]
        public string Raffle { get; set; }

        [JsonProperty("prize")]
        public string Prize { get; set; }

        [JsonProperty("fixedOdds")]
        public string FixedOdds { get; set; }
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

    public partial class Statistic
    {
        [JsonProperty("totalWon")]
        public string TotalWon { get; set; }

        [JsonProperty("previousWinner")]
        public long PreviousWinner { get; set; }

        [JsonProperty("charitableDonation")]
        public string CharitableDonation { get; set; }

        [JsonProperty("charity")]
        public string Charity { get; set; }

        [JsonProperty("appDownload")]
        public long AppDownload { get; set; }
    }

}

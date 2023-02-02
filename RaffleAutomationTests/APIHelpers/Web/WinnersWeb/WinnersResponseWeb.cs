using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web.WinnersWeb
{
    public partial class WinnerResponse
    {
        [JsonProperty("winners")]
        public List<Winner> Winners { get; set; }

        [JsonProperty("allCount")]
        public int AllCount { get; set; }

        [JsonProperty("years")]
        public List<int> Years { get; set; }
    }

    public partial class Winner
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("drawDate")]
        public DateTimeOffset DrawDate { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("photoUrl")]
        public Guid PhotoUrl { get; set; }

        [JsonProperty("videoUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri VideoUrl { get; set; }
    }
}

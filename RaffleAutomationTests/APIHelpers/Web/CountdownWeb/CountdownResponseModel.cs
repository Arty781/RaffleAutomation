using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.WebApi
{
    public partial class CountdownResponseModelWeb
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("endsAt")]
        public DateTimeOffset EndsAt { get; set; }

        [JsonProperty("property")]
        public Property Property { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Property
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
}

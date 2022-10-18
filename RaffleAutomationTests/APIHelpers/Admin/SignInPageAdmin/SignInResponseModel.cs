using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Admin
{
    public partial class SignInResponseModelAdmin
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }

    public partial class User
    {
        [JsonProperty("isBlocked")]
        public bool IsBlocked { get; set; }

        [JsonProperty("permissions")]
        public List<Permission> Permissions { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("__v")]
        public long V { get; set; }
    }

    public partial class Permission
    {
        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("rights")]
        public Rights Rights { get; set; }
    }

    public partial class Rights
    {
        [JsonProperty("View")]
        public bool View { get; set; }

        [JsonProperty("Update")]
        public bool Update { get; set; }

        [JsonProperty("Delete")]
        public bool Delete { get; set; }
    }

}

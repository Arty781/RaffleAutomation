using NUnit.Framework.Constraints;

namespace RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb
{
    public class SignUpRequest
    {
        private static string JsonBody()
        {
            SignUpRequestModel req = new()
            {
                Name = Name.FirstName(),
                Surname = Name.LastName(),
                Password = Credentials.PASSWORD,
                Email = "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com",
                EmailCommunication = true,
                Country = Country.COUNTRY_CODES[137],
                Phone = RandomHelper.RandomPhone(),
                Notifications = new()
                {
                    All = true,
                    DreamHome = true,
                    FixedOdds = true,
                    Lifestyle = true,
                    MyCompetitions = true,
                    NewPrizes = true
                }

            };            
            return JsonConvert.SerializeObject(req);
        }

        private static string JsonBodyReferral(string referralKey)
        {
            SignUpReferralRequestModel req = new()
            {
                Name = Name.FirstName(),
                Surname = Name.LastName(),
                Password = "Qaz11111",
                Email = "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com",
                EmailCommunication = true,
                Country = Country.COUNTRY_CODES[RandomHelper.RandomFPId(Country.COUNTRY_CODES)],
                Phone = PhoneNumber.CellPhone(),
                Notifications = new()
                {
                    All = false,
                    DreamHome = false,
                    FixedOdds = false,
                    Lifestyle = false,
                    MyCompetitions = false,
                    NewPrizes = false
                },
                ReferralKey = referralKey

            };
            return JsonConvert.SerializeObject(req);
        }

        public static void RegisterNewUser(out SignUpResponse? response)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/signup",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("accept", "application/json, */*");
            req.LoadBodyFromString(JsonBody(), charset: "utf-8");

            Http http = new();
            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            response = http.LastMethodSuccess
            ? JsonConvert.DeserializeObject<SignUpResponse>(resp?.BodyStr ?? throw new Exception("Response body is null."))
            : throw new ArgumentException(http.LastErrorText);
        }

        public static SignUpResponse? RegisterNewReferral(string referralKey)
        {

            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/signup",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.LoadBodyFromString(JsonBodyReferral(referralKey), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            var response = http.LastMethodSuccess
            ? JsonConvert.DeserializeObject<SignUpResponse>(resp?.BodyStr ?? throw new Exception("Response body is null."))
            : throw new ArgumentException(http.LastErrorText);
            return response;
        }
    }
}

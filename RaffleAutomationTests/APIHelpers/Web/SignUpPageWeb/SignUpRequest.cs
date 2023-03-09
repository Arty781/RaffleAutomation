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
                Password = "Qaz11111",
                Email = "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com",
                EmailCommunication = true,
                Country = Country.COUNTRY_CODES[RandomHelper.RandomFPId(Country.COUNTRY_CODES)],
                Phone = PhoneNumber.CellPhone(),
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
            var request = JsonConvert.SerializeObject(req);
            return request;
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
            var request = JsonConvert.SerializeObject(req);
            return request;
        }

        public static SignUpResponse? RegisterNewUser()
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/signup",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.LoadBodyFromString(JsonBody(), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            var response = JsonConvert.DeserializeObject<SignUpResponse>(resp.BodyStr);
            return response;
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
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.LoadBodyFromString(JsonBodyReferral(referralKey), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            var response = JsonConvert.DeserializeObject<SignUpResponse>(resp.BodyStr);
            return response;
        }
    }
}

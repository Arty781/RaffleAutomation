namespace RaffleAutomationTests.APIHelpers.Admin
{
    public class SignInRequestAdmin
    {

        private static string SignIn(string login, string password)
        {
            SignInRequestModel str = new()
            {
                Email = login,
                Password = password
            };
            return JsonConvert.SerializeObject(str);
        }

        public static SignInResponseModelAdmin? MakeAdminSignIn(string login, string password)
        {
            HttpRequest req = new HttpRequest
            {
                HttpVerb = "POST",
                Path = $"/api/users/cms/signin",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");

            req.LoadBodyFromString(SignIn(login, password), charset: "utf-8");

            Http http = new();
            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            var response = http.LastMethodSuccess
                ? JsonConvert.DeserializeObject<SignInResponseModelAdmin>(resp?.BodyStr ?? throw new Exception("Response body is null."))
                : throw new ArgumentException(http.LastErrorText);

            return response;
        }

    }
}

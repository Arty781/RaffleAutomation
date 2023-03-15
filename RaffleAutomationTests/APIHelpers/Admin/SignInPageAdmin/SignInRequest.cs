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
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));
            var response = JsonConvert.DeserializeObject<SignInResponseModelAdmin>(resp.BodyStr);

            return response;
        }

    }
}

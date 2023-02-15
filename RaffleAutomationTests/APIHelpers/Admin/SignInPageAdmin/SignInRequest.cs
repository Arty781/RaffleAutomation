namespace RaffleAutomationTests.APIHelpers.Admin
{
    public class SignInRequestAdmin
    {

        public static string SignIn(string login, string password)
        {
            string str = string.Format("{{" +
                "\"email\"" + ":" + $"\"{login}\"" + "," +
                "\"password\"" + ":" + $"\"{password}\"" + "}}");
            return str;
        }

        public static SignInResponseModelAdmin? MakeAdminSignIn(string login, string password)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/users/cms/signin", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddJsonBody(SignIn(login, password));

            var response = restDriver.Execute(request);
            var content = response.Content;

            var token = JsonConvert.DeserializeObject<SignInResponseModelAdmin>(content);

            return token;
        }

    }
}

namespace RaffleAutomationTests.APIHelpers.Web.SignIn
{
    public class SignInRequestWeb
    {

        public static SignInRequestModelWeb RequestBuilder(string login, string password)
        {
            SignInRequestModelWeb req = new()
            {
                Email = login,
                Password = password
            };
            return req;
        }

        public static SignInResponseModelWeb? MakeSignIn(string login, string password)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/users/signin", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddJsonBody(RequestBuilder(login, password));

            var response = restDriver.Execute(request);
            var content = response.Content;

            var token = JsonConvert.DeserializeObject<SignInResponseModelWeb>(content);

            return token;
        }

    }
}

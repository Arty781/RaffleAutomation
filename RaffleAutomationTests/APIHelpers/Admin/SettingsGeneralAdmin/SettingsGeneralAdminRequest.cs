using Newtonsoft.Json;
using RaffleAutomationTests.Helpers;
using RestSharp;

namespace RaffleAutomationTests.APIHelpers.Admin
{
    public class SettingsGeneralAdmin
    {

        public static string SignIn(string login, string password)
        {
            string str = string.Format("{{" +
                "\"email\"" + ":" + $"\"{login}\"" + "," +
                "\"password\"" + ":" + $"\"{password}\"" + "}}");
            return str;
        }

        public static SettingsGeneralAdminResponseModel? MakeAdminSignIn(string login, string password)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/users/cms/signin", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddJsonBody(SignIn(login, password));

            var response = restDriver.Execute(request);
            var content = response.Content;

            var token = JsonConvert.DeserializeObject<SettingsGeneralAdminResponseModel>(content);

            return token;
        }

    }
}

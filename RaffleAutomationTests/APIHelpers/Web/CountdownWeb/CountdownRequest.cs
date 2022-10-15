using Newtonsoft.Json;
using RaffleAutomationTests.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.WebApi
{
    public class CountdownRequestWeb
    {
        public static CountdownResponseModelWeb GetCountdown(SignInResponseModelWeb SignIn)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("api/raffles/active/countdowns/", Method.Get);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");

            var response = restDriver.Execute(request);
            var content = response.Content.Replace("[{", "{").Replace("}]", "}");
            var countdownResponse = JsonConvert.DeserializeObject<CountdownResponseModelWeb>(content);

            return countdownResponse;
        }
    }
}

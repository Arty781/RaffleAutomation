using RaffleAutomationTests.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.WebApi
{
    public class SignInRequestWeb
    {
       
        public static SignInRequestModelWeb SignIn(string login, string password)
        {
            SignInRequestModelWeb req = new()
            {
                Email = login,
                Password = password
            };
            return req;
        }

        public static SignInResponseModelWeb MakeSignIn(string login, string password)
        {
            
            
            var restDriver = new RestClient(Endpoints.ApiHost);
            RestRequest? request = new RestRequest("/api/users/signin", Method.Post);
            request.AddHeaders(headers: Headers.HeadersCommon());
            request.AddJsonBody(SignIn(login, password));

            var response = restDriver.Execute(request);
            var content = response.Content;

            var token = JsonConvert.DeserializeObject<SignInResponseModelWeb>(content);

            return token;
        }

    }
}

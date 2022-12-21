using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaffleAutomationTests.Helpers;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using RimuTec.Faker;

namespace RaffleAutomationTests.APIHelpers.Web.SignUpPageWeb
{
    public class SignUpRequest
    {
        private static  SignUpRequestModel JsonBody()
        {
            SignUpRequestModel req = new()
            {
                Name = Name.FirstName(),
                Surname = Name.LastName(),
                Password = "Qaz11111",
                Email = "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com",
                EmailCommunication = true,
                Country = Country.COUNTRY_CODES[RandomHelper.RandomFPId(Country.COUNTRY_CODES)],
                Phone = RandomHelper.RandomPhone(),
                Notifications= new()
                {
                    All= false,
                    DreamHome= false,
                    FixedOdds= false,
                    Lifestyle= false,
                    MyCompetitions= false,
                    NewPrizes= false
                }
            };

            return req;
        }
        public static SignUpResponse? RegisterNewUser()
        {

            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? req = new RestRequest("/api/users/signup", Method.Post);
            req.AddHeaders(headers: Headers.COMMON);
            req.AddJsonBody(JsonBody());

            var response = restDriver.Execute(req);
            if(response.IsSuccessStatusCode != true)
            {
                Debug.WriteLine(response.ErrorMessage);
            }
            var content = response.Content;

            SignUpResponse? email = JsonConvert.DeserializeObject<SignUpResponse>(content);

            return email;
        }
    }
}

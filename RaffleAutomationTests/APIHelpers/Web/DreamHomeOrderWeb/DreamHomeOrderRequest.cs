using Newtonsoft.Json;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web
{
    public class DreamHomeOrderRequestWeb
    {
        public static DreamHomeOrderRequestModel RequestBuilder(string id)
        {
            DreamHomeOrderRequestModel req = new()
            {
                NumOfTickets = $"{RandomHelper.RandomNumber()}",
                PrizeType = "raffle",
                PrizeId = id
            };

            return req;
        }

        public static DreamHomeOrderResponseModelWeb? AddDreamhomeTickets(SignInResponseModelWeb SignIn, CountdownResponseModelDreamHomeWeb countdown)
        {


            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/orders", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");
            request.AddJsonBody(RequestBuilder(countdown.Id));

            var r = restDriver.Execute(request);
            if(r.IsSuccessStatusCode == false)
            {
                Debug.WriteLine(r.ErrorMessage);
            }
            Debug.WriteLine(r.Content);
            var content = r.Content;

            var response = JsonConvert.DeserializeObject<DreamHomeOrderResponseModelWeb>(content);

            return response;
        }
    }
}

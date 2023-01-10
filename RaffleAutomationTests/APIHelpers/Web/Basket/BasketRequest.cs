using Newtonsoft.Json;
using RaffleAutomationTests.APIHelpers.Web.SignIn;
using RaffleAutomationTests.Helpers;
using RestSharp;

namespace RaffleAutomationTests.APIHelpers.Web.Basket
{
    public class BasketRequest
    {
        public static CreateBasketRequest RequestBuilder(string id)
        {
            CreateBasketRequest req = new()
            {
                Order = id
            };

            return req;
        }


        public static void DeleteOrders(SignInResponseModelWeb SignIn, GetBasketOrdersResponse Orders)
        {
            if (Orders.BasketOrders != null)
            {
                foreach (var basketOrder in Orders.BasketOrders)
                {
                    var restDriver = new RestClient(ApiEndpoints.API);
                    RestRequest? request = new RestRequest("/api/orders", Method.Delete);
                    request.AddHeaders(headers: Headers.COMMON);
                    request.AddHeader("authorization", $"Bearer {SignIn.Token}");
                    request.AddJsonBody(RequestBuilder(basketOrder.Id));
                    restDriver.Execute(request);

                }

            }

        }

        public static GetBasketOrdersRequest RequesBuilder()
        {
            GetBasketOrdersRequest req = new()
            {
                CouponId = null,
                IsApplyCredit = false
            };

            return req;
        }


        public static GetBasketOrdersResponse? GetBasketOrders(SignInResponseModelWeb SignIn)
        {
            var restDriver = new RestClient(ApiEndpoints.API);
            RestRequest? request = new RestRequest("/api/orders/getBasketOrders", Method.Post);
            request.AddHeaders(headers: Headers.COMMON);
            request.AddHeader("authorization", $"Bearer {SignIn.Token}");
            request.AddJsonBody(RequesBuilder());

            var response = restDriver.Execute(request);
            var content = response.Content;
            var countdownResponse = JsonConvert.DeserializeObject<GetBasketOrdersResponse>(content);

            return countdownResponse;
        }
    }
}

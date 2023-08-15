using RaffleAutomationTests.APIHelpers.Web.FixedOddsPrizesWeb;
using RaffleAutomationTests.APIHelpers.Web.ForgotPasswordWeb;

namespace RaffleAutomationTests.APIHelpers.Web.Basket
{
    public class BasketRequest
    {
        public static string RequestBuilder(string id)
        {
            CreateBasketRequest req = new()
            {
                Order = id
            };

            return JsonConvert.SerializeObject(req);
        }


        public static void DeleteOrders(SignInResponseModelWeb SignIn, GetBasketOrdersResponse Orders)
        {
            if (Orders.BasketOrders != null)
            {
                foreach (var basketOrder in Orders.BasketOrders)
                {
                    Http http = new()
                    {
                        Accept = "application/json",
                        AuthToken = "Bearer " + SignIn.Token
                    };
                    HttpRequest req = new()
                    {
                        HttpVerb = "DELETE",
                        Path = "/api/orders",
                    };
                    req.AddHeader("Content-Type", "application/json");
                    req.LoadBodyFromString(RequestBuilder(basketOrder.Id), "UTF-8");

                    HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
                    if (http.LastStatus != 200)
                    {
                        throw new ArgumentException(http.LastErrorText);
                    }

                }

            }

        }

        public static string RequesBuilder()
        {
            GetBasketOrdersRequest req = new()
            {
                CouponId = null,
                IsApplyCredit = false
            };

            return JsonConvert.SerializeObject(req);
        }


        public static GetBasketOrdersResponse? GetBasketOrders(SignInResponseModelWeb SignIn)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = "/api/orders/getBasketOrders",
            };

            req.AddHeader("connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept", "application/json, text/plain, */*");
            req.AddHeader("content-type", "application/json");
            req.AddHeader("authorization", $"Bearer {SignIn.Token}");
            req.LoadBodyFromString(RequesBuilder(), charset: "utf-8");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                throw new ArgumentException(http.LastErrorText);
            }
            var countdownResponse = JsonConvert.DeserializeObject<GetBasketOrdersResponse>(resp.BodyStr);

            return countdownResponse;
        }
    }
}

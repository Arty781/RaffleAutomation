namespace RaffleAutomationTests.APIHelpers.Web.ForgotPasswordWeb
{
    public class RequestForgotPassword
    {
        private static string RequestBuilder(string login)
        {
            RequestForgot req = new()
            {
                Email = login
            };
            return JsonConvert.SerializeObject(req);
        }

        private static string JsonBody(string token)
        {
            RequestReset request = new()
            {
                Password = RandomHelper.RandomString(15),
                Token = token
            };
            return JsonConvert.SerializeObject(request);
        }

        private static string JsonBody(string token, string pass)
        {
            RequestReset request = new()
            {
                Password = pass,
                Token = token
            };
            return JsonConvert.SerializeObject(request);
        }

        public static ResponseForgotPassword? ForgotPassword(string email)
        {
            Http http = new()
            {
                Accept = "application/json"
            };

            string url = String.Concat(ApiEndpoints.API_CHIL + "/api/users/password/forgot");
            HttpResponse resp = http.PostJson2(url, "application/json", RequestBuilder(email));
            if (http.LastStatus != 200)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            var token = JsonConvert.DeserializeObject<ResponseForgotPassword>(resp.BodyStr);

            return token;
        }

        public static string GetResetLink(string link)
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = link
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");

            Http http = new Http();

            HttpResponse resp = http.SynchronousRequest("email.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Console.WriteLine(http.LastErrorText);
            }
            return resp.FinalRedirectUrl;
        }

        public static ResponseResetPassword? ResetPassword(string token)
        {
            Http http = new()
            {
                Accept = "application/json"
            };

            string url = String.Concat(ApiEndpoints.API_CHIL + "/api/users/password/reset");
            HttpResponse resp = http.PostJson2(url, "Application/json", JsonBody(token));
            if (http.LastStatus != 200)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            var content = JsonConvert.DeserializeObject<ResponseResetPassword>(resp.BodyStr);

            return content;
        }

        public static ResponseResetPassword? ResetPassword(string token, string password)
        {
            Http http = new()
            {
                Accept = "application/json"
            };

            string url = String.Concat(ApiEndpoints.API_CHIL + "/api/users/password/reset");
            HttpResponse resp = http.PostJson2(url, "Application/json", JsonBody(token, password));
            if (http.LastStatus != 200)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            var content = JsonConvert.DeserializeObject<ResponseResetPassword>(resp.BodyStr);

            return content;
        }
    }
}

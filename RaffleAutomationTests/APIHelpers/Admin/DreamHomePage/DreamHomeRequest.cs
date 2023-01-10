using Chilkat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RaffleAutomationTests.APIHelpers.Admin.DreamHomePage
{
    public class DreamHomeRequest
    {
        private static string JsonBody(DreamHomeResponse response, double priceWithDiscount, double priceWithoutDiscount)
        {
            DreamHomeRequestModel req = new()
            {
                Active = response.Raffles.FirstOrDefault().Active,
                IsActiveDiscount = response.Raffles.FirstOrDefault().IsActiveDiscount,
                IsPopular = response.Raffles.FirstOrDefault().IsPopular,
                IsTrending = response.Raffles.FirstOrDefault().IsTrending,
                EndsAt = response.Raffles.FirstOrDefault().EndsAt,
                StartAt = response.Raffles.FirstOrDefault().StartAt,
                TicketPrice = priceWithoutDiscount,
                DefaultTickets = response.Raffles.FirstOrDefault().DefaultTickets,
                IsDiscountRates = response.Raffles.FirstOrDefault().IsDiscountRates,
                CreditsRates = new List<CreditsRate>()
                {
                    new CreditsRate()
                    {
                        Id = 1,
                    Count = 20,
                    Percent = 30
                    }
                },
                CreditsEndDate = response.Raffles.FirstOrDefault().CreditsEndDate,
                CreditsStartDate = response.Raffles.FirstOrDefault().CreditsStartDate,
                IsCreditsActive = response.Raffles.FirstOrDefault().IsCreditsActive,
                IsCreditsPermanent = response.Raffles.FirstOrDefault().IsCreditsPermanent,
                DiscountRates = new List<DiscountRate>()
                {
                    new DiscountRate()
                    {
                        AmountTickets = 15,
                        Percent = 16.67,
                        NewPrice = priceWithDiscount
                    },
                    new DiscountRate()
                    {
                        AmountTickets = 16,
                        Percent = 0,
                        NewPrice = priceWithoutDiscount
                    }
                },
                DiscountTicket = new()
                {
                    Percent = 1,
                    NewPrice = 1
                },
                DiscountCategory = response.Raffles.FirstOrDefault().DiscountCategory,
                FreeTicketsRates = new List<object>()
                {
                    new FreeTicketsRate()
                    {

                    }
                },
                IsFreeTicketsRates = response.Raffles.FirstOrDefault().IsFreeTicketsRates,
                TicketsBundles = new()
                {
                    5,
                    15,
                    20,
                    50
                },
                Title = response.Raffles.FirstOrDefault().Title,
                MetaTitle = response.Raffles.FirstOrDefault().MetaTitle,
                MetaDescription = response.Raffles.FirstOrDefault().MetaDescription
            };
            return JsonConvert.SerializeObject(req);
        }

        public static void EditTiketPriceInDreamHome(SignInResponseModelAdmin token, DreamHomeResponse response, double priceWithDiscount, double priceWithoutDiscount)
        {
            HttpRequest req = new HttpRequest
            {
                HttpVerb = "PUT",
                Path = $"/api/raffles/{response.Raffles.FirstOrDefault().Id}",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            req.LoadBodyFromString(JsonBody(response, priceWithDiscount, priceWithoutDiscount), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
                return;
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));
        }

        public static DreamHomeResponse GetActiveDreamHome(SignInResponseModelAdmin token)
        {
            HttpRequest req = new HttpRequest
            {
                HttpVerb = "GET",
                Path = $"/api/raffles/active/cms/?number=1&count=10&filter=undefined",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            var response = JsonConvert.DeserializeObject<DreamHomeResponse>(resp.BodyStr);
            return response;
        }

    }
}

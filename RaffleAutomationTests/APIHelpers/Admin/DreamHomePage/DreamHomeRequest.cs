﻿using Chilkat;
using Newtonsoft.Json;
using RaffleAutomationTests.Helpers;
using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace RaffleAutomationTests.APIHelpers.Admin.DreamHomePage
{
    public class DreamHomeRequest
    {
        private static string JsonBody(RaffleResponse response, double priceWithDiscount, double priceWithoutDiscount)
        {
            DreamHomeRequestModel req = new()
            {
                Active = response.Active,
                IsActiveDiscount = response.IsActiveDiscount,
                IsPopular = response.IsPopular,
                IsTrending = response.IsTrending,
                EndsAt = response.EndsAt,
                StartAt = response.StartAt,
                TicketPrice = priceWithoutDiscount,
                DefaultTickets = response.DefaultTickets,
                IsDiscountRates = response.IsDiscountRates,
                CreditsRates = new List<CreditsRate>()
                {
                    new CreditsRate()
                    {
                        Id = 1,
                    Count = 20,
                    Percent = 30
                    }
                },
                CreditsEndDate = response.CreditsEndDate,
                CreditsStartDate = response.CreditsStartDate,
                IsCreditsActive = response.IsCreditsActive,
                IsCreditsPermanent = response.IsCreditsPermanent,
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
                DiscountCategory = response.DiscountCategory,
                FreeTicketsRates = new List<object>()
                {
                    new FreeTicketsRate()
                    {

                    }
                },
                IsFreeTicketsRates = response.IsFreeTicketsRates,
                TicketsBundles = new()
                {
                    5,
                    15,
                    50,
                    150
                },
                Title = response.Title,
                MetaTitle = response.MetaTitle,
                MetaDescription = response.MetaDescription
            };
            return JsonConvert.SerializeObject(req);
        }

        private static string JsonBodyProperty()
        {
            Property str = new()
            {
                GalleryImages= new List<string>() { },
                GalleryImagesMobile= new List<string>() { },
                FloorPlanImage = String.Empty,
                BadroomImage= String.Empty,
                BathroomImage= String.Empty,
                CardImage= String.Empty,
                OutspaceImage= String.Empty,
                BathroomText= Lorem.ParagraphByChars(300),
                BedroomText= Lorem.ParagraphByChars(300),
                OutspaceText= Lorem.ParagraphByChars(300),
                Description= Lorem.ParagraphByChars(50),
                Heading= Lorem.ParagraphByChars(20),
                GeneralText= Lorem.ParagraphByChars(50),
                PixangleSource= String.Empty,
                Location= Address.FullAddress(),
                Latitude=Address.Latitude(),
                Longitude=Address.Longitude(),
                TourLink = String.Empty,
                Overview = new List<Overview>()
                {
                    new Overview()
                    {
                        Title= Lorem.ParagraphByChars(20),
                        Value= $"{RandomHelper.RandomIntNumber(99)}",
                        Icon= "common/dreamhome_prop_icons/Bath.png",
                    },
                    new Overview()
                    {
                        Title= Lorem.ParagraphByChars(20),
                        Value= $"{RandomHelper.RandomIntNumber(99)}",
                        Icon= "common/dreamhome_prop_icons/Bath.png",
                    },
                    new Overview()
                    {
                        Title= Lorem.ParagraphByChars(20),
                        Value= $"{RandomHelper.RandomIntNumber(99)}",
                        Icon= "common/dreamhome_prop_icons/Bath.png",
                    },
                    new Overview()
                    {
                        Title= Lorem.ParagraphByChars(20),
                        Value= $"{RandomHelper.RandomIntNumber(99)}",
                        Icon= "common/dreamhome_prop_icons/Bath.png",
                    }

                }
            };


            return JsonConvert.SerializeObject(str);
        }

        private static string JsonBodyRaffle(PropertyResponse property)
        {
            DreamHomeRequestModel req = new()
            {
                Active = false,
                IsActiveDiscount = false,
                IsPopular = false,
                IsTrending = false,
                EndsAt = DateTime.Now.AddYears(1),
                StartAt = DateTime.Now.AddDays(-1),
                TicketPrice = 2,
                DefaultTickets = 10,
                IsDiscountRates = true,
                CreditsRates = new List<CreditsRate>()
                {
                    new CreditsRate()
                    {
                        Id = 1,
                        Count = 20,
                        Percent = 30
                    }
                },
                CreditsEndDate = DateTime.Now.AddMonths(1),
                CreditsStartDate = DateTime.Now,
                IsCreditsActive = false,
                IsCreditsPermanent = false,
                DiscountRates = new List<DiscountRate>()
                {
                    new DiscountRate()
                    {
                        AmountTickets = 15,
                        Percent = 16.67,
                        NewPrice = 1.66666666666
                    },
                    new DiscountRate()
                    {
                        AmountTickets = 16,
                        Percent = 0,
                        NewPrice = 2
                    }
                },
                DiscountTicket = new()
                {
                    Percent = 1,
                    NewPrice = 1
                },
                DiscountCategory = "cash",
                FreeTicketsRates = new List<object>()
                {
                    new FreeTicketsRate()
                    {

                    }
                },
                IsFreeTicketsRates = false,
                TicketsBundles = new()
                {
                    5,
                    15,
                    20,
                    50
                },
                Title = Lorem.ParagraphByChars(30),
                MetaTitle = Lorem.ParagraphByChars(50),
                MetaDescription = Lorem.ParagraphByChars(40),
                Property = property.Id
                
            };
            return JsonConvert.SerializeObject(req);
        }

        public static void EditTiketPriceInDreamHome(SignInResponseModelAdmin token, RaffleResponse response, double priceWithDiscount, double priceWithoutDiscount)
        {
            HttpRequest req = new HttpRequest
            {
                HttpVerb = "PUT",
                Path = $"/api/raffles/{response.Id}",
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

        public static RaffleResponse? GetActiveDreamHome(SignInResponseModelAdmin token)
        {
            HttpRequest req = new()
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

            var response = JsonConvert.DeserializeObject<RaffleResponse?>(resp.BodyStr);
            return response;
        }

        public static DreamHomeResponse? GetNotActiveDreamHomes(SignInResponseModelAdmin token)
        {
            HttpRequest req = new HttpRequest
            {
                HttpVerb = "GET",
                Path = $"/api/raffles/?number=1&count=10&filter=false",
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
            var res = JsonConvert.DeserializeObject<DreamHomeResponse>(resp.BodyStr).Raffles.Count;
            var response = JsonConvert.DeserializeObject<DreamHomeResponse?>(resp.BodyStr);
            

            return response;
        }

        public static RaffleResponse? CreateNewDreamHome(SignInResponseModelAdmin token)
        {
            HttpRequest req = new HttpRequest
            {
                HttpVerb = "POST",
                Path = $"/api/properties",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            req.LoadBodyFromString(JsonBodyProperty(), charset: "utf-8");

            Http http = new();

            HttpResponse respProperty = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            var responseProperty = JsonConvert.DeserializeObject<PropertyResponse>(respProperty.BodyStr);

            req = new HttpRequest
            {
                HttpVerb = "POST",
                Path = $"/api/raffles",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            req.LoadBodyFromString(JsonBodyRaffle(responseProperty), charset: "utf-8");

            http = new();

            HttpResponse respRaffle = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            var response = JsonConvert.DeserializeObject<RaffleResponse?>(respRaffle.BodyStr);
            return response;
        }

    }
}
namespace RaffleAutomationTests.APIHelpers.Admin.DreamHomePage
{
    public class DreamHomeRequest
    {
        private static string JsonBody(Raffles response, double priceWithDiscount, double priceWithoutDiscount, List<long> bundles)
        {
            DreamHomeRequestModel req = new()
            {
                Active = response.Active,
                IsActiveDiscount = response.IsActiveDiscount,
                IsPopular = response.IsPopular,
                IsTrending = response.IsTrending,
                EndsAt = response.EndsAt.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                StartAt = response.StartAt.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
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
                CreditsEndDate = response.CreditsEndDate.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                CreditsStartDate = response.CreditsStartDate.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
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
                FreeTicketsRates = Array.Empty<string>(),
                IsFreeTicketsRates = response.IsFreeTicketsRates,
                TicketsBundles = bundles,
                Title = response.Title,
                MetaTitle = response.MetaTitle,
                MetaDescription = response.MetaDescription,
                StepperCountdown = response.StepperCountdown,
                IsClosed = false
            };
            return JsonConvert.SerializeObject(req);
        }

        private static string JsonBody(RaffleResponse response, bool first, int hoursStartAt, int hoursEndsAt)
        {
            DreamHomeRequestModel? req = null;
            if (first == true)
            {
                req = new()
                {
                    Active = response.Raffles.First().Active,
                    IsActiveDiscount = response.Raffles.First().IsActiveDiscount,
                    IsPopular = response.Raffles.First().IsPopular,
                    IsTrending = response.Raffles.First().IsTrending,
                    EndsAt = DateTime.Now.AddHours(hoursEndsAt).ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                    StartAt = DateTime.Now.AddHours(hoursStartAt).ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                    TicketPrice = 2,
                    DefaultTickets = response.Raffles.First().DefaultTickets,
                    IsDiscountRates = response.Raffles.First().IsDiscountRates,
                    CreditsRates = new List<CreditsRate>()
                {
                    new CreditsRate()
                    {
                        Id = 1,
                        Count = 20,
                        Percent = 30
                    }
                },
                    CreditsEndDate = response.Raffles.First().CreditsEndDate.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                    CreditsStartDate = response.Raffles.First().CreditsStartDate.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                    IsCreditsActive = response.Raffles.First().IsCreditsActive,
                    IsCreditsPermanent = response.Raffles.First().IsCreditsPermanent,
                    DiscountRates = new List<DiscountRate>()
                {
                    new DiscountRate()
                    {
                        AmountTickets = 15,
                        Percent = 16.67,
                        NewPrice = 1.6666667
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
                    DiscountCategory = response.Raffles.First().DiscountCategory,
                    FreeTicketsRates = Array.Empty<string>(),
                    IsFreeTicketsRates = response.Raffles.First().IsFreeTicketsRates,
                    TicketsBundles = new()
                    {
                        5,
                        15,
                        50,
                        150
                    },
                    Title = response.Raffles.First().Title,
                    MetaTitle = response.Raffles.First().MetaTitle,
                    MetaDescription = response.Raffles.First().MetaDescription,
                    StepperCountdown = response.Raffles.First().StepperCountdown,
                    IsClosed = false
                };
            }
            else
            {
                req = new()
                {
                    Active = response.Raffles.Last().Active,
                    IsActiveDiscount = response.Raffles.Last().IsActiveDiscount,
                    IsPopular = response.Raffles.Last().IsPopular,
                    IsTrending = response.Raffles.Last().IsTrending,
                    EndsAt = DateTime.Now.AddHours(hoursEndsAt).ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                    StartAt = DateTime.Now.AddHours(hoursStartAt).ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                    TicketPrice = 2,
                    DefaultTickets = response.Raffles.Last().DefaultTickets,
                    IsDiscountRates = response.Raffles.Last().IsDiscountRates,
                    CreditsRates = new List<CreditsRate>()
                {
                    new CreditsRate()
                    {
                        Id = 1,
                        Count = 20,
                        Percent = 30
                    }
                },
                    CreditsEndDate = response.Raffles.Last().CreditsEndDate.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                    CreditsStartDate = response.Raffles.Last().CreditsStartDate.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                    IsCreditsActive = response.Raffles.Last().IsCreditsActive,
                    IsCreditsPermanent = response.Raffles.Last().IsCreditsPermanent,
                    DiscountRates = new List<DiscountRate>()
                {
                    new DiscountRate()
                    {
                        AmountTickets = 15,
                        Percent = 16.67,
                        NewPrice = 1.6666667
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
                    DiscountCategory = response.Raffles.Last().DiscountCategory,
                    FreeTicketsRates = Array.Empty<string>(),
                    IsFreeTicketsRates = response.Raffles.Last().IsFreeTicketsRates,
                    TicketsBundles = new()
                    {
                        5,
                        15,
                        50,
                        150
                    },
                    Title = response.Raffles.Last().Title,
                    MetaTitle = response.Raffles.Last().MetaTitle,
                    MetaDescription = response.Raffles.Last().MetaDescription,
                    StepperCountdown = response.Raffles.Last().StepperCountdown,
                    IsClosed = false
                };
            }
            return JsonConvert.SerializeObject(req);
        }

        private static string JsonBodyDeactivate(RaffleResponse response)
        {
            DreamHomeRequestModel req = new()
            {
                Active = false,
                IsActiveDiscount = response.Raffles.First().IsActiveDiscount,
                IsPopular = response.Raffles.First().IsPopular,
                IsTrending = response.Raffles.First().IsTrending,
                EndsAt = response.Raffles.First().EndsAt.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                StartAt = response.Raffles.First().StartAt.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                TicketPrice = response.Raffles.First().TicketPrice,
                DefaultTickets = response.Raffles.First().DefaultTickets,
                IsDiscountRates = response.Raffles.First().IsDiscountRates,
                CreditsRates = new List<CreditsRate>()
                {
                    new CreditsRate()
                    {
                        Id = 1,
                        Count = 20,
                        Percent = 30
                    }
                },
                CreditsEndDate = response.Raffles.First().CreditsEndDate.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                CreditsStartDate = response.Raffles.First().CreditsStartDate.ToString("yyyy-MM-dd'T'hh:mm:ss'.000Z'"),
                IsCreditsActive = response.Raffles.First().IsCreditsActive,
                IsCreditsPermanent = response.Raffles.First().IsCreditsPermanent,
                DiscountRates = response.Raffles.First().DiscountRates,
                DiscountTicket = new()
                {
                    Percent = 1,
                    NewPrice = 1
                },
                DiscountCategory = response.Raffles.First().DiscountCategory,
                FreeTicketsRates = Array.Empty<string>(),
                IsFreeTicketsRates = response.Raffles.First().IsFreeTicketsRates,
                TicketsBundles = response.Raffles.First().TicketsBundles,
                Title = response.Raffles.First().Title,
                MetaTitle = response.Raffles.First().MetaTitle,
                MetaDescription = response.Raffles.First().MetaDescription,
                StepperCountdown = response.Raffles.First().StepperCountdown,
                IsClosed = true

            };
            return JsonConvert.SerializeObject(req);
        }

        private static string JsonBodyProperty()
        {
            Property str = new()
            {
                GalleryImages = new List<string>() { },
                GalleryImagesMobile = new List<string>() { },
                FloorPlanImage = String.Empty,
                BadroomImage = String.Empty,
                BathroomImage = String.Empty,
                CardImage = String.Empty,
                OutspaceImage = String.Empty,
                BathroomText = Lorem.ParagraphByChars(300),
                BedroomText = Lorem.ParagraphByChars(300),
                OutspaceText = Lorem.ParagraphByChars(300),
                Description = Lorem.ParagraphByChars(50),
                Heading = Lorem.ParagraphByChars(20),
                GeneralText = Lorem.ParagraphByChars(50),
                PixangleSource = String.Empty,
                Location = Address.FullAddress(),
                Latitude = Address.Latitude(),
                Longitude = Address.Longitude(),
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
            CreateDreamHomeRequestModel req = new()
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

        public static void EditTiketPriceInDreamHome(SignInResponseModelAdmin token, Raffles response, double priceWithDiscount, double priceWithoutDiscount, List<long> bundles)
        {
            HttpRequest req = new HttpRequest
            {
                HttpVerb = "PUT",
                Path = $"/api/raffles/{response.Id}",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            req.LoadBodyFromString(JsonBody(response, priceWithDiscount, priceWithoutDiscount, bundles), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
                return;
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));
        }

        public static void EditDreamHomeStartEndDate(SignInResponseModelAdmin token, RaffleResponse response, bool isFirst, int hoursStartAt, int hoursEndsAt)
        {
            HttpRequest req = new();
            if (isFirst == true)
            {
                req = new HttpRequest
                {
                    HttpVerb = "PUT",
                    Path = $"/api/raffles/{response.Raffles.First().Id}",
                    ContentType = "application/json"
                };
                req.AddHeader("Connection", "Keep-Alive");
                req.AddHeader("applicationid", "WppJsNsSvr");
                req.AddHeader("accept-encoding", "gzip, deflate, br");
                req.AddHeader("authorization", $"Bearer {token.Token}");

                req.LoadBodyFromString(JsonBody(response, isFirst, hoursStartAt, hoursEndsAt), charset: "utf-8");
            }
            else
            {
                req = new HttpRequest
                {
                    HttpVerb = "PUT",
                    Path = $"/api/raffles/{response.Raffles.Last().Id}",
                    ContentType = "application/json"
                };
                req.AddHeader("Connection", "Keep-Alive");
                req.AddHeader("applicationid", "WppJsNsSvr");
                req.AddHeader("accept-encoding", "gzip, deflate, br");
                req.AddHeader("authorization", $"Bearer {token.Token}");

                req.LoadBodyFromString(JsonBody(response, isFirst, hoursStartAt, hoursEndsAt), charset: "utf-8");
            }

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
                return;
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));
        }

        public static void DeactivateDreamHome(SignInResponseModelAdmin token, RaffleResponse response)
        {
            HttpRequest req = new HttpRequest
            {
                HttpVerb = "PUT",
                Path = $"/api/raffles/{response.Raffles.First().Id}",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            req.LoadBodyFromString(JsonBodyDeactivate(response), charset: "utf-8");
            if (response != null)
            {
                Http http = new();

                HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
                if (http.LastMethodSuccess != true)
                {
                    Debug.WriteLine(http.LastErrorText);
                    return;
                }
                Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));
            }

        }

        public static RaffleResponse? GetActiveDreamHome(SignInResponseModelAdmin token, out Raffles? closeEarlier)
        {
            HttpRequest req = new()
            {
                HttpVerb = "GET",
                Path = $"/api/raffles/active/cms/?number=1&count=10&filter=undefined",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("applicationid", "WppJsNsSvr");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            var response = JsonConvert.DeserializeObject<RaffleResponse?>(resp.BodyStr);
            closeEarlier = response.Raffles.OrderBy(item => item.EndsAt)
                             .FirstOrDefault();
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
            req.AddHeader("applicationid", "WppJsNsSvr");
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
            req.AddHeader("applicationid", "WppJsNsSvr");
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
            req.AddHeader("applicationid", "WppJsNsSvr");
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

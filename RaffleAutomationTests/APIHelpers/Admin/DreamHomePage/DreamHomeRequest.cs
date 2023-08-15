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
                        Id = "0",
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
                        Id = "0",
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
                        NewPrice = 1.6666666
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
                        Id = "0",
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
                        NewPrice = 1.6666666
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
                        Id = "0",
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
            PropertyRequest str = new()
            {
                GalleryImages = new List<string>() 
                {
                    string.Empty,
                },
                GalleryImagesMobile = new List<string>()
                {
                    string.Empty
                },
                FloorPlanImage = String.Empty,
                BadroomImage = String.Empty,
                BathroomImage = String.Empty,
                CardImage = String.Empty,
                OutspaceImage = String.Empty,
                BathroomText = String.Empty,
                BedroomText = String.Empty,
                OutspaceText = String.Empty,
                Description = Lorem.ParagraphByChars(550),
                Heading = String.Empty,
                GeneralText = String.Empty,
                PixangleSource = String.Empty,
                Location = String.Empty,
                Latitude = 0,
                Longitude = 0,
                TourLink = String.Empty,
                Overview = new List<Overview>() { }
            };


            return JsonConvert.SerializeObject(str);
        }

        private static string JsonBodyRaffle(PropertyResponse property)
        {
            CreateDreamHomeRequestModel req = new()
            {
                StepperCountdown = new()
                {
                    title= Lorem.Word(),
                    startAt = DateTime.Now.AddDays(-1),
                    endsAt= DateTime.Now.AddDays(1),
                    isActive= false,
                },
                Active = false,
                IsActiveDiscount = false,
                IsPopular = false,
                IsTrending = false,
                EndsAt = DateTime.Now.AddYears(1),
                StartAt = DateTime.Now.AddDays(-1),
                TicketPrice = 2,
                DefaultTickets = 5,
                IsDiscountRates = true,
                CreditsRates = new List<CreditsRate>()
                {
                    new CreditsRate()
                    {
                        Id = "0",
                        Count = 20,
                        Percent = 30
                    }
                },
                //CreditsEndDate = DateTime.Now.AddMonths(1),
                //CreditsStartDate = DateTime.Now,
                IsCreditsActive = false,
                //IsCreditsPermanent = false,
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
                    Percent = 0,
                    NewPrice = 1
                },
                DiscountCategory = "cash",
                FreeTicketsRates = new List<object>() { },
                IsFreeTicketsRates = false,
                TicketsBundles = new()
                {
                    5,
                    15,
                    50,
                    150
                },
                Title = Company.Name() +" "+ Name.LastName(),
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
                throw new ArgumentException(http.LastErrorText);
            }
            
        }

        public static void EditDreamHomeStartEndDate(SignInResponseModelAdmin token, RaffleResponse response, bool isFirst, int hoursStartAt, int hoursEndsAt)
        {
            HttpRequest req;
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
                throw new ArgumentException(http.LastErrorText);
            }
            
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
                    throw new ArgumentException(http.LastErrorText);
                }
                
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
            var response = http.LastMethodSuccess
                ? JsonConvert.DeserializeObject<RaffleResponse?>(resp?.BodyStr ?? throw new Exception("Response body is null."))
                : throw new ArgumentException(http.LastErrorText);
            
            closeEarlier = response.Raffles.OrderBy(item => item.EndsAt).FirstOrDefault();
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
            var response = http.LastMethodSuccess
                ? JsonConvert.DeserializeObject<DreamHomeResponse?>(resp?.BodyStr ?? throw new Exception("Response body is null."))
                : throw new ArgumentException(http.LastErrorText);

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
            var responseProperty = http.LastMethodSuccess
                ? JsonConvert.DeserializeObject<PropertyResponse>(respProperty?.BodyStr ?? throw new Exception("Response body is null."))
                : throw new ArgumentException(http.LastErrorText);

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
            HttpResponse respRaffle = http.SynchronousRequest(ApiEndpoints.API_CHIL, 443, true, req);
            var response = http.LastMethodSuccess 
                ? JsonConvert.DeserializeObject<RaffleResponse?>(respRaffle?.BodyStr ?? throw new Exception("Response body is null."))
                : throw new ArgumentException(http.LastErrorText);

            return response;
        }

    }
}

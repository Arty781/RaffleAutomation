using Chilkat;
using Newtonsoft.Json;
using RaffleAutomationTests.Helpers;
using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RaffleAutomationTests.APIHelpers.Admin.UsersPage
{
    public class UsersRequest
    {
        public static string JsonBody(string email)
        {
            UsersRequestModel requestModel = new()
            {
                Filter = new Filter()
                {
                    Blocked = "All",
                    SearchName = "",
                    SearchEmail = email,
                    SearchPhone = "",
                    SearchSurname = ""
                },
                Pagination = new Pagination()
                {
                    Page = 1,
                    PerPage = 100000
                },
                Sort = new Sort()
                {
                    Field = "_id",
                    Order = "asc"
                }
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        public static string JsonBodyFilterUser(int pageCount, int usersCount)
        {
            var s = (pageCount / usersCount) * usersCount;
            var d = pageCount - s;
            UsersRequestModel requestModel = new()
            {
                Filter = new Filter()
                {
                    Blocked = "All",
                    SearchName = "",
                    SearchEmail = "",
                    SearchPhone = "",
                    SearchSurname = ""
                },
                Pagination = new Pagination()
                {
                    Page = pageCount / usersCount,
                    PerPage = usersCount + d
                },
                Sort = new Sort()
                {
                    Field = "_id",
                    Order = "asc"
                }
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        public static string JsonBody()
        {
            UserOrdersRequestModel requestModel = new()
            {
                Filter = new FilterUserOrders()
                {
                    SearchField = "",
                    SearchString = "",
                    StartDate = DateTime.Now.AddYears(-5).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                    EndDate = DateTime.Now.AddYears(5).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                    Competitions = new List<object>() { }
                },
                Pagination = new Pagination()
                {
                    Page = 1,
                    PerPage = 10
                },
                Sort = new Sort()
                {
                    Field = "_id",
                    Order = "asc"
                }
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        public static string JsonBodyAddRaffle(string prizeId)
        {
            AddTicketsRequestModel requestModel = new()
            {
                Competition = "raffle",
                PrizeId = prizeId,
                TicketsCount = RandomHelper.RandomIntNumber(100)
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        public static string JsonBodyRemovetickets(OrdersResponseModel ordersIds)
        {
            DeleteOrdersRequestModel requestModel = new()
            {
                Ids = ordersIds.Orders.FirstOrDefault().OrdersIds
            };

            return JsonConvert.SerializeObject(requestModel);
        }

        public static string JsonBodyAddCredits(string time, int i)
        {
            DateTime dateNow = DateTime.Now;
            DateTime dateTomorrow = DateTime.Now.AddDays(1);
            AddCreditsRequestModel requestModel = new();
            if (time.ToLower() == "now")
            {
                string createDateOneDay = dateNow.AddDays(-30 + 1).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                string createDateThreeDays = dateNow.AddDays(-30 + 3).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                string createDateSevenDays = dateNow.AddDays(-30 + 7).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                if (i == 0)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateOneDay,
                        ExpiredDate = DateTime.Parse(createDateOneDay).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }
                else if (i == 1)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateThreeDays,
                        ExpiredDate = DateTime.Parse(createDateThreeDays).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }
                else if (i == 2)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateSevenDays,
                        ExpiredDate = DateTime.Parse(createDateSevenDays).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }

            }
            else if (time.ToLower() == "tomorrow")
            {
                string createDateOneDay = dateTomorrow.AddDays(-30 + 1).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                string createDateThreeDays = dateTomorrow.AddDays(-30 + 3).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                string createDateSevenDays = dateTomorrow.AddDays(-30 + 7).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'");
                if (i == 0)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateOneDay,
                        ExpiredDate = DateTime.Parse(createDateOneDay).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }
                else if (i == 1)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateThreeDays,
                        ExpiredDate = DateTime.Parse(createDateThreeDays).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }
                else if (i == 2)
                {
                    requestModel = new()
                    {
                        Amount = RandomHelper.RandomIntNumber(100),
                        CreatedDate = createDateSevenDays,
                        ExpiredDate = DateTime.Parse(createDateSevenDays).AddDays(30).ToString("yyyy-MM-dd'T'HH:mm:ss.fff'z'"),
                        Description = Lorem.Sentence()

                    };
                }

            }

            return JsonConvert.SerializeObject(requestModel);
        }

        public static UsersResponse? GetUser(SignInResponseModelAdmin token, string email)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/get",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBody(email), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            var response = JsonConvert.DeserializeObject<UsersResponse?>(resp.BodyStr);
            return response;
        }

        public static UsersResponse? GetLastUsers(SignInResponseModelAdmin token, int usersCount)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/get",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyFilterUser(110, 10), charset: "utf-8");

            Http http = new();

            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));
            var response = JsonConvert.DeserializeObject<UsersResponse>(resp.BodyStr);
            req = new()
            {
                HttpVerb = "POST",
                Path = $"api/users/get",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyFilterUser(response.AllCount, usersCount), charset: "utf-8");

            http = new();

            resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("Error message is " + Convert.ToString(resp.BodyStr));

            response = JsonConvert.DeserializeObject<UsersResponse?>(resp.BodyStr);
            return response;
        }

        public static OrdersResponseModel? GetUserOrders(SignInResponseModelAdmin token, string userId)
        {
            HttpRequest req = new()
            {
                HttpVerb = "POST",
                Path = $"/api/users/{userId}/orders/admin",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBody(), charset: "utf-8");
            Http http = new();
            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
            var response = JsonConvert.DeserializeObject<OrdersResponseModel?>(resp.BodyStr);

            return response;
        }

        public static AddTicketsResponseModel? AddDreamhomeTicketsToUser(SignInResponseModelAdmin token, string userId, string prizeId)
        {
            HttpRequest req = new()
            {
                HttpVerb = "PATCH",
                Path = $"/api/users/{userId}/add-tickets",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyAddRaffle(prizeId), charset: "utf-8");
            Http http = new();
            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
            var response = JsonConvert.DeserializeObject<AddTicketsResponseModel?>(resp.BodyStr);
            return response;
        }

        public static AddCreditsResponseModel? AddCreditsToUser(SignInResponseModelAdmin token, string userId, string nowOrTomorrow)
        {
            AddCreditsResponseModel? response = null;
            for (int i = 0; i < 3; i++)
            {
                HttpRequest req = new()
                {
                    HttpVerb = "PATCH",
                    Path = $"/api/credits/{userId}",
                    ContentType = "application/json"
                };
                req.AddHeader("Connection", "Keep-Alive");
                req.AddHeader("accept-encoding", "gzip, deflate, br");
                req.AddHeader("authorization", $"Bearer {token.Token}");
                req.LoadBodyFromString(JsonBodyAddCredits(nowOrTomorrow, i), charset: "utf-8");
                Http http = new();
                HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
                if (http.LastMethodSuccess != true)
                {
                    Debug.WriteLine(http.LastErrorText);
                }
                Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
                response = JsonConvert.DeserializeObject<AddCreditsResponseModel?>(resp.BodyStr);
            }
            return response;
        }

        public static void RemoveTicketsFromUser(SignInResponseModelAdmin token, OrdersResponseModel ordersIds)
        {
            HttpRequest req = new()
            {
                HttpVerb = "DELETE",
                Path = $"/api/orders/delete-many/admin",
                ContentType = "application/json"
            };
            req.AddHeader("Connection", "Keep-Alive");
            req.AddHeader("accept-encoding", "gzip, deflate, br");
            req.AddHeader("authorization", $"Bearer {token.Token}");
            req.LoadBodyFromString(JsonBodyRemovetickets(ordersIds), charset: "utf-8");
            Http http = new();
            HttpResponse resp = http.SynchronousRequest("staging-api.rafflehouse.com", 443, true, req);
            if (http.LastMethodSuccess != true)
            {
                Debug.WriteLine(http.LastErrorText);
            }
            Debug.WriteLine("response message is " + "\r\n" + Convert.ToString(resp.BodyStr));
        }

        public static void DeleteLastUser(SignInResponseModelAdmin token, UsersResponse user)
        {
            HttpRequest req = new()
            {
                HttpVerb = "DELETE",
                Path = $"api/users/{user.Users.FirstOrDefault().Id}",
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
        }

        public static void DeleteUser(SignInResponseModelAdmin token, User user)
        {
            HttpRequest req = new()
            {
                HttpVerb = "DELETE",
                Path = $"api/users/{user.Id}",
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
        }
    }
}

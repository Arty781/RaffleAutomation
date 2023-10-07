
using RimuTec.Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlaywrightAutomation.Helpers;

namespace PlaywrightAutomation.Pages.WEB.UserProfilePage
{
    public partial class UserProfile
    {
        public static async Task OpenSubscriptionsTab()
        {
            await Button.Click(tabSubscriptions);
        }

        public static async Task BuyTenPoundsSub()
        {
            await Button.Click(btn10BundleWithoutSub);
        }

        public static async Task BuyTwentyFivePoundsSub()
        {
            await Button.Click(btn25BundleWithSub);
        }

        public static async Task ClickEditPersonalDataBtn()
        {
            await Button.Click(btnEditPersonal);
            await WaitUntil.ElementIsVisible(btnSave);
        }


        public static async Task ClickEditPasswordBtn()
        {
            await Button.Click(btnEditPassword);
            await WaitUntil.ElementIsVisible(btnSave);
        }


        public static async Task ClickEditAccountBtn()
        {
            await Button.Click(btnEditAccount);
            await WaitUntil.ElementIsVisible(btnSave);
        }


        public static async Task EditPersonalData()
        {
            await InputBox.TypeText(inputFirstName, Name.FirstName());
            await InputBox.TypeText(inputLastName, Name.LastName());
            await Button.Click(btnSave);
        }


        public static async Task EditPassword(string currentPass = "Qaz11111", string newPass = "Qaz11111!", string confirmPass = "Qaz11111!")
        {
            await InputBox.TypeText(inputCurrentPassword, currentPass);
            await InputBox.TypeText(inputNewPassword, newPass);
            await InputBox.TypeText(inputConfirmPassword, confirmPass);
            await Button.Click(btnSave);
        }


        public static async Task EditAccountData()
        {
            await InputBox.TypeText(inputEmail, DateTime.Now.ToString("yyyy-MM-dThh-mm-fff") + "@putsbox.com");
            await InputBox.TypeText(inputPhone, RandomHelper.RandomPhone());
            await Button.Click(btnSave);
        }


        public static async Task OpenMyTicketsCompetitions()
        {
            await GoToPage("https://staging.rafflehouse.com/profile/tickets", tabMyTicketsCompetitions);
            await WaitUntil.ElementIsVisible(listDreamHomeHistory);
        }


        public static async Task OpenDreamHomeHistoryList()
        {
            await Button.Click(listDreamHomeHistory);
            await WaitUntil.ElementIsVisible(prizeName);
            //await Browser.Driver.WaitForTimeoutAsync(1000);
        }


        public static async Task ScrollToEndOfHistoryList(int countOrders)
        {
            await WaitUntil.ElementIsVisible(prizeName);
            for (int i = 0; i < countOrders; i++)
            {
                await (await Browser.Driver.QuerySelectorAllAsync(prizeName)).Last().ScrollIntoViewIfNeededAsync();
                await Browser.Driver.WaitForTimeoutAsync(250);
            }
        }

        public static async Task CloseDreamHomeHistoryList()
        {
            await Button.Click(listDreamHomeHistory);
            await WaitUntil.ElementIsInvisible(prizeName);
        }

        public static async Task OpenSubscriptionInProfile()
        {
            await GoToPage("https://staging.rafflehouse.com/profile/subscription", titleSubscriptionProfile);
        }


        public static async Task PauseSubscription()
        {
            await Button.ClickOnNthElement(btnDetails, 0);
            await Button.ClickOnNthElement(inputPause, 0);
            await Button.Click(btnPausePopUp);
            await WaitUntil.ElementIsVisible(textPausedSubscription);
        }


        public static async Task UnpauseSubscription()
        {
            await Button.ClickOnNthElement(btnDetails, 0);
            await Button.ClickOnNthElement(inputPause, 0);
            await Button.Click(btnUnpausePopUp);
            await WaitUntil.ElementIsVisible(textActiveSubscription);
        }


        public static async Task CancelSubscription()
        {
            await Button.ClickOnNthElement(btnDetails, 0);
            await Button.ClickOnNthElement(btnCancelSubscription, 0);
            await Button.Click(btnCancelPopUp);
            await WaitUntil.ElementIsVisible(textCancelledSubscription);
        }


        public static async Task ReactivateSubscription()
        {
            await Button.ClickOnNthElement(btnDetails, 0);
            await Button.ClickOnNthElement(btnReactivateSubscription, 0);
            await Button.Click(btnReactivatePopUp);
            await WaitUntil.ElementIsVisible(textActiveSubscription);
        }

        public static async Task VerifyValidationOnProfilePersonalDetails()
        {
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0:
                        await InputBox.TypeText(inputFirstName, "");
                        await InputBox.TypeText(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 1:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, "q");
                        await InputBox.TypeText(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 2:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, "qtweqweqwueyqwyfeasdasgdjadasdasdasgdjadasdasdasgdjadasda"); //more than 50 characters
                        await InputBox.TypeText(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 3:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, "qwe1234");
                        await InputBox.TypeText(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 4:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, "Qqweqe!@#$%");
                        await InputBox.TypeText(inputLastName, Name.LastName());
                        await Button.Click(btnSave);
                        await VerifyDisplayingFirstNameErrorMessage();
                        break;
                    case 5:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputLastName, "");
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 6:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputLastName, "q");
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 7:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputLastName, "qtweqweqwueyqwyfeasdasgdjadasdasdasgdjadasdasdasgdjadasda"); //more than 50 characters
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 8:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputLastName, "qqweq123132");
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;
                    case 9:
                        await WaitUntil.ElementIsVisible(inputFirstName);
                        await InputBox.TypeText(inputFirstName, Name.FirstName());
                        await InputBox.TypeText(inputLastName, "QWaass$%^&*");
                        await Button.Click(btnSave);
                        await VerifyDisplayingLastNameErrorMessage();
                        break;

                }
            }
        }


        public static async Task VerifyValidationOnProfilePassword()
        {
            for (int i = 0; i < 11; i++)
            {
                switch (i)
                {
                    case 0:
                        await InputBox.TypeText(inputCurrentPassword, "");
                        await InputBox.TypeText(inputNewPassword, "Qaz11111!");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 1:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11");
                        await InputBox.TypeText(inputNewPassword, "Qaz11111!");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 2:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz123456789012345678");
                        await InputBox.TypeText(inputNewPassword, "Qaz11111!");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 3:
                        await InputBox.TypeText(inputCurrentPassword, "Qwertyui");
                        await InputBox.TypeText(inputNewPassword, "Qaz11111!");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingOldPasswordErrorMessage();
                        break;
                    case 4:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11111");
                        await InputBox.TypeText(inputNewPassword, "");
                        await InputBox.TypeText(inputConfirmPassword, "");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 5:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11111");
                        await InputBox.TypeText(inputNewPassword, "Qaz11");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 6:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11111");
                        await InputBox.TypeText(inputNewPassword, "Qaz123456789012345678");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 7:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11111");
                        await InputBox.TypeText(inputNewPassword, "Qwertyui");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 8:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11111");
                        await InputBox.TypeText(inputNewPassword, "123456789");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 9:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11111");
                        await InputBox.TypeText(inputNewPassword, "!@#$%^^&!");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111!");
                        await Button.Click(btnSave);
                        await VerifyDisplayingNewPasswordErrorMessage();
                        break;
                    case 10:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11111");
                        await InputBox.TypeText(inputNewPassword, "Qaz11111!");
                        await InputBox.TypeText(inputConfirmPassword, "");
                        await Button.Click(btnSave);
                        await VerifyDisplayingConfirmPasswordErrorMessage();
                        break;
                    case 11:
                        await InputBox.TypeText(inputCurrentPassword, "Qaz11111");
                        await InputBox.TypeText(inputNewPassword, "Qaz11111!");
                        await InputBox.TypeText(inputConfirmPassword, "Qaz11111");
                        await Button.Click(btnSave);
                        await VerifyDisplayingConfirmPasswordErrorMessage();
                        break;

                }
            }
        }


        public static async Task VerifyValidationOnProfileAccountDetails()
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        await InputBox.TypeText(inputEmail, "");
                        await InputBox.TypeText(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 1:
                        await InputBox.TypeText(inputEmail, string.Join(" qatester-", DateTime.Now.ToString("yyyy-MM-dThh-mm-ss"), "  ", "@putsbox.com "));
                        await InputBox.TypeText(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 2:
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "putsbox.com");
                        await InputBox.TypeText(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 3:
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@@putsbox.com");
                        await InputBox.TypeText(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 4:
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox");
                        await InputBox.TypeText(inputPhone, "953214567");
                        await Button.Click(btnSave);
                        await VerifyDisplayingEmailErrorMessage();
                        break;
                    case 5:
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "");
                        await Button.Click(btnSave);
                        await VerifyDisplayingPhoneErrorMessage();
                        break;
                    case 6:
                        await InputBox.TypeText(inputEmail, "qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
                        await InputBox.TypeText(inputPhone, "9532145");
                        await Button.Click(btnSave);
                        await VerifyDisplayingPhoneErrorMessage();
                        break;

                }
            }
        }

        public static async Task VerifyDisplayingFirstNameErrorMessage()
        {

            await WaitUntil.ElementIsVisible(textFirstNameErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textFirstNameErrorMessage)).IsVisibleAsync().Result, Is.True, "First name error message is not displayed");
        }


        public static async Task VerifyDisplayingLastNameErrorMessage()
        {

            await WaitUntil.ElementIsVisible(textLastNameErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textLastNameErrorMessage)).IsVisibleAsync().Result, Is.True, "Last name error message is not displayed");
        }


        public static async Task VerifyDisplayingEmailErrorMessage()
        {

            await WaitUntil.ElementIsVisible(textEmailErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textEmailErrorMessage)).IsVisibleAsync().Result, Is.True, "Email error message is not displayed");
        }


        public static async Task VerifyDisplayingPhoneErrorMessage()
        {

            await WaitUntil.ElementIsVisible(textPhoneErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textPhoneErrorMessage)).IsVisibleAsync().Result, Is.True, "Phone error message is not displayed");
        }


        public static async Task VerifyDisplayingOldPasswordErrorMessage()
        {

            await WaitUntil.ElementIsVisible(textOldPasswordErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textOldPasswordErrorMessage)).IsVisibleAsync().Result, Is.True, "Old Password error message is not displayed");
        }


        public static async Task VerifyDisplayingNewPasswordErrorMessage()
        {

            await WaitUntil.ElementIsVisible(textNewPasswordErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textNewPasswordErrorMessage)).IsVisibleAsync().Result, Is.True, "New Password error message is not displayed");
        }


        public static async Task VerifyDisplayingConfirmPasswordErrorMessage()
        {

            await WaitUntil.ElementIsVisible(textConfirmPasswordErrorMessage);
            Assert.That((await Browser.Driver.QuerySelectorAsync(textConfirmPasswordErrorMessage)).IsVisibleAsync().Result, Is.True, "Confirm Password error message is not displayed");
        }

        
        public static async Task VerifyDisplayingSuccessfullToaster()
        {
            await WaitUntil.ElementIsVisible(SuccessUpdateDialog);
            Assert.That((await Browser.Driver.QuerySelectorAsync(SuccessUpdateDialog)).IsVisibleAsync().Result, Is.True, "Success Update Dialog is not displayed");
        }

        
        public static async Task VerifyUpdatePasswordSuccessfullToaster()
        {
            await WaitUntil.ElementIsVisible(SuccessUpdatePasswordDialog);
            Assert.That((await Browser.Driver.QuerySelectorAsync(SuccessUpdatePasswordDialog)).IsVisibleAsync().Result, Is.True, "Success Update Password Dialog is not displayed");
        }

        
        public static async Task VerifyAddingTickets(double price, int countOrders)
        {
            await WaitUntil.ElementIsVisible(prizePrice);
            for (int i = 0; i < countOrders; i++)
            {
                await (await Browser.Driver.QuerySelectorAllAsync(prizeName)).Last().ScrollIntoViewIfNeededAsync();
                await Browser.Driver.WaitForTimeoutAsync(250);
            }
            var item = await OrderHistoryVerificator.GetOrderHistory((await Browser.Driver.QuerySelectorAllAsync(prizePrice)).ToList(), countOrders);
            Assert.That((double)item.Item2, Is.EqualTo(price), $"Order total is not matched. Expected {price}, but was {(double)item.Item2}");

        }

        public class OrderHistoryVerificator
        {
            private static async Task<(List<RequestModels.Profile.OrderHistory>, int)> SplitIntoRows(List<IElementHandle> inputList, int elementsPerRow, int maxRows)
            {
                List<RequestModels.Profile.OrderHistory> historyList = new();
                int sum = 0;
                int numRows = inputList.Count / elementsPerRow;
                if (numRows < maxRows)
                {
                    throw new Exception("Not enough rows available.");
                }
                numRows = Math.Min(maxRows, numRows); // Calculate the actual number of rows to include
                for (int i = 0; i < numRows * elementsPerRow; i += elementsPerRow)
                {
                    IElementHandle prizeElement = inputList[i];
                    IElementHandle purchaseDateElement = inputList[i + 1];
                    IElementHandle numTicketsElement = inputList[i + 2];
                    IElementHandle priceElement = inputList[i + 3];

                    RequestModels.Profile.OrderHistory item = new()
                    {
                        PRIZE = await prizeElement.TextContentAsync() ?? throw new Exception("Prize is null"),
                        PURCHASE_DATE = await purchaseDateElement.TextContentAsync() ?? throw new Exception("Date is null"),
                        NUM_TICKETS = int.Parse(await numTicketsElement.TextContentAsync() ?? throw new Exception("Tickets is null")),
                        PRICE = int.Parse(priceElement.TextContentAsync().Result[1..])
                    };
                    sum += item.PRICE; // Accumulate the price
                    historyList.Add(item);
                }

                int totalPriceSum = sum;

                return (historyList, totalPriceSum);
            }

            public static async Task<(List<RequestModels.Profile.OrderHistory>, int)> GetOrderHistory(List<IElementHandle> inputList, int maxRows)
            {
                var history = await SplitIntoRows(inputList, 4, maxRows);
                List<RequestModels.Profile.OrderHistory> result = history.Item1;
                int totalPriceSum = history.Item2;

                return (result, totalPriceSum);
            }


        }

        //public static async Task VerifyCancelationEmail(string email, string name)
        //{
        //    EmailVerificator.VerifyCancelationEmail(email, name);

        //    return this;
        //}

        //public static async Task VerifyPauseEmail(string email, string name)
        //{
        //    EmailVerificator.VerifyPauseEmail(email, name);

        //    return this;
        //}

        //public static async Task VerifyUnpauseEmail(string email, string name, string charity, int activeRaffles)
        //{
        //    EmailVerificator.VerifyUnpauseEmail(email, name, charity, activeRaffles);

        //    return this;
        //}

        //public static async Task VerifyInitialEmailAuth(string email, string name, int quantity, double value, string charity)
        //{
        //    EmailVerificator.VerifyInitialEmailAuth(email, name, charity);

        //    return this;
        //}

        //public static async Task VerifyInitialEmailUnauth(string email, string name, int quantity, double value, string charity, int activeRaffles)
        //{
        //    EmailVerificator.VerifyInitialEmailUnauth(email, name, charity, activeRaffles);

        //    return this;
        //}

        //public static async Task WaitUntilScriptRuning(int activeRaffles)
        //{
        //    var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
        //    foreach (var user in users)
        //    {
        //        var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
        //        var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
        //        var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
        //        //Assert.That(ordersList.Count >= 1, $"New order is not created, current subscription orders count is \"{ordersList.Count}\"");

        //        foreach (var subscription in subscriptionList)
        //        {
        //            Assert.IsNotNull(subscription.Refference);
        //            Assert.IsNotNull(subscription.CardSource);
        //            Assert.IsNotNull(subscription.CheckoutId);
        //        }
        //        EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
        //                            user.Name,
        //                            "None Selected",
        //                            activeRaffles);
        //        EmailVerificator.VerifyUnpauseEmail(user.Email,
        //                            user.Name,
        //                            "None Selected",
        //                            activeRaffles);
        //    }

        //    return this;
        //}
    }
}

﻿

using RimuTec.Faker;
using static RaffleAutomationTests.Helpers.AppDbHelper;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Profile
    {
        [AllureStep("Click Edit Personal data button")]
        public Profile ClickEditPersonalDataBtn()
        {
            Button.ClickJS(btnEditPersonal);
            return this;
        }

        [AllureStep("Click Edit Password button")]
        public Profile ClickEditPasswordBtn()
        {
            Button.ClickJS(btnEditPassword);
            return this;
        }

        [AllureStep("Click Edit Account button")]
        public Profile ClickEditAccountBtn()
        {
            Button.ClickJS(btnEditAccount);
            return this;
        }

        [AllureStep("Edit Personal data")]
        public Profile EditPersonalData()
        {
            InputBox.Element(inputFirstName, 10, Name.FirstName());
            InputBox.Element(inputLastName, 10, Name.LastName());
            Button.ClickJS(btnSave);
            return this;
        }

        [AllureStep("Edit Password")]
        public Profile EditPassword(string currentPass = "Qaz11111", string newPass = "Qaz11111!", string confirmPass = "Qaz11111!")
        {
            InputBox.Element(inputCurrentPassword, 10, currentPass);
            InputBox.Element(inputNewPassword, 10, newPass);
            InputBox.Element(inputConfirmPassword, 10, confirmPass);
            Button.ClickJS(btnSave);
            return this;
        }

        [AllureStep("Edit Account Data")]
        public Profile EditAccountData()
        {
            WaitUntil.CustomElementIsVisible(btnSave);
            InputBox.Element(inputEmail, 10, DateTime.Now.ToString("yyyy-MM-dThh-mm-fff") + "@putsbox.com");
            InputBox.Element(inputPhone, 10, RandomHelper.RandomPhone());
            Button.ClickJS(btnSave);
            return this;
        }

        [AllureStep("Open Order History page")]
        public Profile OpenMyTicketsCompetitions()
        {
            Browser._Driver.Navigate().GoToUrl("https://staging.rafflehouse.com/profile/tickets");
            WaitUntil.CustomElementIsVisible(tabMyTicketsCompetitions);
            WaitUntil.CustomElementIsVisible(listDreamHomeHistory);
            return this;
        }

        [AllureStep("Open Dream Home History list")]
        public Profile OpenDreamHomeHistoryList()
        {

            Button.Click(listDreamHomeHistory);
            WaitUntil.CustomElementIsVisible(prizeName);
            WaitUntil.WaitSomeInterval(1000);
            return this;
        }

        [AllureStep("Scroll To End Of List")]
        public Profile ScrollToEndOfHistoryList(int countOrders)
        {
            WaitUntil.CustomElementIsVisible(prizeName);
            for (int i = 0; i < countOrders; i++)
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Browser._Driver;
                string script = "arguments[0].scrollTop += 500;";
                jsExecutor.ExecuteScript(script, listHistory);
                WaitUntil.WaitSomeInterval(250);
            }
            return this;
        }

        [AllureStep("Close Dream Home History list")]
        public Profile CloseDreamHomeHistoryList()
        {

            Button.Click(listDreamHomeHistory);
            WaitUntil.CustomElevemtIsInvisible(prizeName);
            return this;
        }

        [AllureStep("Open Weekly History list")]
        public Profile OpenWeeklyHistoryList()
        {

            Button.Click(listWeeklyHistory);
            WaitUntil.CustomElementIsVisible(prizeName);
            WaitUntil.WaitSomeInterval(1000);
            return this;
        }

        [AllureStep("Close Weekly History list")]
        public Profile CloseWeeklyHistoryList()
        {

            Button.Click(listWeeklyHistory);
            WaitUntil.CustomElevemtIsInvisible(prizeName);
            return this;
        }

        [AllureStep("Open Fixed Odds History list")]
        public Profile OpenFixedOddsList()
        {

            Button.Click(listWeeklyHistory);
            WaitUntil.CustomElementIsVisible(prizeName);
            WaitUntil.WaitSomeInterval(1000);
            return this;
        }

        [AllureStep("Close Fixed Odds History list")]
        public Profile CloseFixedOddsList()
        {

            Button.Click(listWeeklyHistory);
            WaitUntil.CustomElevemtIsInvisible(prizeName);
            return this;
        }

        [AllureStep("Open Subscription in Profile")]
        public Profile OpenSubscriptionInProfile()
        {
            Browser._Driver.Navigate().GoToUrl("https://staging.rafflehouse.com/profile/subscription");
            Browser._Driver.Navigate().Refresh();
            WaitUntil.CustomElementIsVisible(titleSubscriptionProfile);
            return this;
        }

        [AllureStep("Pause subscription")]
        public Profile PauseSubscription()
        {
            Button.Click(btnDetails.FirstOrDefault());
            Button.Click(inputPause.FirstOrDefault());
            Button.Click(btnPausePopUp);
            WaitUntil.WaitSomeInterval();
            WaitUntil.CustomElementIsVisible(titleSubscriptionStatus.Where(t=>t.Text == "Paused Subscription").First());
            return this;
        }

        [AllureStep("Unpause subscription")]
        public Profile UnpauseSubscription()
        {
            Button.Click(btnDetails.FirstOrDefault());
            Button.Click(inputPause.FirstOrDefault());
            Button.Click(btnUnpausePopUp);
            WaitUntil.WaitSomeInterval();
            WaitUntil.CustomElementIsVisible(titleSubscriptionStatus.Where(t => t.Text == "Active Subscription").First());
            return this;
        }

        [AllureStep("Cancel subscription")]
        public Profile CancelSubscription()
        {
            Button.Click(btnDetails.FirstOrDefault());
            Button.Click(btnCancelSubscription.FirstOrDefault());
            Button.Click(btnCancelPopUp);
            WaitUntil.WaitSomeInterval();
            WaitUntil.CustomElementIsVisible(titleSubscriptionStatus.Where(t => t.Text == "Cancelled Subscription").First());
            return this;
        }

        [AllureStep("Reactivate subscription")]
        public Profile ReactivateSubscription()
        {
            Button.Click(btnDetails.FirstOrDefault());
            Button.Click(btnReactivateSubscription.FirstOrDefault());
            Button.Click(btnReactivatePopUp);
            WaitUntil.WaitSomeInterval();
            WaitUntil.CustomElementIsVisible(titleSubscriptionStatus.Where(t => t.Text == "Active Subscription").First());
            return this;
        }

        public Profile VerifyCancelationEmail(string email, string name)
        {
            EmailVerificator.VerifyCancelationEmail(email, name);

            return this;
        }

        public Profile VerifyPauseEmail(string email, string name)
        {
            EmailVerificator.VerifyPauseEmail(email, name);

            return this;
        }

        public Profile VerifyUnpauseEmail(string email, string name, int quantity, double value, string charity)
        {
            EmailVerificator.VerifyUnpauseEmail(email, name, quantity, value, charity);

            return this;
        }

        public Profile VerifyInitialEmailAuth(string email, string name, int quantity, double value, string charity)
        {
            EmailVerificator.VerifyInitialEmailAuth(email, name, quantity, value, charity);

            return this;
        }

        public Profile VerifyInitialEmailUnauth(string email, string name, int quantity, double value, string charity)
        {
            EmailVerificator.VerifyInitialEmailUnauth(email, name, quantity, value, charity);

            return this;
        }

        public Profile WaitUntilScriptRuning()
        {
            var users = AppDbHelper.Users.GetAllUsers().Where(x => x.Email.Contains("@putsbox.com")).Select(x => x).ToList();
            foreach (var user in users)
            {
                var usera = AppDbHelper.Users.GetUserByEmail(user.Email);
                var subscriptionList = AppDbHelper.Subscriptions.GetAllSubscriptionsByUserId(usera);
                var ordersList = AppDbHelper.Orders.GetAllSubscriptionOrdersByUserId(usera);
                //Assert.That(ordersList.Count >= 1, $"New order is not created, current subscription orders count is \"{ordersList.Count}\"");

                foreach (var subscription in subscriptionList)
                {
                    Assert.IsNotNull(subscription.Refference);
                    Assert.IsNotNull(subscription.CardSource);
                    Assert.IsNotNull(subscription.CheckoutId);
                }
                EmailVerificator.VerifyMonthlyEmailAuth(user.Email,
                                    user.Name,
                                    (int)(subscriptionList.Where(x => x.Status == "ACTIVE" && x.NextPurchaseDate < DateTime.Now).Select(x => x.NumOfTickets).First() + subscriptionList.Where(x => x.Status == "ACTIVE" && x.NextPurchaseDate < DateTime.Now).Select(x => x.Extra).First()),
                                    (double)subscriptionList.Where(x => x.Status == "ACTIVE" && x.NextPurchaseDate < DateTime.Now).Select(x => x.TotalCost / 100).First(),
                                    "None Selected");
                EmailVerificator.VerifyUnpauseEmail(user.Email,
                                    user.Name,
                                    (int)(subscriptionList.Where(x => x.Status == "ACTIVE" && x.PauseEnd == null).Select(x => x.NumOfTickets).First() + subscriptionList.Where(x => x.Status == "ACTIVE" && x.PauseEnd == null).Select(x => x.Extra).First()),
                                    (double)subscriptionList.Where(x => x.Status == "ACTIVE" && x.PauseEnd == null).Select(x => x.TotalCost / 100).First(),
                                    "None Selected");
            }

            return this;
        }

    }
}

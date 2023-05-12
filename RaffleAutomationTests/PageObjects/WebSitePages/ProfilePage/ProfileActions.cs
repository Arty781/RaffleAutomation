

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
        public Profile EditPassword()
        {
            InputBox.Element(inputCurrentPassword, 10, "Qaz11111");
            InputBox.Element(inputNewPassword, 10, "Qaz11111!");
            InputBox.Element(inputConfirmPassword, 10, "Qaz11111!");
            Button.ClickJS(btnSave);
            return this;
        }

        [AllureStep("Edit Password")]
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

        public Profile VerifyCancelationEmail(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription cancellation receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.CANCEL);

            

            return this;
        }

        public Profile VerifyPauseEmail(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Paused subscription").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.PAUSE);

            return this;
        }

        public Profile VerifyInitialEmailAuth(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.INITIAL_AUTH);

            return this;
        }

        public Profile VerifyInitialEmailUnauth(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription tickets receipt").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.INITIAL_UNAUTH);

            return this;
        }

        public Profile VerifyUnpauseEmail(string email)
        {
            var emailsList = Elements.GgetAllEmailData(email);
            SubscriptionsRequest.CheckEmailsCountFor17Minutes(emailsList, email);
            emailsList = Elements.GgetAllEmailData(email);
            var id = emailsList.Where(x => x.subject == "Subscription pause reactivation").Select(q => q.id).FirstOrDefault();
            var emailInitial = Elements.GgetHtmlBody(email, id);
            ParseHelper.ParseHtmlAndCompare(emailInitial, SubscriptionEmailsTemplate.UNPAUSE);

            return this;
        }
    }
}

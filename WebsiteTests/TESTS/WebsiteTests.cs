namespace RaffleHouseAutomation.WebSiteTests
{
    [TestFixture]
    [AllureNUnit]
    public class Demo : TestBaseWeb
    {
        [Test]
        public void Demotest()
        {
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            for (int q = 0; q < 100; q++)
            {
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                WaitUntil.WaitSomeInterval(250);
            }

            Pages.Basket
                .ClickCartBtn();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
        }
    }

    [TestFixture]
    [AllureNUnit]
    public class Authorization : TestBaseWeb
    {


        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Login")]
        public void LoginByEmail()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void RegisterNewUser()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignUpPage();
            Pages.SignUp
                .EnterUserData();
            string email = SignUp.GetEmail();
            Pages.SignUp
                .ClickSignUpBtn()
                .VerifyEmail(email);

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var user = UsersRequest.GetUser(tokenAdmin, email);
            UsersRequest.DeleteUser(tokenAdmin, user.Users.FirstOrDefault().Id);
            #endregion

        }

        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void EditUserData()
        {
            #region Preconditions
            var response = SignUpRequest.RegisterNewUser();
            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD)
                .VerifyIsSignIn();
            Pages.Profile
                .EditPersonalData()
                .VerifyDisplayingToaster();
            Pages.Profile
                .EditPassword()
                .VerifyDisplayingToaster();
            Pages.Profile
                .EditAccountData()
                .VerifyDisplayingToaster();

            #region Postconditions
            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            UsersRequest.DeleteUser(tokenAdmin, response.User.Id);
            #endregion

        }

    }
    [TestFixture]
    [AllureNUnit]
    public class Payment : TestBaseWeb
    {
        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void MakePurchaseWithDelayAndClosingTab()
        {
            var response = SignUpRequest.RegisterNewUser();
            Pages.Common
                    .CloseCookiesPopUp();
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                    .OpenSignInPage();
            Pages.SignIn
                    .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.Home
                    .OpenHomePage();
            Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectFirstBundleBtn();
            Pages.Common
                    .CloseTabAndWait30Seconds();
            Pages.Home
                    .OpenHomePage();
            Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectFirstBundleBtn();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void PurchaseDreamHome()
        {
            var token = SignInRequestWeb.MakeSignIn(Credentials.LOGIN, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            for (int i = 0; i < 10; i++)
            {
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                WaitUntil.WaitSomeInterval(250);
            }

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
               .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(Credentials.LOGIN, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            for (int i = 0; i < 2; i++)
            {

                if (i == 0)
                {
                    Pages.Home
                    .OpenHomePage();
                    Element
                        .Action(Keys.End);
                    Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectFirstBundleBtn();
                }
                else if (i == 1)
                {
                    Pages.Home
                    .OpenHomePage();
                    Element
                        .Action(Keys.End);
                    Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectSecondBundleBtn();
                }
                else if (i == 2)
                {
                    Pages.Home
                    .OpenHomePage();
                    Element
                        .Action(Keys.End);
                    Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectForthBundleBtn();
                }
                else if (i == 3)
                {
                    Pages.Home
                    .OpenHomePage();
                    Element
                        .Action(Keys.End);
                    Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectThirdBundleBtn();
                }
                else if (i == 4)
                {
                    Pages.Home
                    .OpenHomePage();
                    Element
                        .Action(Keys.End);
                    Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectForthBundleBtn();
                }
                else if (i == 5)
                {
                    Pages.Home
                    .OpenHomePage();
                    Element
                        .Action(Keys.End);
                    Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectFirstBundleBtn();
                }
                else if (i > 5)
                {
                    Pages.Home
                    .OpenHomePage();
                    Element
                        .Action(Keys.End);
                    Pages.Home
                    .OpenDreamTicketSelector()
                    .SelectFirstBundleBtn();
                }
            }

            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SignUpAddTicketsMakePurchase()
        {
            Pages.Common
                .CloseCookiesPopUp();
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.Basket
                .ClickCartBtn();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            for (int i = 0; i < 5; i++)
            {
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                WaitUntil.WaitSomeInterval(250);
            }
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
            Pages.Basket
                .ClickCartBtn();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
        }

        [Test]
        [Category("E2E")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SignUpAddReferralsAndTicketsMakePurchase()
        {
            Pages.Common
                .CloseCookiesPopUp();
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
            WaitUntil.WaitSomeInterval(250);
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.Basket
                .ClickCartBtn();
            double totalOrder = Pages.Basket.GetOrderTotal();
            Pages.Basket
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.ThankYou
                .VerifyThankYouPageIsDisplayed();
            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList()
                .VerifyAddingTickets(totalOrder);
            Pages.Header
                .DoLogout();
            for (int i = 0; i < 10; i++)
            {
                var responseReferral = SignUpRequest.RegisterNewReferral(response.User.ReferralKey);
                var tokenReferral = SignInRequestWeb.MakeSignIn(responseReferral.User.Email, Credentials.PASSWORD);
                var prizesListReferral = CountdownRequestWeb.GetDreamHomeCountdown(tokenReferral);
                DreamHomeOrderRequestWeb.AddDreamhomeTickets(tokenReferral, prizesListReferral.FirstOrDefault());
                WaitUntil.WaitSomeInterval(250);
                Pages.Header
                    .OpenSignInPage();
                Pages.SignIn
                    .EnterLoginAndPass(responseReferral.User.Email, Credentials.PASSWORD);
                Pages.Basket
                    .ClickCartBtn();
                double totalOrderReferral = Pages.Basket.GetOrderTotal();
                Pages.Basket
                    .ClickCheckoutNowBtn()
                    .EnterCardDetails()
                    .ClickPayNowBtn()
                    .ConfirmPurchaseStage();
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
                Pages.Profile
                    .OpenMyTicketsCompetitions()
                    .OpenDreamHomeHistoryList()
                    .VerifyAddingTickets(totalOrderReferral);
                Pages.Header
                    .DoLogout();
            }
        }

        [Test]
        [Category("Payment")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void GetPurchaseDreamHome()
        {
            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            for (int i = 0; i <= 0; i++)
            {
                for (int q = 0; q < RandomHelper.RandomIntNumber(2); q++)
                {
                    DreamHomeOrderRequestWeb.AddDreamhomeTickets(token, prizesList.FirstOrDefault());
                    WaitUntil.WaitSomeInterval(250);
                }

                Pages.Basket
                    .ClickCartBtn();
                Pages.Basket
                    .ClickCheckoutNowBtn()
                    .EnterCardDetails()
                    .ClickPayNowBtn()
                    .ConfirmPurchaseStage();
                Pages.ThankYou
                    .VerifyThankYouPageIsDisplayed();
            }

            Pages.Profile
                .OpenMyTicketsCompetitions()
                .OpenDreamHomeHistoryList();
        }

    }

    [TestFixture]
    [AllureNUnit]
    public class CheckingTextsOnPages : TestBaseWeb
    {
        [Test, Category("Home")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifiedHomePage()
        {
            Pages.Common
                .CloseCookiesPopUp();
            Pages.Home
                .OpenHomePage(WebEndpoints.WEBSITE_HOST)
                .VerifySecondaryBannerTitle()
                .VerifySecondaryBannerSubitle()
                .VerifyBottomSliderTitle()
                .VerifyBottomSliderSubitle();
            Element.Action(Keys.End);
            Pages.Home
                .VerifyInfoBlockTitles()
                .VerifyInfoBlockParagraphs()
                .VerifyHowItWorksTitle()
                .VerifyHowItWorksParagraph()
                .VerifyHowItWorksStepsTitles()
                .VerifyHowItWorksStepsParagraphs();

        }

        [Test, Category("Footer")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifiedDisplayingFooterElements()
        {
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Home
                .OpenHomePage(WebEndpoints.WEBSITE_HOST);
            Pages.Footer
                .VerifyIsDisplayedFooterTitle()
                .VerifyIsDisplayedFooterParagraph()
                .VerifyIsDisplayedContactLinks()
                .VerifyIsDisplayedSponsorLinks();
            Pages.Header
                .OpenWinnersPage();
            Pages.Footer
                .VerifyIsDisplayedFooterTitle()
                .VerifyIsDisplayedFooterParagraph()
                .VerifyIsDisplayedContactLinks()
                .VerifyIsDisplayedSponsorLinks();
            Pages.Header
                .OpenCartPage();
            Pages.Footer
                .VerifyIsDisplayedFooterTitle()
                .VerifyIsDisplayedFooterParagraph()
                .VerifyIsDisplayedContactLinks()
                .VerifyIsDisplayedSponsorLinks();
            Pages.Header
                .OpenPostPage();
            Pages.Footer
                .VerifyIsDisplayedFooterTitle()
                .VerifyIsDisplayedFooterParagraph()
                .VerifyIsDisplayedContactLinks()
                .VerifyIsDisplayedSponsorLinks();
        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifyDisplayedWinners2019()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[0]);
            Pages.Header
                .OpenWinnersPage();
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Winners
                .FilterWinnersByYear(winners.Years[0])
                .ScrollToEndOfList(winners.AllCount)
                .VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifyDisplayedWinners2020()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[1]);
            Pages.Header
                .OpenWinnersPage();
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Winners
                .FilterWinnersByYear(winners.Years[1])
                .ScrollToEndOfList(winners.AllCount)
                .VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifyDisplayedWinners2021()
        {
            var winners = WinnersRequest.GetAllWinners();
            winners = WinnersRequest.GetAllWinnersByYear(winners.Years[2]);
            Pages.Header
                .OpenWinnersPage();
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Winners
                .FilterWinnersByYear(winners.Years[2])
                .ScrollToEndOfList(winners.AllCount)
                .VerifyDisplayedFilteredWinnersByYear(winners);

        }

        [Test, Category("Winners")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Home Page")]
        public void VerifyDisplayedCTACards()
        {
            var winners = WinnersRequest.GetAllWinners();
            Pages.Header
                .OpenWinnersPage();
            Pages.Common
               .CloseCookiesPopUp();
            Pages.Winners
                .ScrollToEndOfList(winners.AllCount)
                .VerifyDisplayedCTAButtons(winners.AllCount);

        }
    }

    [TestFixture]
    [AllureNUnit]
    public class ErrorPaymentTests : TestBaseWeb
    {
        #region Test displaying of error messages

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void InsufientFundsError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 151);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            var userOrders = UsersRequest.GetUserOrders(tokenAdmin, users.Users.FirstOrDefault().Id);
            UsersRequest.RemoveTicketsFromUser(tokenAdmin, userOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void RestrictedCardError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 62);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            var userOrders = UsersRequest.GetUserOrders(tokenAdmin, users.Users.FirstOrDefault().Id);
            UsersRequest.RemoveTicketsFromUser(tokenAdmin, userOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void BadTrackDataError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 154);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void SecurityVioLationError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 163);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            var userOrders = UsersRequest.GetUserOrders(tokenAdmin, users.Users.FirstOrDefault().Id);
            UsersRequest.RemoveTicketsFromUser(tokenAdmin, userOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        [Test]
        [Category("Test displaying of Errors")]
        [AllureTag("Regression")]
        [AllureOwner("Artem Sukharevskyi")]
        [AllureSeverity(SeverityLevel.critical)]
        [Author("Artem", "qatester91311@gmail.com")]
        [AllureSuite("Client")]
        [AllureSubSuite("Payment")]
        public void InvalidTransactionError()
        {
            #region Preconditions

            var tokenAdmin = SignInRequestAdmin.MakeAdminSignIn(Credentials.LOGIN_ADMIN, Credentials.PASSWORD_ADMIN);
            var dreamResponse = DreamHomeRequest.GetActiveDreamHome(tokenAdmin);
            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 0.16666666, 0.01);

            var response = SignUpRequest.RegisterNewUser();
            var token = SignInRequestWeb.MakeSignIn(response.User.Email, Credentials.PASSWORD);
            var basketOrders = BasketRequest.GetBasketOrders(token);
            BasketRequest.DeleteOrders(token, basketOrders);
            var prizesList = CountdownRequestWeb.GetDreamHomeCountdown(token);
            DreamHomeOrderRequestWeb.AddDreamhomeTicketsForError(token, prizesList.FirstOrDefault(), 12);
            WaitUntil.WaitSomeInterval(250);

            #endregion

            Pages.Common
                .CloseCookiesPopUp();
            Pages.Header
                .OpenSignInPage();
            Pages.SignIn
                .EnterLoginAndPass(response.User.Email, Credentials.PASSWORD);
            Pages.SignIn
                .VerifyIsSignIn();
            Pages.Basket
                .ClickCartBtn()
                .ClickCheckoutNowBtn()
                .EnterCardDetails()
                .ClickPayNowBtn()
                .ConfirmPurchaseStage();
            Pages.Basket
                .VerifyErrorMessageIsDisplayed();

            #region Postconditions

            DreamHomeRequest.EditTiketPriceInDreamHome(tokenAdmin, dreamResponse, 1.6666666, 2);
            var users = UsersRequest.GetUser(tokenAdmin, response.User.Email);
            var userOrders = UsersRequest.GetUserOrders(tokenAdmin, users.Users.FirstOrDefault().Id);
            UsersRequest.RemoveTicketsFromUser(tokenAdmin, userOrders);
            UsersRequest.DeleteLastUser(tokenAdmin, users);

            #endregion
        }

        #endregion
    }
}
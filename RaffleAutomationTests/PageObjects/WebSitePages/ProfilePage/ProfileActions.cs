using NUnit.Allure.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using RimuTec.Faker;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Profile
    {
        [AllureStep("Edit Personal data")]
        public Profile EditPersonalData()
        {
            Button.ClickJS(EditPersonalBtn);
            InputBox.Element(FirstNameInput, 10, Name.FirstName());
            InputBox.Element(LastNameInput, 10, Name.LastName());
            Button.ClickJS(btnSave);
            return this;
        }

        [AllureStep("Displayed error message")]
        public Profile EnterFirstnameWithMore50Characters()
        {
            Button.ClickJS(EditPersonalBtn);
            InputBox.Element(FirstNameInput, 10, Lorem.ParagraphByChars(51).Trim(' '));
            InputBox.Element(LastNameInput, 10, Name.LastName());
            Button.ClickJS(btnSave);
            Assert.IsTrue(textErrorMessage.Displayed, "Error message is not displayed");
            InputBox.Element(FirstNameInput, 10, Name.FirstName());
            Button.ClickJS(btnSave);
            return this;
        }

        [AllureStep("Displayed error message")]
        public Profile EnterLastnameWithMore50Characters()
        {
            Button.ClickJS(EditPersonalBtn);
            InputBox.Element(FirstNameInput, 10, Name.FirstName());
            InputBox.Element(LastNameInput, 10, Lorem.ParagraphByChars(51).Trim(' '));
            Button.ClickJS(btnSave);
            Assert.IsTrue(textErrorMessage.Displayed, "Error message is not displayed");
            InputBox.Element(LastNameInput, 10, Name.LastName());
            Button.ClickJS(btnSave);
            return this;
        }

        [AllureStep("Edit Password")]
        public Profile EditPassword()
        {
            Button.ClickJS(EditPasswordBtn);
            InputBox.Element(CurrentPasswordInput, 10, "Qaz11111");
            InputBox.Element(NewPasswordInput, 10, "Qaz11111!");
            InputBox.Element(ConfirmPasswordInput, 10, "Qaz11111!");
            Button.ClickJS(btnSave);
            return this;
        }

        [AllureStep("Edit Password")]
        public Profile EditAccountData()
        {
            Button.ClickJS(btnEditAccount);
            WaitUntil.CustomElementIsVisible(btnSave);
            Element.Action(Keys.End);
            cbbxCountry.Click();
            Button.ClickCountryJS(inputCountry);
            InputBox.Element(inputPhone, 10, "953214567");
            btnSave.SendKeys("");
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
    }
}

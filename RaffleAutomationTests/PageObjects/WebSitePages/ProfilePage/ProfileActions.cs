using NUnit.Allure.Steps;
using OpenQA.Selenium;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class Profile
    {
        [AllureStep("Edit Personal data")]
        public Profile EditPersonalData()
        {
            Button.Click(EditPersonalBtn);
            InputBox.Element(FirstNameInput, 10, "Qaz11111");
            InputBox.Element(LastNameInput, 10, "Qaz11111!");
            Button.Click(btnSave);
            return this;
        }

        [AllureStep("Edit Password")]
        public Profile EditPassword()
        {
            Button.Click(EditPasswordBtn);
            InputBox.Element(CurrentPasswordInput, 10, "Qaz11111");
            InputBox.Element(NewPasswordInput, 10, "Qaz11111!");
            InputBox.Element(ConfirmPasswordInput, 10, "Qaz11111!");
            Button.Click(btnSave);
            return this;
        }

        [AllureStep("Edit Password")]
        public Profile EditAccountData()
        {
            WaitUntil.CustomElementIsVisible(inputEmail);
            btnEditAccount.Click();
            WaitUntil.CustomElementIsVisible(btnSave);
            inputEmail.SendKeys(Keys.Control + "A" + Keys.Delete);
            inputEmail.SendKeys("qatester - " + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@xitroo.com");
            Pages.SignUp.countryInput.Click();
            ClickHelper.Clicker(Pages.SignUp.countryList);
            inputPhone.SendKeys(Keys.Control + "A" + Keys.Delete);
            inputPhone.SendKeys("953214567");
            btnSave.Click();
            return this;
        }
    }
}

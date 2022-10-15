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

        //[AllureStep("Edit Password")]
        //public Profile EditAccountData()
        //{
        //    WaitUntil.VisibilityOfAllElementsLocatedBy(_EmailInput);
        //    EditAccountBtn.Click();
        //    WaitUntil.VisibilityOfAllElementsLocatedBy(_SaveBtn);
        //    EmailInput.SendKeys(Keys.Control + "A" + Keys.Delete);
        //    EmailInput.SendKeys("qatester - " + DateTime.Now.ToString("yyyy - MM - dThh - mm - ss") + "@xitroo.com");
        //    Pages.SignUp.countryInput.Click();
        //    ClickHelper.Clicker(Pages.SignUp.countryList);
        //    PhoneInput.SendKeys(Keys.Control + "A" + Keys.Delete);
        //    PhoneInput.SendKeys("953214567");
        //    SaveBtn.Click();
        //    return this;
        //}
    }
}

using NUnit.Allure.Steps;
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
            WaitUntil.VisibilityOfAllElementsLocatedBy(_FirstNameInput);
            EditPersonalBtn.Click();
            WaitUntil.VisibilityOfAllElementsLocatedBy(_SaveBtn);
            FirstNameInput.Clear();
            FirstNameInput.SendKeys("EditedNameJane");
            LastNameInput.Clear();
            LastNameInput.SendKeys("Lorem");
            SaveBtn.Click();
            return this;
        }

        [AllureStep("Edit Password")]
        public Profile EditPassword()
        {
            WaitUntil.VisibilityOfAllElementsLocatedBy(_CurrentPasswordInput);
            EditPasswordBtn.Click();
            WaitUntil.VisibilityOfAllElementsLocatedBy(_SaveBtn);
            CurrentPasswordInput.Clear();
            CurrentPasswordInput.SendKeys("Qaz11111");
            NewPasswordInput.Clear();
            NewPasswordInput.SendKeys("Qaz11111!");
            ConfirmPasswordInput.Clear();
            ConfirmPasswordInput.SendKeys("Qaz11111!");
            SaveBtn.Click();
            return this;
        }

        [AllureStep("Edit Password")]
        public Profile EditAccountData()
        {
            WaitUntil.VisibilityOfAllElementsLocatedBy(_EmailInput);
            EditAccountBtn.Click();
            WaitUntil.VisibilityOfAllElementsLocatedBy(_SaveBtn);
            EmailInput.Clear();
            EmailInput.SendKeys("qatester - " + DateTime.Now.ToString("yyyy - MM - dThh - mm - ss") + "@xitroo.com");
            ClickHelper.Clicker(Pages.SignUp.countryInput);
            ClickHelper.Clicker(Pages.SignUp.countryList);
            Pages.SignUp.phoneInput.Clear();
            Pages.SignUp.phoneInput.SendKeys("953214567");
            SaveBtn.Click();
            return this;
        }
    }
}

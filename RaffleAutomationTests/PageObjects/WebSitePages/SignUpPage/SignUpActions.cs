using NUnit.Allure.Steps;
using RaffleAutomationTests.Helpers;
using System;
using RimuTec.Faker;
using System.Collections.Generic;

namespace RaffleAutomationTests.PageObjects
{
    public partial class SignUp
    {
        [AllureStep("Get Country list")]
        public List<string> GetCountryList()
        {
            List<string> countrylist = new List<string>();
            for (int i = 0; i < listCountryAll.Count; i++)
            {
                countrylist.Add(listCountryAll[i].Text);
                Console.WriteLine(countrylist[i]);
            }
            return countrylist;
        }
        [AllureStep("Enter user data")]
        public SignUp EnterUserData()
        {
            WaitUntil.CustomElementIsVisible(inputFirstName);
            inputFirstName.SendKeys(Name.FirstName());
            inputSurname.SendKeys(Name.LastName());
            inputEmail.SendKeys("qatester-" + DateTime.Now.ToString("yyyy-MM-dThh-mm-ss") + "@putsbox.com");
            inputCountry.Click();
            GetCountryList();
            Button.ClickJS(listCountry);
            inputPhone.SendKeys("961234563");
            inputPassword.SendKeys("Qaz11111");
            btnConfirmOpt.Click();
            btnRememberMe.Click();

            return this;
        }

        [AllureStep("Click \"Sign Up\" button")]
        public SignUp ClickSignUpBtn()
        {
            WaitUntil.CustomElementIsVisible(btnSignUp);
            btnSignUp.Click();

            return this;
        }
    }
}

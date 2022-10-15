using RaffleAutomationTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.SignInPageAdmin
{
    public class SignInAssertionsAdmin
    {
        
        public static void VerifyIsAdminSignInSuccesfull(SignInResponseModelAdmin response)
        {
            Assert.IsTrue(Credentials.LOGIN_ADMIN == response.User.Email);
        }
    }
}

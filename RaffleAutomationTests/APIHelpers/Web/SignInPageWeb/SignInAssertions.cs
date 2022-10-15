using RaffleAutomationTests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.APIHelpers.Web
{
    public class SignInAssertionsWeb
    {
        
        public static void VerifyIsAdminSignInSuccesfull(SignInResponseModelWeb response)
        {
            Assert.IsTrue(Credentials.LOGIN == response.User.Email);
        }
    }
}

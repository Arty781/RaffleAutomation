using NUnit.Framework;
using RaffleAutomationTests.Helpers;

namespace RaffleAutomationTests.APIHelpers.Admin
{
    public class SignInAssertionsAdmin
    {

        public static void VerifyIsAdminSignInSuccesfull(SignInResponseModelAdmin response)
        {
            Assert.IsTrue(Credentials.LOGIN_ADMIN == response.User.Email);
        }
    }
}

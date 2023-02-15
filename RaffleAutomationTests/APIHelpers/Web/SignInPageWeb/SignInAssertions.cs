namespace RaffleAutomationTests.APIHelpers.Web.SignIn
{
    public class SignInAssertionsWeb
    {

        public static void VerifyIsAdminSignInSuccesfull(SignInResponseModelWeb response)
        {
            Assert.IsTrue(Credentials.LOGIN == response.User.Email);
        }
    }
}

namespace RaffleAutomationTests.PageObjects
{
    public partial class Profile
    {
        public Profile VerifyDisplayingToaster()
        {
            WaitUntil.CustomElementIsVisible(SuccessUpdateDialog);
            Assert.IsTrue(SuccessUpdateDialog.Displayed);

            return this;
        }

        public Profile VerifyAddingTickets(double price)
        {
            WaitUntil.CustomElementIsVisible(prizePrice.Last());
            Assert.AreEqual(price, double.Parse(prizePrice.First().Text.Trim('£')));

            return this;
        }
    }
}

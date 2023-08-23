using static RaffleAutomationTests.Helpers.Element;

namespace RaffleAutomationTests.PageObjects
{
    public partial class CmsUserManagement
    {
        public CmsUserManagement SearchUser(string email)
        {
            WaitUntil.CustomElementIsVisible(textTitleUserManagement, 25);
            Element.Action(Keys.End);
            Button.Click(Pages.CmsCommon.btnLastPage);
            WaitUntil.CustomElementIsVisible(Element.FindSpecificUser(email).btnEdit);

            return this;
        }

        public void VerifyUserIsEdited(Element.UserRowModel userData, string email)
        {
            Assert.Multiple(() =>
            {
                Assert.That(Element.FindSpecificUser(email).Name, Is.EqualTo(userData.Name), string.Concat("Name doesn't match!", $" Expected: {userData.Name} but was {Element.FindSpecificUser(email).Name}"));
                Assert.That(Element.FindSpecificUser(email).Surname, Is.EqualTo(userData.Surname), string.Concat("Surname doesn't match!", $" Expected: {userData.Surname} but was {Element.FindSpecificUser(email).Surname}"));
                Assert.That(Element.FindSpecificUser(email).Email, Is.EqualTo(userData.Email), string.Concat("Email doesn't match!", $" Expected: {userData.Email} but was {Element.FindSpecificUser(email).Email}"));
                Assert.That(Element.FindSpecificUser(email).Phone, Is.EqualTo(userData.Phone), string.Concat("Phone doesn't match!", $" Expected: {userData.Phone} but was {Element.FindSpecificUser(email).Phone}"));

            });
        }

        public void VerifyTicketsIsAdded(List<CompetitionRowModel> competitionList, string competition, int numOfTickets)
        {
            WaitUntil.WaitSomeInterval();
            Assert.Multiple(() =>
            {
                Assert.That(int.Parse(SelectTicketsDataByCompetition(competition).FirstOrDefault().NumberOfTickets), Is.EqualTo(int.Parse(competitionList.FirstOrDefault().NumberOfTickets) + numOfTickets), string.Concat("Competition doesn't match!", $" Expected: {int.Parse(competitionList.FirstOrDefault().NumberOfTickets) + numOfTickets} but was {SelectTicketsDataByCompetition(competition).FirstOrDefault().NumberOfTickets}"));

            });
        }
    }
}
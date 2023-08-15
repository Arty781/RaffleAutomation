using System.Threading;

namespace RaffleAutomationTests.Helpers
{
    class AllureServe
    {
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukharevsky Artem")]
        [AllureSuite("DriverLevel")]
        [AllureSubSuite("GoToAllureResults")]
        [Test]
        public void GoToAllureResults()
        {
            AllureConfigFilesHelper.OpenAllureReport();
        }

        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukharevsky Artem")]
        [AllureSuite("DriverLevel")]
        [AllureSubSuite("ForceCloseDriver")]
        [Test]
        public static void ForceClose()
        {
            ForceCloseDriver.ForeseClose();
        }
    }
   
}

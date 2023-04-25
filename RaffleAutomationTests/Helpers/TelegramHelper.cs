namespace RaffleAutomationTests.Helpers
{
    public partial class TelegramHelper
    {
        private static string token = "5130591097:AAF6jNtd1H3l9baweL7QQsD5npn2ODqmlhk";
        private static TelegramBotClient? _clientM;
        private static readonly string _id = "595478648";
        protected static Message messageText;
        protected static Message messagePhoto;

        public static async System.Threading.Tasks.Task SendMessage()
        {
            switch (Browser._Driver)
            {
                case null:
                    _clientM = new TelegramBotClient(token);

                    messageText = await _clientM.SendTextMessageAsync(
                        chatId: _id,
                        text: "The test-case \"" + TestContext.CurrentContext.Test.Name.ToString() +
                        "\" has failed" + "\n" + "\n" + TestContext.CurrentContext.Result.Message);

                    break;
                case not null:
                    _clientM = new TelegramBotClient(token);

                    string filePath = ScreenShotHelper.MakeScreenShot();
                    FileStream stream = System.IO.File.OpenRead(filePath);
                    var inputOnlineFile = new InputOnlineFile(stream, filePath);

                    messageText = await _clientM.SendTextMessageAsync(
                        chatId: _id,
                        text: "The test-case \"" + TestContext.CurrentContext.Test.Name.ToString() +
                        "\" has failed" + "\n" + "\n" + TestContext.CurrentContext.Result.Message);

                    messagePhoto = await _clientM.SendPhotoAsync(
                        chatId: _id,
                        photo: inputOnlineFile
                        );
                    ScreenShotHelper.DeleteScreenShot(filePath);
                    break;
            }
        }

    }
}

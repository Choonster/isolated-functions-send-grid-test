using Microsoft.Azure.Functions.Worker;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IsolatedFunctionsSendGridTest
{
    public static class TestSendGrid
    {
        [Function("TestSendGrid")]
        [SendGridOutput]
        public static SendGridMessage Run([TimerTrigger("0 0/5 * * * *")] TimerInfo timer)
        {
            var message = new SendGridMessage
            {
                From = new EmailAddress(GetAppSetting("FromEmail"), GetAppSetting("FromName")),
                Subject = "SendGrid Test Email",
            };

            message.AddTo(GetAppSetting("ToEmail"), GetAppSetting("ToName"));

            message.AddContent(MimeType.Text, "Test email");

            return message;
        }

        private static string GetAppSetting(string name)
        {
            var toEmail = Environment.GetEnvironmentVariable(name);

            if (string.IsNullOrEmpty(toEmail))
            {
                throw new InvalidOperationException($"{name} is required");
            }

            return toEmail;
        }
    }
}

using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GestaoIso.Services
{
    public class EnviarEmailPorApiSendGridService : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("rbgh.desenvolvimento@outlook.com", "BGH System"),
                Subject = subject,
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(email));
            var response = await client.SendEmailAsync(msg);
        }
    }
}

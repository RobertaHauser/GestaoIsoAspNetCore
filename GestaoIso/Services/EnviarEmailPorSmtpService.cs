using Microsoft.AspNetCore.Identity.UI.Services;

namespace GestaoIso.Services
{
    public class EnviarEmailPorSmtpService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}

using GestaoIso.Models.DTO;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GestaoIso.Services
{
    public class EnviarEmailPorSmtpService : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Processar(new EmailDTO()
            {
                Para = new List<string>
                {
                    email
                },
                Titulo = subject,
                Mensagem = htmlMessage
            });
            return null;
        }



        static Email Email()
        {
            return new Email("contato@ycaro.net", "m)x)~)Z!2$KE", "mail.ycaro.net", 587)
            {
                EnableSsl = false
            };
        }


        private void Processar(EmailDTO emailDTO)
        {
            try
            {
                var email = Email();
                email.Titulo(emailDTO.Titulo);
                email.Conteudo(emailDTO.Mensagem, true);


                if (emailDTO.Para != null)
                    emailDTO.Para.ForEach((c) =>
                    {
                        email.AddDestinatario(c);
                    });

                if (emailDTO.CC != null)
                    emailDTO.CC.ForEach((c) =>
                    {
                        email.AddDestinatario(c);
                    });

                if (emailDTO.CCO != null)
                    emailDTO.CCO.ForEach((c) =>
                    {
                        email.AddDestinatarioCco(c);
                    });

                email.Enviar();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

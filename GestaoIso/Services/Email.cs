namespace GestaoIso.Services
{
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Threading.Tasks;

    public class Email
    {
        private readonly System.Net.NetworkCredential _credencial;
        private SmtpClient _smtp;

        MailMessage _mailMessage;

        public bool EnableSsl { get; set; }

        public Email Titulo(string titulo)
        {
            _mailMessage.Subject = titulo;

            return this;
        }


        public Email(string userName, string password, string servidor, int porta, string emailDe = null)
        {
            _credencial = new NetworkCredential(userName, password);
            this._smtp = new SmtpClient(servidor, porta)
            {
                UseDefaultCredentials = false,
                EnableSsl = EnableSsl,
                Credentials = _credencial
            };

            this._mailMessage = new MailMessage();

            this._mailMessage.From = new MailAddress(emailDe ?? userName);
        }


        public Email Conteudo(string cont, bool IsBodyHtml)
        {
            _mailMessage.Body = cont;
            _mailMessage.IsBodyHtml = IsBodyHtml;

            return this;
        }

        public Email AddDestinatario(string email)
        {
            _mailMessage.To.Add(email);

            return this;
        }
        public Email AddDestinatarioCc(string email)
        {
            _mailMessage.CC.Add(email);

            return this;
        }

        public Email AddDestinatarioCco(string email)
        {
            _mailMessage.Bcc.Add(email);

            return this;
        }


        public Email AddArquivoIncorporado(string conteudo, string cid, byte[] imagem, string contentType)
        {
            MemoryStream image1 = new MemoryStream(imagem);
            AlternateView av = AlternateView.CreateAlternateViewFromString(conteudo, null, MediaTypeNames.Text.Html);

            LinkedResource headerImage = new LinkedResource(image1);
            headerImage.ContentId = cid;
            headerImage.ContentType = new ContentType(contentType);
            av.LinkedResources.Add(headerImage);
            _mailMessage.AlternateViews.Add(av);

            return this;
        }


        public void Enviar()
        {
            _smtp.Send(_mailMessage);
        }
        public async Task EnviarAsync()
        {
            await _smtp.SendMailAsync(_mailMessage);
        }
    }
}
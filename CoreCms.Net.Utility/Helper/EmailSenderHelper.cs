using CoreCms.Net.Model.ViewModels.Email;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CoreCms.Net.Utility.Helper
{
    public class EmailSenderHelper
    {
        private readonly MailConfiguration _config;
        private readonly ILogger<EmailSenderHelper>? _logger;

        public EmailSenderHelper(MailConfiguration config, ILogger<EmailSenderHelper>? logger = null)
        {
            _config = config;
            _logger = logger;
            ValidateConfiguration();
        }

        private void ValidateConfiguration()
        {
            if (string.IsNullOrWhiteSpace(_config.SmtpServer))
                throw new ArgumentNullException(nameof(_config.SmtpServer));

            if (string.IsNullOrWhiteSpace(_config.UserName))
                throw new ArgumentNullException(nameof(_config.UserName));

            if (string.IsNullOrWhiteSpace(_config.Password))
                throw new ArgumentNullException(nameof(_config.Password));
        }

        public async Task SendEmailAsync(MailMessageModel message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            if (!message.ToAddresses.Any())
                throw new InvalidOperationException("No recipients specified");

            using var smtpClient = CreateSmtpClient();
            using var mailMessage = CreateMailMessage(message);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                _logger?.LogInformation($"Email sent to {string.Join(", ", message.ToAddresses)}");
            }
            catch (SmtpException ex)
            {
                _logger?.LogError(ex, $"SMTP error sending email: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"Error sending email: {ex.Message}");
            }
        }

        private SmtpClient CreateSmtpClient()
        {
            return new SmtpClient(_config.SmtpServer, _config.SmtpPort)
            {
                EnableSsl = _config.EnableSsl,
                Credentials = new NetworkCredential(_config.UserName, _config.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = _config.Timeout,
                UseDefaultCredentials = _config.UseDefaultCredentials
            };
        }

        private MailMessage CreateMailMessage(MailMessageModel model)
        {
            var fromAddress = string.IsNullOrWhiteSpace(_config.FromAddress)
                ? _config.UserName
                : _config.FromAddress;

            var mail = new MailMessage
            {
                From = new MailAddress(fromAddress),
                Subject = model.Subject ?? "[No Subject]",
                Body = model.Body ?? string.Empty,
                IsBodyHtml = model.IsBodyHtml,
                BodyEncoding = model.Encoding ?? Encoding.UTF8,
                SubjectEncoding = model.Encoding ?? Encoding.UTF8
            };

            // Add recipients
            model.ToAddresses.ForEach(to => mail.To.Add(to));
            model.CcAddresses?.ForEach(cc => mail.CC.Add(cc));
            model.BccAddresses?.ForEach(bcc => mail.Bcc.Add(bcc));

            // Add attachments
            if (model.Attachments != null)
            {
                foreach (var attachment in model.Attachments)
                {
                    if (attachment.FileData == null || string.IsNullOrWhiteSpace(attachment.FileName))
                        continue;

                    var stream = new MemoryStream(attachment.FileData);
                    mail.Attachments.Add(new Attachment(
                        stream,
                        attachment.FileName,
                        attachment.MediaType ?? MediaTypeNames.Application.Octet
                    ));
                }
            }

            return mail;
        }


    }
}

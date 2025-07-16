using CoreCms.Net.Model.ViewModels.Email;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using ContentDisposition = MimeKit.ContentDisposition;

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

        #region 异步发送 EMail 信息
        /// <summary>
        /// 异步发送 EMail 信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task SendWithMailKitAsync(MailMessageModel model)
        {
            var message = new MimeMessage();

            // 设置发件人
            message.From.Add(new MailboxAddress("Sender", _config.FromAddress));

            // 添加收件人
            AddRecipients(message.To, model.ToAddresses);

            // 添加抄送
            if (model.CcAddresses?.Count > 0)
            {
                AddRecipients(message.Cc, model.CcAddresses);
            }

            // 添加密送
            if (model.BccAddresses?.Count > 0)
            {
                AddRecipients(message.Bcc, model.BccAddresses);
            }

            // 设置主题
            message.Subject = model.Subject ?? "[No Subject]";

            // 创建多部分邮件
            var multipart = new Multipart("mixed");

            // 创建正文部分
            var textPart = new TextPart(model.IsBodyHtml ? TextFormat.Html : TextFormat.Plain)
            {
                Text = model.Body ?? string.Empty
            };
            multipart.Add(textPart);

            // 添加附件
            AddAttachments(multipart, model.Attachments);

            message.Body = multipart;

            using var client = new MailKit.Net.Smtp.SmtpClient();

            // 阿里邮箱的特殊设置
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect(_config.SmtpServer, _config.SmtpPort, MailKit.Security.SecureSocketOptions.SslOnConnect);

            client.Authenticate(_config.UserName, _config.Password);
            await client.SendAsync(message);
            client.Disconnect(true);
        } 
        #endregion

        #region 添加收件人
        /// <summary>
        /// 添加收件人
        /// </summary>
        /// <param name="list"></param>
        /// <param name="addresses"></param>
        private void AddRecipients(InternetAddressList list, IEnumerable<string> addresses)
        {
            foreach (var address in addresses)
            {
                if (!string.IsNullOrWhiteSpace(address))
                {
                    list.Add(MailboxAddress.Parse(address.Trim()));
                }
            }
        } 
        #endregion

        #region 添加附件列表
        /// <summary>
        /// 添加附件列表
        /// </summary>
        /// <param name="multipart"></param>
        /// <param name="attachments"></param>
        private void AddAttachments(Multipart multipart, IEnumerable<MailAttachment> attachments)
        {
            if (attachments == null) return;

            foreach (var attachment in attachments)
            {
                if (attachment?.FileData == null || string.IsNullOrWhiteSpace(attachment.FileName))
                    continue;

                var mimeType = string.IsNullOrWhiteSpace(attachment.MediaType)
                    ? MimeTypes.GetMimeType(attachment.FileName)
                    : attachment.MediaType;

                var part = new MimePart(mimeType)
                {
                    Content = new MimeContent(new MemoryStream(attachment.FileData)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = attachment.FileName
                };

                multipart.Add(part);
            }
        } 
        #endregion

    }
}

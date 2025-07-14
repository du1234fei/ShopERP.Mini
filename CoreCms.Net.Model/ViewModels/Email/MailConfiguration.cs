using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCms.Net.Model.ViewModels.Email
{
    public class MailConfiguration
    {
        public string SmtpServer { get; set; } = string.Empty;
        public int SmtpPort { get; set; } = 587;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DisplayName { get; set; } = "System Notification";
        public bool EnableSsl { get; set; } = true;
        public string FromAddress { get; set; } = string.Empty;
        public int Timeout { get; set; } = 10000; // 10 seconds
        public bool UseDefaultCredentials { get; set; } = false;
    }

    /// <summary>
    /// 邮箱要添加的附件
    /// </summary>
    public class MailAttachment
    {
        public byte[]? FileData { get; set; }
        public string? FileName { get; set; }
        public string? MediaType { get; set; } // e.g., MediaTypeNames.Application.Pdf
    }

    public class MailMessageModel
    {
        public List<string> ToAddresses { get; set; } = new List<string>();
        public List<string>? CcAddresses { get; set; }
        public List<string>? BccAddresses { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public bool IsBodyHtml { get; set; } = true;
        public List<MailAttachment>? Attachments { get; set; }
        public Encoding? Encoding { get; set; } = Encoding.UTF8;
    }



}

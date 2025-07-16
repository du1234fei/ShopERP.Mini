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
        public int SmtpPort { get; set; } = 465;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string DisplayName { get; set; } = "System Notification";
        public bool EnableSsl { get; set; } = true;
        public string FromAddress { get; set; } = string.Empty;
        public int Timeout { get; set; } = 10000; // 10 seconds
        public bool UseDefaultCredentials { get; set; } = false;//禁止使用系统凭据
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
        public List<string> ToAddresses { get; set; } = new List<string>();//收件人
        public List<string>? CcAddresses { get; set; }//抄送人
        public List<string>? BccAddresses { get; set; }//密送人
        public string? Subject { get; set; }//邮件主体
        public string? Body { get; set; }//邮件正文
        public bool IsBodyHtml { get; set; } = true;//是否为 html
        public List<MailAttachment>? Attachments { get; set; }//附件
        public Encoding? Encoding { get; set; } = Encoding.UTF8;
    }



}

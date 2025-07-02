namespace CoreCms.Net.Web.WebApi.Models
{
    /// <summary>
    ///     错误返回示例
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        ///     回调序列
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        ///     显示回调序列
        /// </summary>

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
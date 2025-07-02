
using System.Threading.Tasks;
using CoreCms.Net.Model.Entities;
using CoreCms.Net.Model.ViewModels.UI;
using Newtonsoft.Json.Linq;

namespace CoreCms.Net.IServices
{
    /// <summary>
    ///     消息配置表 服务工厂接口
    /// </summary>
    public interface ICoreCmsMessageCenterServices : IBaseServices<CoreCmsMessageCenter>
    {
        /// <summary>
        ///     商家发送信息助手
        /// </summary>
        /// <param name="userId">接受者id</param>
        /// <param name="code">模板编码</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        Task<WebApiCallBack> SendMessage(int userId, string code, JObject parameters);
    }
}


namespace CoreCms.Net.Model.FromBody
{
    /// <summary>
    ///     根据订单id取拼团信息提交参数
    /// </summary>
    public class FMGetPinTuanTeamPost
    {
        public string orderId { get; set; } = "";
        public int teamId { get; set; } = 0;
    }
}


namespace CoreCms.Net.Model.FromBody
{
    //APi=========================================================================
    /// <summary>
    ///     获取团购列表请求参数
    /// </summary>
    public class FMGroupGetListPost
    {
        /// <summary>
        ///     类型
        /// </summary>
        public int type { get; set; } = 0;

        /// <summary>
        ///     页码
        /// </summary>
        public int page { get; set; } = 1;

        /// <summary>
        ///     分页数量
        /// </summary>
        public int limit { get; set; } = 10;

        /// <summary>
        ///     活动状态
        /// </summary>
        public int status { get; set; } = 0;
    }


    public class FMGetGoodsDetial
    {
        public int id { get; set; }
        public int groupId { get; set; }
    }
}
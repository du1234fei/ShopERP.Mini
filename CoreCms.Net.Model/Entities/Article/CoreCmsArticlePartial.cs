using System.Collections.Generic;
using SqlSugar;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreCms.Net.Model.Entities
{
    /// <summary>
    /// 文章表
    /// </summary>
    public partial class CoreCmsArticle
    {

        /// <summary>
        /// 文章分类
        /// </summary>
        [SugarColumn(IsIgnore = true)]

        public CoreCmsArticleType articleType { get; set; }


        /// <summary>
        /// 上一篇
        /// </summary>
        [SugarColumn(IsIgnore = true)]

        public CoreCmsArticle upArticle { get; set; }


        /// <summary>
        /// 下一篇
        /// </summary>
        [SugarColumn(IsIgnore = true)]

        public CoreCmsArticle downArticle { get; set; }
    }
}

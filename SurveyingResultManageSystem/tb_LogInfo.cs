//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
/// <summary>
/// 操作类型枚举，上传 = 1，下载 = 2,删除 = 3,创建用户 = 4,修改密码 = 5,重制密码 = 6,系统日志 = 7
/// </summary>
//public enum Operations
//{
//    上传 = 1,
//    下载 = 2,
//    删除 = 3,
//    创建用户 = 4,
//    修改密码 = 5,
//    重制密码 = 6,
//    系统日志 = 7
//}
// </auto-generated>
//------------------------------------------------------------------------------

namespace SurveyingResultManageSystem
{
    using System.ComponentModel.DataAnnotations;

    public partial class tb_LogInfo
    {
            public int ID { set; get; }
            /// <summary>
            /// 用户名
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 时间 保留2012-07-21 16:21:59 格式(注意英文冒号）
            /// </summary>
            public string Time { get; set; }
            /// <summary>
            /// 可能的操作：删除、上传、下载、创建用户、修改密码、重制密码。不能更改文字词语，影响查询。
            /// </summary>
            public string Operation { get; set; }
            /// <summary>
            /// 文件名
            /// </summary>
            [StringLength(50, MinimumLength = 0, ErrorMessage = "最多50个字符")]
            public string FileName { get; set; }
            /// <summary>
            /// 操作说明，1000字符
            /// </summary>
            [StringLength(1000, MinimumLength = 0, ErrorMessage = "最多1000个字符")]
            public string Explain { get; set; }
    }
}

using BT.Manage.Tools.Attributes;
using BT.Manage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Manage.Model
{
    /*-----------------------------------
    // Copyright (C) 2017 备胎 版权所有。
    //
    // 文件名：sysLoginLog.cs
    // 文件功能描述：【登录记录表】实体
    // 创建人：LiaoYu
    // 创建标识： 2018/6/27 22:12:11
    //-----------------------------------*/
    [TableName("e_sys_LoginLog")]
    public class sysLoginLogInfo  : BaseModel
    {
            /// <summary>
            /// 主键ID 自增
            /// </summary>
            [Key]
            [Identity]
            [Display(Name = @" 主键ID 自增 ")]
            public int FID { get; set; }
            /// <summary>
            /// 用户名
            /// </summary>
            [Display(Name = @"用户名")]
            public string FAccount{ get; set; }
            /// <summary>
            /// 缓存服务器的KEY
            /// </summary>
            [Display(Name = @"缓存服务器的KEY")]
            public string FRedisKey{ get; set; }
            private System.DateTime _FAddTime = System.DateTime.Now;
            /// <summary>
            /// 添加时间
            /// </summary>
            [Display(Name = @"添加时间")]
            public System.DateTime FAddTime { get { return _FAddTime; } set { _FAddTime = value; } }        
            /// <summary>
            /// 来源：1.手机 2.后台管理
            /// </summary>
            [Display(Name = @"来源：1.手机 2.后台管理")]
            public int? FSource{ get; set; }
    }
}
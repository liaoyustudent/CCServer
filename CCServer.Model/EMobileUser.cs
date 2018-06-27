using BT.Manage.Tools.Attributes;
using BT.Manage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CCServer.Model
{
    [TableName("e_MobileUser")]
    public class EMobileUser : BaseModel
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
        public string FAccount { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = @"密码")]
        public string FPwd { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name =@"手机号")]
        public string FMobile { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name =@"昵称")]
        public string FNickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [Display(Name =@"真实姓名")]
        public string FPersonName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Display(Name =@"身份证号")]
        public string FPersonIDCard { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [Display(Name =@"是否删除")]
        public int? FIsDeleted { get; set; }

        /// <summary>
        /// 是否是vip
        /// </summary>
        [Display(Name =@"是否是vip")]
        public int? FIsVIP { get; set; }



        private System.DateTime _FAddTime = System.DateTime.Now;
        /// <summary>
        /// 添加时间
        /// </summary>
        [Display(Name = @"添加时间")]
        public System.DateTime FAddTime { get { return _FAddTime; } set { _FAddTime = value; } }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name =@"修改时间")]
        public DateTime? FModifyTime { get; set; }

        /// <summary>
        /// 后台修改人员
        /// </summary>
        [Display(Name =@"后台修改人员")]
        public int? FModifyUser { get; set; }

        /// <summary>
        /// 后台新增人
        /// </summary>
        [Display(Name =@"后台新增人")]
        public int? FAddUser { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [Display(Name =@"是否可用")]
        public int? FCanUse { get; set; }
    }
}

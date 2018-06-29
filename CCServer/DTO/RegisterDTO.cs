using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCServer.DTO
{
    /// <summary>
    /// 注册实体
    /// </summary>
    public class RegisterDTO
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string FAccount { get; set; }

        /// <summary>
        /// 密码(md5加密)
        /// </summary>
        public string FPwd { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string FMobile { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string FNickName { get; set; }


    }
}
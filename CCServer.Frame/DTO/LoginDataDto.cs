using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCServer.Frame.DTO
{
    public class LoginDataDto
    {
        /// <summary>
        ///     用户ID
        /// </summary>
        public int UserId { get; set; }
        
        
        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        
        /// <summary>
        /// 是否是会员
        /// </summary>
        public int IsVIP { get; set; }
    }

    public class LoginDto
    {
        /// <summary>
        ///     用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        public string UserPwd { get; set; }
        
    }


    public class PayLoad
    {
        public string id { get; set; }
        public string name { get; set; }
        public string iss { get; set; }
        public string aud { get; set; }
        public string sub { get; set; }
    }
}

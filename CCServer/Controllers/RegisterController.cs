using BT.Manage.Frame.Base;
using BT.Manage.Redies;
using BT.Manage.Verification;
using CCServer.Base;
using CCServer.BLL;
using CCServer.Frame.Attributes;
using CCServer.Frame.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CCServer.Model;
using BT.Manage.Core;
using BT.Manage.Tools.Utils;
using BT.Manage.Tools;
using CCServer.BLL;

namespace CCServer.Controllers
{
    public class RegisterController: BaseController
    {
        /// <summary>
        /// 注册提交申请
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [BtLog]
        public Result RegisterAccount([FromBody] EMobileUser dto)
        {
            Result result = new Result() { code = 1 };

            try
            {
                #region 验证
                if (string.IsNullOrEmpty(dto.FAccount) || string.IsNullOrEmpty(dto.FPwd))
                {
                    result.code = 0;
                    result.message = "用户名或密码不可为空";
                    return result;
                }
                if (string.IsNullOrEmpty(dto.FMobile))
                {
                    result.code = 0;
                    result.message = "手机号码不可为空";
                    return result;
                }
                //用户名是否已存在
                if (RegisterBll.CheckAccount(dto.FAccount))
                {
                    result.code = 0;
                    result.message = "该用户名已存在";
                    return result;
                }
                //判断昵称是否已存在
                if (RegisterBll.CheckNickName(dto.FNickName))
                {
                    result.code = 0;
                    result.message = "该昵称已存在";
                    return result;
                }
                if(RegisterBll.CheckMobile(dto.FMobile))
                {
                    result.code = 0;
                    result.message = "该手机号已存在";
                    return result;
                }
                #endregion

                dto.FID = 0;
                dto.FPwd = EncryptUtils.MD5(dto.FPwd.Trim().ToLower()).ToLower();
                dto.FAddTime = DateTime.Now;
                dto.SaveOnSubmit();
            }
            catch(Exception ex)
            {
                LogService.Default.Fatal("提交注册申请报错："+ex.Message);
                result.code = 0;
                result.message = "提交申请失败！请联系客服";
            }
            
            return result;
        }

        /// <summary>
        /// 检验是否存在相同账户
        /// </summary>
        /// <param name="FAccount"></param>
        /// <returns></returns>
        [HttpGet]
        [BtLog]
        public Result CheckAccount(string FAccount)
        {
            Result result = new Result() { code = 1 };

            result.@object = RegisterBll.CheckAccount(FAccount) ? 1 : 0;

            return result;
        }

        /// <summary>
        /// 检验是否存在相同昵称
        /// </summary>
        /// <param name="FNickName"></param>
        /// <returns></returns>
        [HttpGet]
        [BtLog]
        public Result CheckNickName(string FNickName)
        {
            Result result = new Result() { code = 1 };

            result.@object = RegisterBll.CheckNickName(FNickName) ? 1 : 0;

            return result;
        }

        /// <summary>
        /// 检验是否存在相同手机号
        /// </summary>
        /// <param name="FNickName"></param>
        /// <returns></returns>
        [HttpGet]
        [BtLog]
        public Result CheckMobile(string FMobile)
        {
            Result result = new Result() { code = 1 };

            result.@object = RegisterBll.CheckMobile(FMobile) ? 1 : 0;

            return result;
        }

    }
}
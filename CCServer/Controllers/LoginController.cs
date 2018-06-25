﻿using BT.Manage.Frame.Base;
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

namespace CCServer.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        #region 登录
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto">登录参数</param>
        /// <returns>返回用户信息</returns>
        [HttpPost]
        [BtLog]
        public Result GetUserInfo([FromBody] LoginDto dto)
        {
            var result = new Result();
            try
            {
                if (!string.IsNullOrEmpty(dto.UserName) && !string.IsNullOrEmpty(dto.UserPwd))
                    result = LoginBll.Login(dto);
                else
                    result.message = "用户名或密码不可为空";
                //LogService.Default.Trace("用户登录{0},IP地址{1}",dto.UserName, Utilities.Tools.GetUserIp());
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }
        #endregion

        #region 是否为登录状态
        /// <summary>
        /// 判断是否为登录状态
        /// </summary>
        /// <returns>返回结果1为Ture，0为False</returns>
        [HttpGet]
        [JwtAuthActionFilter]
        [AllowAnonymous]
        [BtLog]
        public Result IsLogin()
        {
            var item = UserInfo;
            if (item != null)
                return new Result
                {
                    code = 1,
                    message = "当前会话保持中",
                    @object = item
                };
            return new Result
            {
                code = 0,
                message = "缓存已过期请重新登录",
                @object = false
            };
        }
        #endregion


        #region 退出登录
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns>返回是否退出成功</returns>
        [HttpGet]
        [JwtAuthActionFilter]
        [BtLog]
        public Result LoginOut()
        {
            return LoginBll.LoginOut(GetRequestToken);
        }
        #endregion

        
    }
}
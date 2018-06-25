using CCServer.Frame.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Jose;
using BT.Manage.Frame.Base;
using System.Web.Http.Controllers;
using System.Net.Http;

namespace CCServer.Frame
{
    public class AuthToken
    {
        /// <summary>
        ///     创建Token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string CreatToken(LoginDataDto data)
        {
            var secret = ConfigurationManager.AppSettings["TokenSecret"];
            var payload = new
            {
                id = data.UserId,
                name = data.UserName.Trim().ToLower(),
                iss = "CCServer.Api",
                aud = "www.liaoyu.com",
                sub = "CCServer.APP",
                time = DateTime.Now.ToString("yyyy-MM-dd")
            };
            return JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS256);
        }
        /// <summary>
        ///     验证Token合法性
        /// </summary>
        /// <param name="actionContext"></param>
        public static void VerifyToken(HttpActionContext actionContext)
        {
            var result = new Result();
            var jwtObject = new LoginDataDto();
            var secret = ConfigurationManager.AppSettings["TokenSecret"];
            if (actionContext.Request.Headers.Authorization == null ||
                actionContext.Request.Headers.Authorization.Scheme != "Bearer" ||
                actionContext.Request.Headers.Authorization.Parameter == "undefined")
            {
                result.code = 0;
                result.message = "Token不能为空";
                setErrorResponse(actionContext, result);
            }
            else
            {
                try
                {
                    PayLoad payLoad = DecodeToken(secret, actionContext.Request.Headers.Authorization.Parameter);
                    if (int.Parse(payLoad.id) > 0)
                    {
                        //验证通过不处理
                    }
                    else
                    {
                        result.code = 0;
                        result.message = "Token验证无效";
                        setErrorResponse(actionContext, result);
                    }
                }
                catch (Exception ex)
                {
                    result.code = 0;
                    result.message = ex.Message;
                    setErrorResponse(actionContext, result);
                }
            }
        }
        private static void setErrorResponse(HttpActionContext actionContext, Result resutl)
        {
            var response = actionContext.Request.CreateResponse(resutl);
            actionContext.Response = response;
        }

        public static PayLoad DecodeToken(string secret, string token)
        {
            try
            {
                return JWT.Decode<PayLoad>(token, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS256);
            }
            catch (Exception ex)
            {
                throw new Exception("解析Token出错", ex);
            }

        }
    }
}

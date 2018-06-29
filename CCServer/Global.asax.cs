using AutoMapper;
using BT.Manage.Tools;
using CCServer.DTO;
using CCServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CCServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            #region  automapper初始化

            try
            {
                Mapper.Initialize(cfg =>
                {
                    //注册
                    cfg.CreateMap<RegisterDTO, EMobileUser>();
                    
                }
                );
            }
            catch (Exception ex)
            {
                LogService.Default.Fatal(ex, "初始化AutoMapper报错：" + ex.Message);
            }
        }
    }
}

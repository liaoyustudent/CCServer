using System.Web.Http;
using WebActivatorEx;
using CCServer;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CCServer
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.SingleApiVersion("v1", "CCServer");

                        c.IncludeXmlComments(GetXmlCommentsPath());

                        
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }

        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/CCServer.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}

using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            if (Request.HttpMethod == "OPTIONS")
                if (Request.Headers.AllKeys.Contains("origin") || Request.Headers.AllKeys.Contains("Origin"))
                    Response.Flush();                
        }
    }
}

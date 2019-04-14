using star_wars_planets.Application.AutoMapper;
using System.Web.Http;

namespace star_wars_planets.Services.REST.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
        }
    }
}

using Microsoft.Owin;
using CinemaTheca.BLL.Interfaces;
using CinemaTheca.BLL.Services;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(CinemaTheca.Web.App_Start.Startup))]

namespace CinemaTheca.Web.App_Start
{
    public class Startup
    {
        IAppServiceCreator serviceCreator = new AppServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateAppService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }

        private IAppService CreateAppService()
        {
            return serviceCreator.CreateAppService("DefaultConnection");
        }
    }
}
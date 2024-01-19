using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using MyCarApp.BAL.Authorization;
using Owin;

[assembly: OwinStartup(typeof(MyCarApp.WebAPI.Authorization.Startup))]

namespace MyCarApp.WebAPI.Authorization
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(CorsOptions.AllowAll);
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {

                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                AllowInsecureHttp = true
            }; app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}

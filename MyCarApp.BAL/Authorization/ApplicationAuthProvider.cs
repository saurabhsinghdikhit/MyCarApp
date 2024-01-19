using Microsoft.Owin.Security.OAuth;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Authorization
{
    public class ApplicationAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string userType = null;
            if (context.Request.Headers.ContainsKey("UserType"))
            {
                string[] type = new string[1];
                if (context.Request.Headers.TryGetValue("UserType", out type))
                {
                    userType = type[0]; 
                }
            }
            dynamic record = null;
            Guid id;
            if (userType.Equals("Admin"))
            {
                AdminRepository repo = new AdminRepository();
                record = repo.Login(context.UserName, context.Password);
                id = record.Id;
            }
            else
            {
                UserRepository repo = new UserRepository();
                UserLoginVM loginVM = new UserLoginVM();
                loginVM.Email = context.UserName;
                loginVM.Password = context.Password;
                record = repo.Login(loginVM);
                id = record.UserId;
            }

            if (record!=null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Username", ""+id));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
        }
    }
}

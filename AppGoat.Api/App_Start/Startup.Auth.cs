using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using AppGoat.Api.Providers;
using AppGoat.Api.Models;
using AppGoat.Domain.Constants;

namespace AppGoat.Api
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // Para obtener más información sobre cómo configurar la autenticación, visite https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure el contexto de base de datos y el administrador de usuarios para usar una única instancia por solicitud
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Permitir que la aplicación use una cookie para almacenar información para el usuario que inicia sesión
            // y una cookie para almacenar temporalmente información sobre un usuario que inicia sesión con un proveedor de inicio de sesión de terceros
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure la aplicación para el flujo basado en OAuth
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // En el modo de producción establezca AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Permitir que la aplicación use tokens portadores para autenticar usuarios
            app.UseOAuthBearerTokens(OAuthOptions);

            // Quitar los comentarios de las siguientes líneas para habilitar el inicio de sesión con proveedores de inicio de sesión de terceros
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }

        public void CreateDefaultRolesAndUsers()
        {
            var context = new ApplicationDbContext();

            var roleManager = new CustomRoleStore(context);
            var userManager = new ApplicationUserManager(new CustomUserStore(context));


            if (!roleManager.RoleExists(UserRoles.ADMIN))
            {
                var role = new CustomRole() { Name = UserRoles.ADMIN };
                roleManager.Create(role);

                var userAdmin = new ApplicationUser { Name = "Administrador", UserName = "Admin", Email = "Admin@es.com" };
                var userPWD = "GoatStar_2020";
                var result = userManager.Create(userAdmin, userPWD);

                if (result.Succeeded)
                {
                    var res = userManager.AddToRole(userAdmin.Id, UserRoles.ADMIN);
                }
            }

            if (!roleManager.RoleExists(UserRoles.SUPERVISOR))
            {
                var role = new CustomRole { Name = UserRoles.SUPERVISOR };
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists(UserRoles.OPERATOR))
            {
                var role = new CustomRole { Name = UserRoles.OPERATOR };
                roleManager.Create(role);
            }
        }
    }
}

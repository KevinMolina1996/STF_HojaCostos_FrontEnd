using AppWebHojaCosto.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace AppWebHojaCosto.Controllers.Helpers
{
    public class OwinAuthenticationService
    {
        private readonly HttpContextBase _context;
        private const string AuthenticationType = "ApplicationCookie";

        public OwinAuthenticationService(HttpContextBase context)
        {
            _context = context;
        }

        //public void SignIn(Usuario user, IList<string> roleNames)
        //{
        //    IList<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Sid, user.UsCodigoN.ToString()),
        //        new Claim(ClaimTypes.Name, user.UsNombreS.ToString()),
        //        new Claim(ClaimTypes.Email, user.UsEmailS.ToString()),
        //    };

        //    foreach (string roleName in roleNames)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, roleName));
        //    }

        //    ClaimsIdentity identity = new ClaimsIdentity(claims, AuthenticationType);

        //    IOwinContext context = _context.Request.GetOwinContext();
        //    IAuthenticationManager authenticationManager = context.Authentication;

        //    authenticationManager.SignIn(identity);
        //}

        //public void SignOut()
        //{
        //    IOwinContext context = _context.Request.GetOwinContext();
        //    IAuthenticationManager authenticationManager = context.Authentication;

        //    authenticationManager.SignOut(AuthenticationType);
        //}

    }
}
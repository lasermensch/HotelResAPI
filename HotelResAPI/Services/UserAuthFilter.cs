using HotelResAPI.Data;
using HotelResAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Services
{
    public class UserAuthAttribute : TypeFilterAttribute
    {
        public UserAuthAttribute() : base(typeof(UserAuthFilter)) { }
    }
    public class UserAuthFilter : IAuthorizationFilter
    {
        private readonly HotelResDbContext _context;
        public UserAuthFilter(HotelResDbContext context)
        {
            _context = context;
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var action = filterContext.ActionDescriptor;
            bool hasAllowAnonymous = filterContext.ActionDescriptor.EndpointMetadata.Any(em => em.GetType() == typeof(AllowAnonymousAttribute));
                                                                                                                                                    //Undersöker om det
                                                                                                                                                    //finns några AllowAnonymous som är underlägsna
                                                                                                                                                    //detta filter.
            if (hasAllowAnonymous)
                return;

            try
            {
                var headers = filterContext.HttpContext.Request.Headers;
                if (!headers.ContainsKey("Authorization"))
                    filterContext.Result = new StatusCodeResult(403);
                var authHeader = headers["Authorization"].ToString();

                if (!authHeader.StartsWith("Bearer ") && authHeader.Length > 7)
                    filterContext.Result = new StatusCodeResult(403);

                var handler = new JwtSecurityTokenHandler();

                var token = handler.ReadJwtToken(authHeader.Remove(0, 7));

                int? now = new JwtSecurityToken(expires: DateTime.Now).Payload.Exp; //Enklaste sättet jag funnit.
                if (token.Payload.Exp < now) //Kollar att token inte har gått ut...
                    filterContext.Result = new StatusCodeResult(403);

                string id = SecurityService.Decrypt(AppSettingsSingleton.Instance.JwtEmailEncryption, token.Payload.Sub);

                User u = _context.Users.Find(Guid.Parse(id));
                if (u == null)
                    filterContext.Result = new StatusCodeResult(403);

                filterContext.HttpContext.Items["extractId"] = id; //För att kunna komma åt det aktuella user-id direkt från filtret...
                
                //filterContext.Result = new JsonResult(token);
                
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                filterContext.Result = new StatusCodeResult(403);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MaasBordro.API.Security
{
    public class BasicAuth:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized,"Unauthorized");     
            }
            else 
            {
                string authCode = actionContext.Request.Headers.Authorization.Parameter;
                string decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(authCode));

                if (decodedUsernamePassword == "admin:Erzincan24+") 
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(decodedUsernamePassword),null);       
                }
                else 
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Unauthorized");
                }
            }
        }

    }
}
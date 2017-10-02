using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace GAP.WebApi.Security
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {

        private const String USER_NAME = "my_user";
        private const String USER_PASSWORD = "my_password";

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var username = "";
            var password = "";

            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                username = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);
            }


            if (ValidateUser(username, password))
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }

        }

        private bool ValidateUser(String userName, String password)
        {
            if (USER_NAME.Equals(userName) && USER_PASSWORD.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
using FindMyCourtObjectLibrary.Common;
using FindMyCourtObjectLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace FindMyCourt.Authentication
{
    public class FMCAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            string username = WebOperationContext.Current.IncomingRequest.Headers["username"];
            string password = WebOperationContext.Current.IncomingRequest.Headers["password"];

            if (username != null && password != null)
            {
                List<User> users = User.GetUsers(null, username);
                User user = users[0];

                string generatedSaltedPassword = SaltedPasswordUtility.GenerateSaltedPassword(user.Salt, password);

                if (generatedSaltedPassword != user.SaltedPassword)
                    return false;
                else
                {
                    return true;
                }
            }
            else if (HttpContext.Current.Request.Cookies.Get("oauthtoken") != null)
            {
                //TODO: implement token validation logic
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
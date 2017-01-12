using System;
using System.Web;
using System.Web.SessionState;

namespace CoreFramework.ASP.Extensions
{
    public static class HttpContextExtensions
    {
        public const string USER_ID_KEY = "UserID";

        public static int GetUserID(this HttpContext context)
        {
            if (context.Session == null)
            {
                return -1;
            }

            object idObj = context.Session[USER_ID_KEY];
            if (idObj is int)
            {
                return (int)idObj;
            }
            else
            {
                return -1;
            }
        }


        public static int GetSessionInt(this HttpSessionState session, string key, int fallback)
        {
            Object sessionObj = session[key];
            if (sessionObj is int)
            {
                return (int)sessionObj;
            }
            else
            {
                return fallback;
            }
        }
    }
}

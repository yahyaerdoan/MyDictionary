using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dictionary.BussinessLogicLayer.SessionHelper
{
    public static class SessionHelper
    {
        public static string GetSessionIformation(HttpSessionStateBase session)
        {
            return (string)session["Email"];
        }
    }
}

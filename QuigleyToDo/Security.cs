using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuigleyToDo
{
    public static class Security
    {
        public static string CurrentUserFull
        {
            get { return System.Security.Principal.WindowsIdentity.GetCurrent()?.Name ?? "No windows identity"; }
        }

        public static string CurrentUser
        {
            get 
            {
                if (System.Security.Principal.WindowsIdentity.GetCurrent()?.Name != null)
                {
                    var parts = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split(new char[1] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                        return parts[1];
                    else
                        return "No windows identity";
                }
                else
                    return "No windows identity";
            }
        }

        public static string CurrentUserDomain
        {
            get
            {
                if (System.Security.Principal.WindowsIdentity.GetCurrent()?.Name != null)
                {
                    var parts = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 2)
                        return parts[0];
                    else
                        return "No windows identity";
                }
                else
                    return "No windows identity";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.ViewModels
{
    public class LoginInfoViewModel
    {
        public double Timeout = 7500;
        public object Token;
        public string UserId;
        public long CompanyId;
        public long CafeId;
    }
}

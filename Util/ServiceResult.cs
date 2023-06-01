using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _67RoleBaseSecurity.Util
{
    public class ServiceResult<T>
    {
        public int Success { get; set; }
        public int Message { get; set; }
        public T Data { get; set; }
    }
}
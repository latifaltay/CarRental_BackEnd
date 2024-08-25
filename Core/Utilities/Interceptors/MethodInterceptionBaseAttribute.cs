using Castle.DynamicProxy;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 3c9e86c044ed123d9fad52e410f4033b602e70d8

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
<<<<<<< HEAD
    public abstract class MethodInterceptionBaseAttribute : Attribute, Castle.DynamicProxy.IInterceptor
=======
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
>>>>>>> 3c9e86c044ed123d9fad52e410f4033b602e70d8
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
<<<<<<< HEAD
=======

>>>>>>> 3c9e86c044ed123d9fad52e410f4033b602e70d8
}

using Castle.DynamicProxy;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public Castle.DynamicProxy.IInterceptor[] SelectInterceptors(Type type, MethodInfo method, Castle.DynamicProxy.IInterceptor[] interceptors)
=======
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
>>>>>>> 3c9e86c044ed123d9fad52e410f4033b602e70d8
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
<<<<<<< HEAD
=======

>>>>>>> 3c9e86c044ed123d9fad52e410f4033b602e70d8

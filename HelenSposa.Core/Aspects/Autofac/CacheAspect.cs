using Castle.DynamicProxy;
using HelenSposa.Core.CrossCuttingConcerns.Caching;
using HelenSposa.Core.Utilities.Interceptors;
using HelenSposa.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Aspects.Autofac
{
    public class CacheAspect:MethodInterception
    {
        int _duration;
        ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            //{invocation.Method.ReflectedType.FullName}   class ismi
            //{invocation.Method.Name}                     method ismi
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");

            var arguments = invocation.Arguments.ToList();

            var key = $"{methodName}({string.Join(",",arguments.Select(x=>x?.ToString()??"<Null>"))})";

            if (_cacheManager.isExist(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}

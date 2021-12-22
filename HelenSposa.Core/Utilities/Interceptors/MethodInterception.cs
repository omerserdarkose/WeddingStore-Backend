using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Interceptors
{
    /// <summary>
    /// kullanacak aspectler icin temel akisi iceren ve override edilerek ihtiyaca yonelik
    /// doldurulacak methodlari iceren soyut sinif
    /// </summary>
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        //IInvocation calisacak olan methodu temsil ediyor
        protected virtual void OnBefore (IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException (IInvocation invocation) { }
        protected virtual void OnSuccess (IInvocation invocation) { }

        //genel akis
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }



    }
}

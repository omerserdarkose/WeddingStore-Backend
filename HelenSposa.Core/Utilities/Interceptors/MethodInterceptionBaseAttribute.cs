using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Utilities.Interceptors
{
    /// <summary>
    /// kullanacagimiz butun method interceptorlari icin genel ozellikleri iceren bir baseAttribute sinifi olusturuyoruz
    /// </summary>
    /// 

    //bu attribute siniflara(genel ozellik olarak yazildi ama benim ihtiyacim olmayacak muhtemelen) ve methodlara uygulanabilir,
    //birden fazla kez kullanilabilir ve inherit edilmis siniflarda da kullanilabilir
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]

    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //attribute un oncelik siralamasi degistirmek istersek diye bu propertyi ekliyoruz
        public int Priority { get; set; }
        
        //inherit eden siniflarda interceptorun ne zaman ne yapacagini tanimlamak icin kullanacagiz
        public virtual void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}

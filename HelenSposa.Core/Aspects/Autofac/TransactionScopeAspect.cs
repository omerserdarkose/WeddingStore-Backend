using Castle.DynamicProxy;
using HelenSposa.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HelenSposa.Core.Aspects.Autofac
{
    //MethodInterceprion sinifinda tanimladigimiz ve ici bos olan methodlari
    //bu aspectte hangisi ihtiyacimiz ise ona gore override ederek aktiflestiriyoruz
    //ornegin burada Intercept methodu ile islem yapilan methodun yasam dongusunu
    //override etmeye ihtiyacimiz var
    public class TransactionScopeAspect:MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            //transaction scope instance olusuruluyor
            using (TransactionScope transactionScope=new TransactionScope())
            {
                try
                {
                    //method isleme aliniyor
                    invocation.Proceed();

                    //bir problem cikmadiysa transaction tamamlaniyor
                    transactionScope.Complete();

                }
                catch (Exception)
                {
                    //hata alinirsa
                    //transaction kapsamindaki islmeler iptal ediliyor
                    transactionScope.Dispose();

                    //hata yukari yollaniyor
                    throw;
                }

            }
        }
    }
}

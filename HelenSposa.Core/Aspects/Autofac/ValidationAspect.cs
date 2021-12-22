using Castle.DynamicProxy;
using FluentValidation;
using HelenSposa.Core.CrossCuttingConcerns.Validation.FluentValidation;
using HelenSposa.Core.Utilities.Interceptors;
using HelenSposa.Core.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Core.Aspects.Autofac
{
    public class ValidationAspect:MethodInterception
    {
        //reflection ile validasyon yapilacak turu ogrenicez ve bu degiskene atama yapicaz
        private Type _validatorType;

        //constructor da fluentValidation sinifi bekleniyor
        public ValidationAspect(Type validatorType)
        {
            //eger gelen obje IValidatordan turetilmemisse hata veriliyor
            if(!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }

        //MethodInterceprion sinifinda tanimladigimiz ve ici bos olan methodlari
        //bu aspectte hangisi ihtiyacimiz ise ona gore override ederek aktiflestiriyoruz
        //ornegin burada OnBefore ihtiyacimiz
        protected override void OnBefore(IInvocation invocation)
        {
            //gelen validatorin tipini ogrenmistik
            //simdi kullanmak icin reflection ile o tipde bir instance olusturuyoruz
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            //bu validasyon ile hangi tipteki entity veya modellerin kontrolunun yapilacagini ogreniyoruz
            //ornegin gelen validator customerValidator ise
            //public class CustomerValidator:AbstractValidator<Customer> bu imzadaki Customer yazan kismi bu sekilde aliyoruz
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //bu aspectin yazildigi methodun aldigi parametreleri gezip kontrol edecegimiz tipte olanlari topluyoruz
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            //konrol edilecek tipte olanlarin herbiri icin validate methodunu cagiriyoruz ve arg olarak yukarida olusturdugumuz validator instancini ve gelen veriyi veriyoruz
            foreach (var entity in entities)
            {
                ValidatorTool.Validate(validator, entity);
            }

        }
    }
}

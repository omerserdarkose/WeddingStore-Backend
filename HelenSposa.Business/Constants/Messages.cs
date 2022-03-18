using HelenSposa.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HelenSposa.Business.Constant
{
    public static class Messages
    {
        public static string CustomerAdded = "Müşteri başarıyla eklendi";
        public static string CustomerDeleted = "Müşteri başarıyla silindi";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi";
        internal static string CustomerNotFound = "Belirtilen musteri kayitlarda bulunmamaktadir!";

        public static string ExpenseTypeAdded = "Gider türü başarıyla eklendi";
        public static string ExpenseTypeDeleted = "Gider türü başarıyla silindi";
        public static string ExpenseTypeUpdated = "Gider türü başarıyla güncellendi";
        public static string ExpenseTypeNotFound = "Gider türü bulunamadı";

        public static string ExpenseAdded = "Gider başarıyla eklendi";
        public static string ExpenseDeleted = "Gider başarıyla silindi";
        public static string ExpenseUpdated = "Gider başarıyla güncellendi";


        public static string UserNotFoundByMail = "Bu email ile kayitli kullanici bulunmamaktadir!";
        public static string UserNotFoundById = "Bu id ile kayitli kullanici bulunmamaktadir!";
        public static string PasswordNotMatch = "Girilen parola hatali";
        public static string SuccessfulLogin = "Kullanici girisi basarili";
        public static string UserAlreadyExist = "Bu mail ile kayitli bir kullanici zaten mevcut";
        public static string UserAdded = "Kullanici basariyla kaydedildi";
        public static string AccessTokenCreated = "Access Token olusturuldu";
        public static string AuthorizationDenied = "Islem icin yetkiniz bulunmamaktadir. Lutfen yoneticinize basvurunuz";
        public static string UserClaimAdded = "Kullanici yetkisi eklendi";
        public static string UserUpdated = "Kullanici bilgileri guncellendi";
        public static string UserClaimDeleted = "Kullanici yetkisi kaldirildi";
        public static string UserClaimNotFound = "Belirtilen yetki kullanicida bulunmamaktadir";
        public static string UserClaimAlreadyExists = "Beirtilen yetki zaten mevcut";
        public static string UserRemoved = "Kullanicinin sitem girisi engellendi";
        public static string UserDenied = "Girisiniz engellendi. Lutfen yoneticinize danisiniz";
    }
}

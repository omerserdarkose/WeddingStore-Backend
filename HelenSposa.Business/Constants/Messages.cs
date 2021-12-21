using HelenSposa.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static string ExpenseAdded = "Gider başarıyla eklendi";
        public static string ExpenseDeleted = "Gider başarıyla silindi";
        public static string ExpenseUpdated = "Gider başarıyla güncellendi";

        public static string UserNotFound = "Bu email ile kayitli kullanici bulunmamaktadir!";
        internal static string PasswordNotMatch = "Girilen parola hatali";
        internal static string SuccessfulLogin = "Kullanici girisi basarili";
        internal static string UserAlreadyExist = "Bu mail ile kayitli bir kullanici zaten mevcut";
        internal static string UserRegistered = "Kullanici basariyla kaydedildi";
        internal static string AccessTokenCreated = "Access Token olusturuldu";

    }
}

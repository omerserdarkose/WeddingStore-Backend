using HelenSposa.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using HelenSposa.Entities.Dtos.Expense;

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
        public static string ClaimNotFoundById="Belirtilen id ye kayitli yetki bulunmamaktadir";
        public static string ClaimAlreadyExists="Islem yapilmaya calisilan yetki zaten yetkiler listesinde mevcut";
        public static string ClaimAdded="Yeni yetki listeye eklendi";
        public static string ClaimRemoved = "Yetki listeden kaldirildi";
        public static string ClaimUpdated="Yetki guncellendi";
        public static string UserPasswordReseted="Parola Sifirlandi";
        public static string ExpenseNotExists="Kayitli Gider bulunmamaktadir";
        public static string ExpenseNotExistsByCategory="Bu kategoride Gider Bulunmamaktadir";
        public static string EventTypeAdded="Etkinlik türü eklendi";
        public static string EventTypeNotFound="Etkinlik türü mevcut değil";
        public static string EventTypeDeleted="Etkinlik türü kaldırıldı";
        public static string EventTypeUpdated="Etkinlik türü güncellendi";
        public static string ProductAdded="Ürün eklendi";
        public static string ProductNotFound = "Ürün mevcut değil";
        public static string ProductDeleted = "Ürün kaldırıldı";
        public static string ProductUpdated = "Ürün güncellendi";
    }
}

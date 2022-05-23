using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string Updated = "Güncellendi";
        public static string Listed = "Ürünler Listelendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductCountOfCategoryError = "Bu kategoride maximum 10 ürün olabilir.";
        public static string ProductNameAlreadyExists = "Bu isim zaten mevcut.";
        public static string CategoryLimitExceded = "Kategori limiti aştı.";

        public static string AuthorizationDenied = "Yetkiniz Yok!";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

    }
}

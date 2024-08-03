using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        //For customer 
        public static string CustomerNameInvalid = "Müşteri adı geçersiz. En az 2 karakter uzunluğunda olmalıdır.";
        public static string CustomerAdded = "Müşteri başarıyla eklendi.";
        public static string CustomerDeleted = "Müşteri başarıyla silindi.";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi.";
        public static string CustomerNotFound = "Müşteri bulunamadı.";
        public static string CustomersListed = "Müşteriler başarıyla listelendi.";
        public static string CustomerFetched = "Müşteri başarıyla getirildi.";

        //For cars
        public static string CarNameInvalid = "Araç adı geçersiz. En az 2 karakter uzunluğunda olmalıdır.";
        public static string CarAdded = "Araç başarıyla eklendi.";
        public static string CarNotDelete = "Araç silinemedi.";
        public static string CarNotFound = "Araç bulunamadı.";
        public static string CarUpdated = "Araç başarıyla güncellendi.";
        public static string CarDeleted = "Araç başarıyla silindi.";
        public static string CarsListed = "Araçlar başarıyla listelendi.";
        public static string CarIsNotAvailable = "Araç kiralamaya uygun değil.";

        //For brand
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandsListed = "Markalar listelendi";


        //For color
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorsListed = "Renkler listelendi";

      
        // For rental
        public static string InvalidRentalDates = "Kiralama bitiş tarihi, kiralama başlangıç tarihinden önce olamaz.";
        public static string RentalAdded = "Kiralama başarıyla eklendi.";
        public static string RentalDeleted = "Kiralama başarıyla silindi.";
        public static string RentalUpdated = "Kiralama başarıyla güncellendi.";
        public static string RentalNotFound = "Kiralama bulunamadı.";
        public static string RentalsListed = "Kiralamalar başarıyla listelendi.";
        public static string RentalFetched = "Kiralama başarıyla getirildi.";

        // For user
        public static string UserNameInvalid = "Kullanıcı adı geçersiz. En az 2 karakter uzunluğunda olmalıdır.";
        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UsersListed = "Kullanıcılar başarıyla listelendi.";
        public static string UserFetched = "Kullanıcı başarıyla getirildi.";
        public static string EmailInvalid = "E-posta adresi geçersiz.";
        public static string PasswordInvalid = "Parola geçersiz. Güvenlik gereksinimlerini karşılamalıdır.";
        


        //For maintenance
        public static string MaintenanceTime = "Sistem bakımda. Lütfen daha sonra tekrar deneyin.";

    }
}

Merhaba, öncelikle bütün methotları Açıklamak istiyorum
Auth Klasörü -> AuthC 
{
 public static string Auths = "null"; komutu yetki
belirtir.
}
Context-> MyContext
{
Database ile etkileşim kuruyorum. 4 adet dbsetim var
1-> users // Kullanıcılar ile alakalı veriler
2-> ticketss //Biletler ile alakalı veriler
3-> categories // Kategoriler ile alakalı veriler
4-> tikcethistory // Bilet geçmişi ile alakalı veriler
}
Controllers
a->AdminPanelController
{
4 Adet methodumuz var.
1. Method (Main) // Anapanel kısmıdır. Önemli bir
özelliği yok
2. Method (Addticket) // Bilet eklemek için başlangıç
kısımıdır.
3. Method (AddTickets) //Bilet eklemenin bitiş kısmıdır.
4. Method (UserList) // Bu methodun projeye herhangi bir
katkısı yoktur, admin bütün yetkili kişileri görmek ister
diye düşünmüştüm o yüzden ekledim.
}
b->HomeController
{
4 Adet methodumuz var.
1. Method (Index) //Anapanelimizdir, giriş kısmını gösterir.
2. Method (Login) //Giriş için kullanılan method.
3. Method (SignUp) // Kayıt için kullanılan method
bu 2 method daha çok yazılımcı için deneme methodları
eğer yeni bir şeyler denemek isterse. (bu bilgi
unutulmasın)
4. Method (ViewTicket) // Giriş yapmadan biletleri görmek ister
iseniz kullanılacak bir method, beşiktaşlılar kullanabilir.
}
c->LoginController
{
4 Adet methodumuz var.
1. Method (Login) // Giriş için başlangıç methodu fakat bu
method ana method yazılımcı için değil kullanıcı için.
2. Method (LoginControl) Girişi bitiren method. Bu da yazılımcı
için değil kullanıcı içindir.
3. Method (Register) //Kayıt olmak için başlangıç methodu
4. Method (RegisterControl) Kayıt olmak işlemini bitiren method.
}
D->UserPanelController
{
4 Adet methodumuz ve 1 adet Fieldimiz var.
1. Method (Main)// Anapanel methodumuzdur, burda önemli bir detay
giriş yapan kişinin id sini parametre olarak alıp Fieldimiz ile
bunu paylaşıyoruz.
2. Method (Tickets)// Kullanıcıların biletleri görüp satın alması
için kullanılan method.
3. Method (Succes)// Kullanıcılar bilet satın almak isterse
aktif edilecek methottur.
4. Method (TicketHistory) Kullanıcılar daha önce satın aldığı bütün
biletleri görmek isterse çalışacak method.
}
DTO
[
Requests
{
LoginRQ    request islemleri
TicketRQ
}
Responses
{
Genel olarak bütün response islemleri
}
]
Models
[
Entities
{
CategoryEntity// Kategori için entity
TicketHistoryEntity// Bilet geçmişi için entity
TicketEntity// Bilet için entity
UserEntity// Kullanıcı için entity
}
Vmodel
{
CategotyView // Kategori için
TicketHistory //Bilet geçmişi için
TicketView // Bilet için
UserIdView // Bu en önemlisi bence userid icin
UserView // Kullanıcı view
ErrorViewModel //Benle bi alakası yok mvc ile birlikte geliyor
ama bildiğim kadarıyla hata sayfasında gösterilmesi için
kullanılıyor :)
/* Konudan bağımsız şekilde aslında bence bütün viewler sadece
bir view içinde kullanılsa yani sadece 1 view olsa içinde bütün
Listler, idler, vs vs herşey olsa daha rahat olur. Sadece bi dü-
şünce*/
}
Services
{
CategoryService
 {
Context ile bağlantısı var.
1 adet methodu var o da (GettAll) yanlış yazılmış ama bunu
daha sonra yazıyorum o yüzden düzeltemem :( Bütün kategorileri
getiriyor.
 }
RegisterService
  {
Burda da context bağlantısı var,
sadece 1 adet işlevi var mail ve şifreyi kontrol edip kayıt olma
işlemini yapıyor. Evet ya da hayır gönderiyor.
  }
TicketHistoryService
   {
Burada da context ile bağlantı var.
3 Adet methodumuz var
1. Method (GettAll) [sanırım get yazmayı bilmiyorum] Bütün ticket
geçmişini getiriyor.
2. Method (GettByUserId) idsi verilen bir userin daha önce satın
aldığı bütün biletleri getiriyor.
3. Method (Entry) Bilet geçmişi eklemeye yarayan method.
    }
TicketService
     {
Burada da context ile bağlantı var.
5 Adet methodumuz var
1. Method (GettAll) Bütün biletleri getirir.
2. Method (GettAllByID) Kategori id sine göre bütün biletleri
getirir.
3. Method (GetById) Özel bir id ye göre bilet getirir.
4. Method (DecraseQuantity) Bilet satın alındığında biletin
sayısını düşürüyor.
5. Method (Necessary) Zaman kontrolü yapıyor [Hocam bu methodu,
bağlamayı unutmuşum ama her şeyi hazır sadece normal gettall yerine
bunu kullanacağız eğer izin verirseniz hemen düzeltebilirim.
     }
Views ise forntlar (yalan söylemek istemiyorum bazı yerlerde
bootsrap ve chatgpt kullandım üzerine kendim modifiye ettim.
}
]

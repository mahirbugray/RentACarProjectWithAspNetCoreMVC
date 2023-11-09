# Rent A Car Project
TR -> Asp.Net Core 7 teknolojisi ve MVC mimarisi ile yazılmış bir araç kiralama sitesi.

Proje içerisinde öncelikle hesabımız yoksa yeni bir kullanıcı kaydı yapıp bu işlemi tamamladıktan sonra bize uygun kategorideki aracı kaç günlük kiralamak istediğimizi seçip ödeme işlemine geçiyoruz, aracı devretmek istediğimizde ise profil sekmemizden devretme isteği yapıyoruz ve admin onayladıktan sonra bu araç tekrar kiralanabilir duruma geçiyor.

Bunlara ek olarak gelişmiş bir yapı sunan bir Admin paneline sahip bu panel üzerinden araçlar, firmalar, sigartolar için CRUD işlemlerini yapabiliyoruz ve ayrıca burada kiralama işlemine ait detayları görebiliyoruz.

Son olarak da profil bilgilerimizi güncelleyebiliyoruz, şifre ile ilgili işlemleri yapabiliyoruz.

ENG -> A car rental site written with Asp.Net Core 7 technology and MVC architecture.

In the project, first of all, if we do not have an account, we register a new user and after completing this process, we choose how many days we want to rent the vehicle in the appropriate category and proceed to the payment process, when we want to transfer the vehicle, we make a transfer request from our profile tab and after the admin approves it, this vehicle becomes available for rent again.

In addition to these, it has an Admin panel that offers an advanced structure, through this panel we can perform CRUD transactions for vehicles, companies, insurances and we can also see the details of the rental process here.

Finally, we can update our profile information and perform password-related operations.
## Kullanılan Teknolojiler / Used Technologies

- Katmanlı Mimari / Onion Pattern
- Asp.Net Core 7
- Ajax
- N Tier Architecture (Entity Layer, Service Layer, DataAccess Layer, UI Layer)
- Identity Authorization
- Entity Framework Core
- MS Sql
- Generic Repository
- Unit Of Work
- LINQ
- JavaScript
- Bootstrap
## Usage/Examples
- TR -> Projeyi çalıştırmak için UI katmanındaki appsettings.json dosyasındaki ConnectionStrings altındaki "ConnStr" kısmını kendinize göre ayarlamanız gerekmektedir

- EN -> To run the project, configure the "ConnStr" section under ConnectionStrings in the appsettings.json file in the UI layer according to your environment.
``` javascript
{
  "ConnectionStrings": {
    "ConnStr": "Bu kısmı kendinize göre ayarlamanız gereklidir"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

```

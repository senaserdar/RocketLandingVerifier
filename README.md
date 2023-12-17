Rocket Landing Verifier

Bu proje, roketlerin belirli bir iniş alanına güvenli bir şekilde inip inemediğini kontrol etmek için kullanılan bir C# sınıf kütüphanesini içerir. Kodun güvenirliliği unitTestler ile arttırılmıştır.

Metodlar ve İşlevler

IsOutOfPlatform: Belirtilen koordinatların platform alanının dışında olup olmadığını kontrol eder.
IsCollision: Belirtilen koordinatlarda bir çarpışma olup olmadığını kontrol eder.
IsLandingPermitted: Belirtilen koordinatlara roketin inişine izin verilip verilmediğini kontrol eder.
IsOneUnitDistance: Belirtilen koordinatlara iniş yapmadan önce diğer roketlerle minimum birimlik mesafe olup olmadığını kontrol eder.
MarkArea: İniş yapılacak koordinatları işaretler.

Kurulum
Bu kütüphaneyi kullanmak için:

Bu projeyi derleyerek DLL dosyasını oluşturun.
Kullanmak istediğiniz C# projesine oluşturulan DLL dosyasını referans olarak ekleyin.
LandingAreaVerifier sınıfını kullanarak roket inişlerini kontrol edin.
SS'deki gibi Reference 'ı dll'nin kendi makinenizdeki yolunu vererek ekleyebilirsiniz.
<img width="1083" alt="Screen Shot 2023-12-17 at 20 45 18" src="https://github.com/senaserdar/RocketLandingVerifier/assets/53566797/f3262ac4-13bd-4a5d-9ffe-8be061c5824d">




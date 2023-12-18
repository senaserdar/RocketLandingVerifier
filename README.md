## Rocket Landing Verifier

Bu proje, roketlerin belirli bir iniş alanına güvenli bir şekilde inip inemediğini kontrol etmek için kullanılan bir C# sınıf kütüphanesini içerir. Kodun güvenirliliği unitTestler ile arttırılmıştır.

### Metodlar ve İşlevler

IsOutOfPlatform: Belirtilen koordinatların platform alanının dışında olup olmadığını kontrol eder.

IsCollision: Belirtilen koordinatlarda daha önce rocket inmiş mi kontrol eder.

IsOneUnitDistance: Belirtilen koordinatlara iniş yapmadan önce diğer roketlerle minimum 1 birimlik mesafe olup olmadığını kontrol eder.

MarkArea: İniş yapılacak koordinatları işaretler.

### Kurulum

Bu kütüphaneyi kullanmak için:

Bu projeyi derleyerek DLL dosyasını oluşturup kullanmak istediğiniz C# projenize oluşturulan DLL dosyasını referans olarak ekleyin.
LandingAreaVerifier sınıfını kullanarak roket inişlerini kontrol edebilirsiniz.


SS'deki gibi Reference 'ı dll'nin kendi makinenizdeki yolunu vererek eklenebilirsiniz.
<img width="1083" alt="Screen Shot 2023-12-17 at 20 45 18" src="https://github.com/senaserdar/RocketLandingVerifier/assets/53566797/f3262ac4-13bd-4a5d-9ffe-8be061c5824d">

### Örneğin; Bu projede basit bir şekilde dll'i reference olarak ekleyerek RocketLandingVerifier kütüphanesini kullanmaktadır.

https://github.com/senaserdar/SampleOfUsingRocketLandingVerifierDLL

<img width="1330" alt="Screen Shot 2023-12-17 at 22 30 45" src="https://github.com/senaserdar/RocketLandingVerifier/assets/53566797/b7562267-e342-496a-b669-c5cdd66cc5fa">




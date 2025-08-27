# Toplu Mail Gönderim Uygulaması

Bu proje, müşterilere toplu e-posta gönderimi yapmak, her müşteri için kupon kodu üretmek ve bu kuponları takip etmek için geliştirilmiş **C# .NET** tabanlı bir uygulamadır.

## 🚀 Özellikler
- Müşteri kayıtlarını listeleme ve yönetme
- Her müşteriye özel kupon kodu üretme
- Kuponların veritabanında saklanması
- E-posta ile müşteriye otomatik kupon gönderme
- **WinForms arayüzü** ile müşteri listesi görüntüleme
- **ASP.NET Core Web** entegrasyonu
- **Windows Service** desteği

## 📂 Proje Katmanları
- **Entities** → Müşteri sınıfı ve diğer modeller
- **Repository** → Veritabanı işlemleri
- **Helper** → Yardımcı sınıflar (E-posta, kupon üretimi vb.)
- **ConsoleApp** → Konsol uygulaması
- **Goruntule (WinForms)** → Müşteri yönetim arayüzü
- **WinServis** → Windows Service uygulaması
- **WebApp** → ASP.NET Core MVC entegrasyonu

## 🛠️ Kullanılan Teknolojiler
- C# (.NET Framework & .NET Core)
- WinForms
- ASP.NET Core MVC
- Windows Service
- FakeData kütüphanesi (örnek müşteri üretimi için)
- SMTP (E-posta gönderimi için)


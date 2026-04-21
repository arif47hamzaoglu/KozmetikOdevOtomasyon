# Kozmetik Otomasyon Sistemi

Bu proje, C# Windows Forms ve MySQL kullanılarak geliştirilen bir kozmetik ürün yönetim sistemidir. Okul ödevi kapsamında yapılmıştır.

---

## Projeyi Çalıştırmak İçin Gerekenler

- Visual Studio 2019 veya üzeri
- XAMPP (MySQL için)
- .NET Framework 4.7.2

---

## Projeyi İndirme (Klonlama)

Projeyi bilgisayarınıza indirmek için Git'in kurulu olması gerekmektedir.

1. Bir klasör açın, adres çubuğuna `cmd` yazıp Enter'a basın
2. Aşağıdaki komutu yapıştırın ve çalıştırın:

```
git clone https://github.com/arif47hamzaoglu/KozmetikOdevOtomasyon.git
```

3. İndirme tamamlanınca klasörün içine girin, `KozmetikOtomasyon.sln` dosyasını Visual Studio ile açın

---

## Kurulum

1. XAMPP'i açın, Apache ve MySQL'i başlatın
2. `KozmetikOtomasyon.sln` dosyasını Visual Studio ile açın
3. Solution Explorer'da projeye sağ tıklayıp **"Restore NuGet Packages"** deyin
4. `App.config` dosyasındaki MySQL şifresini kendi bilgilerinize göre düzenleyin
5. F5 ile çalıştırın — veritabanı ve tablolar otomatik oluşur

> MySQL şifreniz boşsa App.config'de bir şey değiştirmenize gerek yok.

---

## Giriş Bilgileri

| Alan | Değer |
|------|-------|
| Email | admin@admin.com |
| Şifre | 123456 |

---

## Özellikler

### Şu an çalışanlar
- Admin girişi
- Ürün ekleme, düzenleme, silme
- Sipariş oluşturma ve listeleme
- Sipariş durumu güncelleme (Beklemede / Onaylandı / İptal)
- Veritabanı bağlantısı (otomatik tablo oluşturma)

### İkinci aşamada eklenecekler
- Kullanıcı kayıt / giriş sistemi
- Rol bazlı yetkilendirme (Admin / Kullanıcı)
- Email bildirimi (Gmail SMTP)
- Kullanıcı yönetim paneli

---

## Proje Yapısı

```
KozmetikOtomasyon/
├── DatabaseHelper.cs      ← Tüm veritabanı işlemleri
├── EmailHelper.cs         ← Email gönderimi (henüz aktif değil)
├── Session.cs             ← Giriş yapan kullanıcıyı tutar
├── Models/
│   ├── User.cs
│   ├── Product.cs
│   └── Order.cs
└── Forms/
    ├── LoginForm          ← Giriş ekranı
    ├── MainForm           ← Ana panel
    ├── ProductAddEditForm ← Ürün ekle / düzenle
    └── OrderForm          ← Sipariş ver
```

---

## Veritabanı Tabloları

**Users** — Kullanıcı bilgileri  
**Products** — Ürün bilgileri (ad, fiyat, stok)  
**Orders** — Siparişler (hangi kullanıcı, hangi ürün, kaç adet)

---

## Kullanılan Teknolojiler

- C# / Windows Forms
- MySQL
- ADO.NET
- MySql.Data (NuGet)
- .NET Framework 4.7.2

---

## SQL Script Manuel Kurulum (İsteğe Bağlı)

Uygulama açılışta veritabanını otomatik oluşturur. Manuel kurmak isterseniz aşağıdaki adımları izleyin.

1. XAMPP Control Panel'i açın, **Apache** ve **MySQL**'i başlatın
2. Tarayıcıdan `http://localhost/phpmyadmin` adresine gidin
3. Üst menüden **SQL** sekmesine tıklayın
4. Proje kök dizinindeki `kozmetik_db.sql` dosyasını Not Defteri ile açın, içeriği kopyalayıp yapıştırın
5. **Git** butonuna basın

Sol panelde `kozmetik_db` veritabanı ve altında `users`, `products`, `orders` tabloları göründüyse kurulum tamamdır.

> MySQL şifreniz varsa `App.config` dosyasındaki `DbPassword` alanını güncelleyin.

---

## Notlar

- Proje iki aşamalı olarak geliştirilmektedir, bu repo birinci aşamayı kapsamaktadır
- SQL script dosyası `kozmetik_db.sql` olarak proje kök dizininde bulunmaktadır
- Veritabanı bağlantı ayarları `App.config` dosyasından değiştirilebilir

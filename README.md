# 🛍️ dotnet-store — ASP.NET Core MVC Mağaza Uygulaması

Udemy'de [Sadık Turan](https://www.udemy.com/course/komple-web-developer-kursu/) hocayla adım adım geliştirilen bu proje, ASP.NET Core MVC mimarisini gerçek bir e-ticaret senaryosu üzerinden öğrenmek amacıyla oluşturulmuştur.

---

## 🚀 Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|---|---|
| ASP.NET Core MVC (.NET 10) | Web uygulama çatısı |
| Entity Framework Core | ORM ve veritabanı yönetimi |
| SQLite | Geliştirme ortamı veritabanı |
| ASP.NET Core Identity | Kullanıcı yönetimi ve kimlik doğrulama |
| Razor Views | Sunucu taraflı HTML şablonlama |
| HTML / CSS / JavaScript | Ön yüz |

---

## 📁 Proje Yapısı

```
dotnet-store/
├── Controllers/        # HTTP isteklerini karşılayan controller sınıfları
├── Models/             # Uygulama veri modelleri (AppUser, AppRole vb.)
├── Views/              # Razor şablon dosyaları
├── Services/           # İş mantığı servisleri (CartService, EmailService)
├── ViewComponents/     # Yeniden kullanılabilir view bileşenleri
├── Data/               # DbContext ve seed verileri
├── Migrations/         # EF Core migration dosyaları
├── wwwroot/            # Statik dosyalar (CSS, JS, görseller)
└── Program.cs          # Uygulama başlangıç noktası ve servis konfigürasyonu
```

---

## ✨ Özellikler

- Ürün listeleme ve kategoriye göre filtreleme
- SEO dostu URL yapısı (`/urunler/{kategori}`)
- Kullanıcı kayıt, giriş ve çıkış işlemleri
- Rol tabanlı yetkilendirme (Identity rolleri)
- Sepet yönetimi servisi
- E-posta gönderimi (SMTP servis entegrasyonu)
- Hesap kilitleme (5 başarısız denemede 3 dakika kilit)
- 30 günlük oturum süresi (sliding expiration)

---

## ⚙️ Kurulum

### Gereksinimler

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Adımlar

```bash
# Repoyu klonla
git clone https://github.com/emrhankaratas/first-MVC-project.git
cd first-MVC-project

# Bağımlılıkları yükle
dotnet restore

# Veritabanını oluştur (migration'lar mevcut)
dotnet ef database update

# Uygulamayı başlat
dotnet run
```

Tarayıcıda `https://localhost:{port}` adresine git.

---

## 🔑 Identity Konfigürasyonu

`Program.cs` içinde aşağıdaki kurallar tanımlıdır:

- Minimum şifre uzunluğu: 7 karakter
- Özel karakter, büyük/küçük harf ve rakam zorunluluğu yok
- Benzersiz e-posta adresi zorunlu
- 5 hatalı girişte hesap 3 dakika kilitlenir

---

## 📚 Kaynak

Bu proje, Udemy'deki **[Komple Web Developer Kursu](https://www.udemy.com/course/komple-web-developer-kursu/)** kapsamında Sadık Turan hoca rehberliğinde geliştirilmiştir.

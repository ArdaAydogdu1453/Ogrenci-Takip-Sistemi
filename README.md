# Öğrenci ve Ders Takip Sistemi

Windows Forms (C#) ve MS SQL Server kullanılarak geliştirilmiş, öğrenci kayıtlarını, ders tanımlarını ve öğrencilerin sınıf seviyelerine uygun ders seçimlerini yönetmeyi sağlayan masaüstü otomasyon uygulamasıdır.

---

## 📑 İçindekiler
- [Proje Hakkında](#-proje-hakkında)
- [Özellikler ve Modüller](#-özellikler-ve-modüller)
- [Kullanılan Teknolojiler](#-kullanılan-teknolojiler)
- [Veritabanı Yapısı (`ardaDB.bacpac`)](#-veritabanı-yapısı-ardadbbacpac)
- [Kurulum ve Çalıştırma](#-kurulum-ve-çalıştırma)
- [Bağlantı Cümlesi (Connection String) Yapılandırması](#-bağlantı-cümlesi-connection-string-yapılandırması)
- [Proje Dizin Yapısı](#-proje-dizin-yapısı)

---

## 📌 Proje Hakkında

Bu proje; eğitim kurumları veya okul otomasyonu senaryoları için tasarlanmış çok pencereli bir Windows Forms uygulamasıdır. İlişkisel veritabanı mimarisi (ADO.NET) kullanılarak öğrencilerin bilgileri, açılan dersler ve öğrencilere atanan dersler SQL Server üzerinde saklanır ve yönetilir.

---

## 🚀 Özellikler ve Modüller

Uygulama 4 temel formdan oluşmaktadır:

### 1. Ana Panel (`Form1`)
- Modüller arası geçişi sağlayan ana kontrol ekranı.
- Öğrenci Yönetimi, Ders Yönetimi ve Ders Kayıt ekranlarına tek tıkla erişim.

### 2. Öğrenci Yönetimi (`Form2`)
- **Öğrenci Ekleme:** Öğrenci numarası, adı, soyadı ve sınıf bilgisi ile yeni kayıt oluşturma.
- **Öğrenci Silme:** Öğrenci numarasına göre kayıt silme.
- **Listeleme:** Kayıtlı öğrencilerin `DataGridView` üzerinde anlık listelenmesi.
- **Hızlı Seçim:** Tablodan seçilen öğrenci bilgilerinin otomatik olarak giriş kutularına aktarılması.

### 3. Ders Yönetimi (`Form3`)
- **Ders Ekleme:** Ders ID, ders adı ve sınıf seviyesi (örn. 9, 10, 11, 12) belirterek ders tanımlama.
- **Ders Silme:** Seçilen dersi veritabanından kaldırma.
- **Listeleme:** Mevcut derslerin tablo üzerinde anlık görüntülenmesi.

### 4. Öğrenci - Ders Kayıt ve Filtreleme (`Form4`)
- **Dinamik Ders Filtreleme:** ComboBox'tan bir öğrenci seçildiğinde, o öğrencinin sınıf seviyesine uygun dersler otomatik olarak listelenir.
- **Ders Atama:** Öğrenciye ilgili dersin tanımlanması (`ogrenci_ders` tablosu).
- **İlişkili Tablo Görünümü:** Öğrenci ve ders bilgilerinin `JOIN` sorgusuyla tek tabloda gösterimi.
- **Anlık Canlı Arama:** Öğrenci adı, soyadı, numarası veya sınıfına göre anlık metin tabanlı filtreleme (`DataView RowFilter`).
- **Değişiklik Yönetimi:** Silinen kayıtların filtrelenmesi ve geri alınabilmesi (`RejectChanges`).

---

## 🛠 Kullanılan Teknolojiler

- **Programlama Dili:** C# (.NET Framework 4.7.2)
- **Arayüz:** Windows Forms (WinForms)
- **Veri Tabanı:** Microsoft SQL Server
- **Veri Erişim Mimarisi:** ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `DataSet`, `DataTable`, `DataView`)
- **Geliştirme Ortamı:** Microsoft Visual Studio 2022

---

## 🗄 Veritabanı Yapısı (`ardaDB.bacpac`)

Proje kök dizininde yer alan `ardaDB.bacpac` dosyası projenin veritabanı yedeğidir. İçerisinde aşağıdaki tablolar ve ilişkiler yer almaktadır:

- **`ogrenciler`**: `ogr_no` (PK), `ogr_ad`, `ogr_soyad`, `ogr_sinif`
- **`dersler`**: `ders_id` (PK), `ders_adi`, `sinif_seviyesi`
- **`ogrenci_ders`**: `ogr_ders_id` (PK), `ogr_no` (FK), `ders_id` (FK)

---

## ⚙️ Kurulum ve Çalıştırma

### 1. Veritabanını İçe Aktarma (SSMS)
1. **SQL Server Management Studio (SSMS)** uygulamasını açın ve SQL Server örneğinize bağlanın.
2. Sol taraftaki **Object Explorer** panelinde **Databases** klasörüne sağ tıklayın.
3. **Import Data-tier Application...** seçeneğine tıklayın.
4. Çıkan pencerede bu repoda yer alan `ardaDB.bacpac` dosyasını seçin ve işlemi tamamlayın. `ardaDB` veritabanınız tüm tablolarıyla hazır olacaktır.

### 2. Projeyi Açma ve Derleme
1. Visual Studio'yu açın.
2. `drs_grencş.sln` çözüm (solution) dosyasını açın.
3. Gerekirse aşağıdaki bağlantı cümlesini kendi yerel SQL Server ortamınıza göre güncelleyin.
4. **F5** veya **Start** tuşuna basarak projeyi derleyip çalıştırın.

---

## 🔌 Bağlantı Cümlesi (Connection String) Yapılandırması

Kod içerisindeki varsayılan SQL bağlantı adresi:
```csharp
con = new SqlConnection("Data Source=VCLOUD-LAB2;Initial Catalog=ardaDB;Integrated Security=True");
```

Kendi bilgisayarınızda çalıştırmak için `Form1.cs`, `Form2.cs`, `Form3.cs` ve `Form4.cs` içerisindeki `Data Source` değerini kendi SQL Server adınızla değiştirebilirsiniz:
- Yerel varsayılan sunucu için: `Data Source=.;Initial Catalog=ardaDB;Integrated Security=True`
- SQLEXPRESS için: `Data Source=localhost\\SQLEXPRESS;Initial Catalog=ardaDB;Integrated Security=True`

---

## 📂 Proje Dizin Yapısı

```text
├── ardaDB.bacpac                # SQL Server veritabanı yedeği (DACPAC/BACPAC)
├── drs_grencş.sln               # Visual Studio Çözüm Dosyası
├── .gitignore                   # Visual Studio derleme & önbellek hariç tutma kuralları
├── README.md                    # Proje dokümantasyonu
└── drs_grencş/                  # C# Proje Klasörü
    ├── App.config               # Uygulama yapılandırma dosyası
    ├── drs_grencş.csproj        # C# Proje dosyası
    ├── Program.cs               # Giriş noktası (Main)
    ├── Form1.cs                 # Ana Menü
    ├── Form2.cs                 # Öğrenci İşlemleri Ekranı
    ├── Form3.cs                 # Ders İşlemleri Ekranı
    ├── Form4.cs                 # Öğrenci - Ders Kayıt ve Filtreleme Ekranı
    └── Properties/              # Derleme ve kaynak ayarları
```

# Content Management API

Bu proje, kullanıcıların içerik ve varyantlarını yönetebildiği bir içerik yönetim sistemidir. 

## Notes
1. **Content Language**: When entering a content language, the maximum length allowed is 5 characters.
2. **Technologies Used**: The project uses **GitHub Actions** for CI/CD and **Azure** for cloud hosting, specifically for build and deployment.
3. **API Address**: You can access the API documentation at the following URL:  
   [Content Management API](https://conent-managment-api-hxbfedebfedjd6bd.eastus-01.azurewebsites.net/swagger/index.html)

## Setup Instructions
...

## 🚀 Proje Özellikleri

- Kullanıcı içeriklerini listeleme
- İçerik detaylarını görüntüleme
- İçerik ekleme, güncelleme ve silme
- Varyant yönetimi (ekleme, güncelleme, silme)
- In-Memory Cache desteği
- Repository-Pattern
- SOLID 

## 🛠️ Kullanılan Teknolojiler

- **.NET Core 8**
- **Entity Framework Core**
- **In-Memory Cache**
- **Mapster** (DTO-Model mapping)
- **Swagger** (API dokümantasyonu)


## 📂 Proje Yapısı

Proje modüler bir mimari ile geliştirilmiştir:

```plaintext
CMS
├── shared
│   └── CMS.Shared
├── src
│   ├── CMS.API                # Controller ve API konfigürasyonları
│   ├── CMS.Application        # Servisler ve Mapper'lar
│   ├── CMS.Domain             # Modeller, DTO'lar, Repository ve Service Interface'leri, Unit of Work Interface'i
│   └── CMS.Infrastructure     # Veritabanı context'i, entity konfigürasyonları, repository implementasyonları


## Katman Açıklamaları

### CMS.API
- API endpointlerinin bulunduğu katmandır.  
- Burada **controller** sınıfları yer alır ve dış dünya ile sistem arasındaki giriş noktasıdır.  
- **Swagger** ve diğer API konfigürasyonları da bu katmanda bulunur.  

### CMS.Application
- Servislerin ve iş mantıklarının bulunduğu katmandır.  
- **Mapper'lar (Mapster)** burada konumlandırılmıştır.  
- **Service** sınıfları ile iş kuralları tanımlanır ve ilgili repository'lerle iletişim kurulur.  

### CMS.Domain
- **Modeller ve DTO'lar:** Sistemde kullanılan veri modelleri ve DTO nesneleri bu katmanda yer alır.  
- **Repository ve Service Interface'leri:** Veri erişim ve iş kurallarının arayüzleri burada tanımlanır.  
- **Unit of Work Interface'i:** Repository'ler arasındaki koordinasyonu sağlamak için kullanılan arayüzdür.  

### CMS.Infrastructure
- Veritabanı erişim katmanıdır.  
  - **Context:** Entity Framework `DbContext` sınıfı burada yer alır.  
  - **Entity Configurations:** **Fluent API** kullanılarak veri tabanı şeması tanımlanır.  
  - **Repository Implementations:** Repository arayüzlerinin somut implementasyonları burada yer alır.  



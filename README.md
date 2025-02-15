<h1 align="center">UsingHybridOrm - EF Core ve Dapper Hibrit Kullanımı</h1>

<p align="center">
Bu proje, <strong>EF Core</strong> ve <strong>Dapper</strong>'ın güçlü yönlerini bir araya getirerek, 
<strong>N-tier mimarisi</strong> ile dinamik, performanslı ve esnek bir veri erişim çözümü sunar.
</p>

---

<h2>🚀 Proje Özeti</h2>

<p>Bu proje, <strong>Entity Framework Core</strong> ve <strong>Dapper</strong>'ın hibrit kullanımını göstermektedir.</p>
<ul>
  <li>EF Core, güçlü ORM yetenekleri ile karmaşık veri işlemlerinde esneklik sağlar.</li>
  <li>Dapper, minimal ve hızlı sorgulama yetenekleri ile performans gereksinimlerini karşılar.</li>
</ul>

---

<h2>📌 Özellikler</h2>

<ul>
  <li><strong>EF Core</strong> ile ORM avantajları (veri modeli, ilişki yönetimi, LINQ sorguları).</li>
  <li><strong>Dapper</strong> ile hızlı ve hafif sorgulama kabiliyeti.</li>
  <li><strong>Dinamik veri erişim stratejisi</strong>: İhtiyaçlara göre EF Core ve Dapper arasında kolay geçiş.</li>
  <li><strong>Autofac Dependency Injection</strong> kullanımı ile sürdürülebilir ve modüler yapı.</li>
</ul>

---

<h2>📂 Proje Yapısı</h2>

<pre>
📁 UsingHybridOrm
│ 
├── UsingHybridOrm.DataAccess
│   ├── Dependencies
│   ├── 📁 Abstract
│   │   ├── 📁 Base
│   │   │   ├── ICommandRepository.cs
│   │   │   ├── IQueryRepository.cs
│   │   │   ├── IRepository.cs
│   │   ├── 📁 Resolver
│   │   │   ├── DalKeyEnum.cs
│   │   │   ├── IDepartmentRepositoryResolver.cs
│   │   ├── IDepartmentRepository.cs
│   ├── 📁 Concrete
│   │   ├── 📁 Dapper
│   │   │   ├── 📁 Base
│   │   │   │   ├── DapperBaseRepository.cs
│   │   │   ├── 📁 Connection
│   │   │   │   ├── ConnectionString.cs
│   │   │   ├── DapperDepartmentRepository.cs
│   │   ├── 📁 EntityFramework
│   │   │   ├── 📁 Base
│   │   │   │   ├── EfBaseRepository.cs
│   │   │   ├── 📁 Context
│   │   │   │   ├── HybridUsingOrmDbContext.cs
│   │   │   ├── EfDepartmentRepository.cs
├── UsingHybridOrm.Entities
│   ├── Dependencies
│   ├── 📁 Concrete
│   │   ├── BaseEntity.cs
│   │   ├── Department.cs
│   ├── 📁 DTO
│       ├── 📁 Department
│           ├── DepartmentCreateDTO.cs
│           ├── DepartmentDeleteDTO.cs
│           ├── DepartmentDTO.cs
│           ├── DepartmentUpdateDTO.cs
│       ├── Result.cs
├── UsingHybridOrm.Services
│   ├── Dependencies
│   ├── 📁 Abstract
│   │   ├── IDepartmentService.cs
│   ├── 📁 Concrete
│   │   ├── DepartmentService.cs
│   ├── 📁 DependencyInjection
│   │   ├── DependencyInjectionModule.cs
│   ├── 📁 Mapping
│   │   ├── MappingProfile.cs
│   ├── 📁 Resolver
│   │   ├── DalKey.cs
│   │   ├── DepartmentRepositoryResolver.cs
│   ├── 📁 Validation
│       ├── 📁 FluentValidation
│       │    ├── DepartmentValidator.cs
│       ├── ValidationTool.cs
├── 📁 UsingHybridOrm.UI
│   ├── Dependencies
│   ├── Form1.cs
│   ├── Program.cs
</pre>

---

<h2>🛠️ Kullanılan Teknolojiler</h2>

<ul>
  <li><strong>.NET 8</strong></li>
  <li><strong>Entity Framework Core</strong></li>
  <li><strong>Dapper</strong></li>
  <li><strong>Autofac</strong> (Dependency Injection)</li>
  <li><strong>MSSQL</strong> (Veritabanı)</li>
</ul>

using Autofac;
using AutoMapper;
using UsingHybridOrm.DataAccess.Abstract;
using UsingHybridOrm.DataAccess.Abstract.Resolver;
using UsingHybridOrm.DataAccess.Concrete.Dapper;
using UsingHybridOrm.DataAccess.Concrete.Dapper.Connection;
using UsingHybridOrm.DataAccess.Concrete.EntityFramework.Base;
using UsingHybridOrm.DataAccess.Concrete.EntityFramework.Context;
using UsingHybridOrm.Services.Abstract;
using UsingHybridOrm.Services.Concrete;
using UsingHybridOrm.Services.Mapping;
using UsingHybridOrm.Services.Resolver;
using Microsoft.Data.SqlClient;
using System.Data;

namespace UsingHybridOrm.Services.DependencyInjection
{
    /*
     Bu sınıf, Autofac kullanarak bağımlılıkları kaydetmek için oluşturulmuş bir modüldür.
     Module sınıfından türetilmiştir (Autofac'in bir parçası).
     Bu sınıfta, uygulamanızdaki tüm servislerin, DAL'lerin ve diğer bağımlılıkların nasıl kaydedileceği tanımlanır.
     */
    public class DependencyInjectionModule : 
                 Module
    {
        /*
         Load metodu, Autofac konteynerine bağımlılıkların nasıl ekleneceğini tanımlar.
         ContainerBuilder, bağımlılıkları kaydetmek için kullanılan Autofac'in temel sınıfıdır.
         
         Eğer bir sınıf, Autofac.Module sınıfından türetilmişse, Autofac bu sınıfın Load metodunu çağırırken otomatik olarak bir ContainerBuilder nesnesi sağlar.
         */
        protected override void Load(ContainerBuilder builder)
        {
            // Service kayıtları

            //RegisterType<T>():
            //Belirtilen sınıfın bir örneğinin oluşturulacağını belirtir.

            //.As<Interface>():
            //Kayıt edilen sınıfın, belirtilen arayüz veya sınıf türü olarak çözümleneceğini belirtir.
            //Örneğin, DepartmentService sınıfı, IDepartmentService arayüzü olarak çözümlenecek.

            builder.RegisterType<DepartmentService>()
                   .As<IDepartmentService>()
                   .InstancePerDependency();

            //InstancePerDependency() her çözümleme talebinde(her Resolve çağrısında) yeni bir nesne oluşturur.
            //SingleInstance() ile uygulama boyunca sadece bir adet DepartmentDalResolver nesnesi oluşturulur.

            //Resolver kayıtları
            builder.RegisterType<DepartmentRepositoryResolver>()
                    .As<IDepartmentRepositoryResolver>()
                    .InstancePerDependency();

            //Autofac ile Keyed Services özelliğini kullanarak, aynı servis içerisinde hem EF hem de Dapper implementasyonlarını kullanmak mümkün. Bu özellik .NET içerisinde de .NET 8 ile gelen Keyed Services özelliğinin karşılığı oluyor.

            // Ef ve Dapper DAL kayıtları - Keyed Services
            builder.RegisterType<EfDepartmentRepository>()
                   .Keyed<IDepartmentRepository>(DalKey.EF)
                   .InstancePerDependency();

            builder.RegisterType<DapperDepartmentRepository>()
                   .Keyed<IDepartmentRepository>(DalKey.Dapper)
                   .InstancePerDependency();

            // AutoMapper kayıtları
            //Burada MappingProfile, projemizde tanımladığımız mapping kurallarını içeren bir sınıftır.

            //AsSelf(), bu sınıf doğrudan kendi türüyle(yani MappingProfile) çözümlenir anlamına gelir.
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            })).AsSelf().SingleInstance();

            //IMapper, bir arayüzdür, ancak MapperConfiguration.CreateMapper() çağrısı, Mapper sınıfından bir nesne oluşturur ve bu nesne IMapper arayüzünü uygular. Bu nedenle, IMapper gibi davranan nesne aslında Mapper sınıfına aittir ve CreateMapper() bu nesneyi sağlar.
            builder.Register(mc =>
            {
                var config = mc.Resolve<MapperConfiguration>();
                return config.CreateMapper();
            }).As<IMapper>().SingleInstance();

            /*
             NOT:

             Servislerde dönüşüm yapılırken IMapper arayüzü üzerinden AutoMapper çağrılır. Yani dönüşüm işlemlerini AutoMapper'ın merkezi bir nesnesi (Mapper) yönetir.
             DI Container'a AutoMapper'ı eklemek, dönüşüm işlemlerini çözümlemek için gereklidir.

             FluentValidation'da her Validator sınıfı, açık bir şekilde tanımlanmış kurallara sahiptir.

             Bir validasyon işlemi sırasında doğrudan bir validator nesnesi oluşturulur ve onun Validate() metodu çağrılır.Onun için AutoMapper'ın Container'a kaydı yapılırken FluentValidation'nın yapılmaz.
             */

            //Context kayıtları
            builder.RegisterType<UsingHybridOrmDbContext>()
                  .AsSelf()
                  .InstancePerDependency();

            // IDbConnection'ı kayıt etttik.
            builder.Register(c =>
            {
                var connectionString = ConnectionString.Connection;
                return new SqlConnection(connectionString);
            }).As<IDbConnection>().SingleInstance();
        }
    }
}

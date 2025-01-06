using Autofac;
using UsingHybridOrm.DataAccess.Abstract;
using UsingHybridOrm.DataAccess.Abstract.Resolver;

namespace UsingHybridOrm.Services.Resolver
{
    internal class DepartmentRepositoryResolver :
                   IDepartmentRepositoryResolver
    {
        private readonly IComponentContext _context;

        /*
         Burada IComponentContext yerine IContainer bekleyebilirdik. Çünkü IContainer, IComponentContext'in bir inheritidir ve IComponentContext'ten türetilmiştir. Bu nedenle, bu tür senaryolarda Autofac bize esneklik sağlar: İkisini de kullanabiliriz.

        IComponentContext:

        Sadece bağımlılık çözümleme işlemlerini temsil eder.
        Eğer bir sınıf yalnızca bağımlılık çözümleme (örneğin, Resolve<T>()) yapıyorsa, IComponentContext kullanımı daha uygundur.
        Daha soyut bir arabirimdir ve bağımlılık çözümleme işlemini sınıfınıza "daha az bilgiyle" sağlar (örneğin, konteynerin kendisi hakkında daha fazla bilgiye ihtiyaç yoksa).

        IContainer:
        
        IComponentContext'ten türetilir ve aynı özelliklere sahiptir.
        Bunun dışında, konteyneri genişletmek, yeni bağımlılıklar eklemek gibi işlemleri de destekler.
        Uygulamanın merkezi DI konteyneri olarak kullanılır. Genellikle bağımlılıkları kaydetmek ve çözmek için ana yapı olarak tercih edilir.
         */
        
        public DepartmentRepositoryResolver(IComponentContext context)
        {
            _context = context;
        }

        public IDepartmentRepository CreateDepartmentRepository(DalKeyEnum key)
        {
            switch (key)
            {
                case DalKeyEnum.EF:
                    return _context.ResolveKeyed<IDepartmentRepository>(DalKey.EF);
                case DalKeyEnum.Dapper:
                    return _context.ResolveKeyed<IDepartmentRepository>(DalKey.Dapper);
                default:
                    throw new ArgumentException("Invalid DAL Key");
            }
        }
    }
}

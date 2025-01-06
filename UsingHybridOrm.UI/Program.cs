using Autofac;
using UsingHybridOrm.Services.Abstract;
using UsingHybridOrm.Services.DependencyInjection;

namespace UsingHybridOrm.UI
{
    internal static class Program
    {
        private static IContainer _container = null!;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            _container = Configure();
            Application.Run(new Form1(_container.Resolve<IDepartmentService>()));
        }

        static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterModule<DependencyInjectionModule>() çaðrýsý yapýldýðýnda:
            //Autofac, DependencyInjectionModule sýnýfýnýn Load metodunu otomatik olarak çaðýrýr ve bu metoda bir ContainerBuilder nesnesi saðlar. Bu nesne aslýnda bizim burada builder.Build() ile oluþturacaðýmýz nesne oluyor.
            //Load metodu içindeki tüm builder.Register ifadeleri çalýþtýrýlarak baðýmlýlýklarýn kaydedilmesi saðlanýr.
            builder.RegisterModule<DependencyInjectionModule>();

            /*
             builder.Build() metodu kayýt edilen tüm baðýmlýlýklarý içeren bir IContainer nesnesi oluþturur. (ContainerBuilder)
             Build() metodundan sonra, ContainerBuilder kullanýlarak yapýlan tüm kayýtlar tamamlanmýþ olur ve artýk yeni baðýmlýlýklar eklenemez.
             */

            return builder.Build();
        }
    }
}

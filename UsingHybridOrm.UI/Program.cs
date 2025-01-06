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

            //builder.RegisterModule<DependencyInjectionModule>() �a�r�s� yap�ld���nda:
            //Autofac, DependencyInjectionModule s�n�f�n�n Load metodunu otomatik olarak �a��r�r ve bu metoda bir ContainerBuilder nesnesi sa�lar. Bu nesne asl�nda bizim burada builder.Build() ile olu�turaca��m�z nesne oluyor.
            //Load metodu i�indeki t�m builder.Register ifadeleri �al��t�r�larak ba��ml�l�klar�n kaydedilmesi sa�lan�r.
            builder.RegisterModule<DependencyInjectionModule>();

            /*
             builder.Build() metodu kay�t edilen t�m ba��ml�l�klar� i�eren bir IContainer nesnesi olu�turur. (ContainerBuilder)
             Build() metodundan sonra, ContainerBuilder kullan�larak yap�lan t�m kay�tlar tamamlanm�� olur ve art�k yeni ba��ml�l�klar eklenemez.
             */

            return builder.Build();
        }
    }
}

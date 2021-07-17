//using Prism.Unity;
using Prism.Mef;
using HelloWorld.Views;
using System.Windows;
using Prism.Modularity;
using ModuleA;
using ModuleB;
using System.ComponentModel.Composition.Hosting;

namespace HelloWorld
{
    class Bootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()  // 2. Create Shell. 
        {
            //return Container.Resolve<MainWindow>(); // Unity
            return Container.GetExportedValue<MainWindow>(); // MEF
        }

        protected override void InitializeShell() // 3. InitializeShell
        {
            Application.Current.MainWindow.Show();
        }

        /* protected override void ConfigureModuleCatalog() // UNITY
         {
             ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;  // 1. Before creating the shell, configure modules. 
             catalog.AddModule(typeof(ModuleAModule));
             catalog.AddModule(typeof(ModuleBModule));

         }*/

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleAModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleBModule).Assembly));
        }
    }
}

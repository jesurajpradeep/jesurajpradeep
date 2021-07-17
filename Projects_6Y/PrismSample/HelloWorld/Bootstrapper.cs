using Microsoft.Practices.Unity;
using Prism.Unity;
using HelloWorld.Views;
using System.Windows;
using Prism.Modularity;
using ModuleA;
using ModuleB;

namespace HelloWorld
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()  // 2. Create Shell. 
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell() // 3. InitializeShell
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;  // 1. Before creating the shell, configure modules. 
            catalog.AddModule(typeof(ModuleAModule));
            catalog.AddModule(typeof(ModuleBModule));

        }
    }
}

using Microsoft.Practices.Unity;
using Prism.Unity;
using EmployeeRegistrationApp.Views;
using System.Windows;
using EmpRegistration.Views;
using EmpView;
using Prism.Modularity;

namespace EmployeeRegistrationApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;  // 1. Before creating the shell, configure modules. 
            catalog.AddModule(typeof(EmpRegistration.EmpRegistrationModule));
            catalog.AddModule(typeof(EmpView.EmpViewModule));

        }
    }
}

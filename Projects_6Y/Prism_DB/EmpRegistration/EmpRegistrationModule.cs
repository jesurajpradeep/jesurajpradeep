using EmpRegistration.Views;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace EmpRegistration
{
    public class EmpRegistrationModule : IModule
    {
        IRegionManager _regionManager;

        public EmpRegistrationModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("EmpRegistrationView", typeof(EmpRegistrationView));
        }
    }
}
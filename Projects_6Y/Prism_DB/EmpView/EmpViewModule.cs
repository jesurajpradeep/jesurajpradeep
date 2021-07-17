using EmpView.Views;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace EmpView
{
    public class EmpViewModule : IModule
    {
        IRegionManager _regionManager;

        public EmpViewModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("EmpDataView", typeof(EmpDataView));
        }
    }
}
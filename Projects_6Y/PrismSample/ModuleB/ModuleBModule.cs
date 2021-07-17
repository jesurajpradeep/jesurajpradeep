using Prism.Modularity;
using Prism.Regions;
using System;
using ModuleB.Views;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        IRegionManager _regionManager;

        public ModuleBModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegionB", typeof(ViewB));
        }
    }
}
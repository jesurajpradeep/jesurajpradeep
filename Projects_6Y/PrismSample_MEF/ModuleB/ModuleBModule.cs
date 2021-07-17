using Prism.Modularity;
using Prism.Regions;
using System;
using ModuleB.Views;
using Prism.Mef;
using Prism.Mef.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;

namespace ModuleB
{
    [ModuleExport(typeof(ModuleBModule))]
    public class ModuleBModule : IModule
    {
        IRegionManager _regionManager;

        /*
        [ImportingConstructor]
        public ModuleBModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }*/

        public void Initialize()
        {
            _regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            _regionManager.RegisterViewWithRegion("MainRegionB", typeof(ViewB));
        }
    }
}
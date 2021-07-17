using Prism.Modularity;
using Prism.Regions;
using ModuleA.Views;
using Prism.Mef.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;

namespace ModuleA
{
    [ModuleExport(typeof(ModuleAModule))]
    public class ModuleAModule : IModule
    {
        IRegionManager _regionManager;
        /*
        [ImportingConstructor]
        public ModuleAModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        */
        public void Initialize()
        {
            _regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            _regionManager.RegisterViewWithRegion("MainRegion", typeof(ViewA));
            
        }
    }
}
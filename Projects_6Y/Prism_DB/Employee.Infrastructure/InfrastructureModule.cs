using Prism.Modularity;
using Prism.Regions;
using System;

namespace Employee.Infrastructure
{
    public class InfrastructureModule : IModule
    {
        IRegionManager _regionManager;

        public InfrastructureModule(RegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
using DynamicLoad.Contracts;
using DynamicLoad.Contracts.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicLoad.Contracts.Services
{
    public class ModuleService : IModuleService
    {
        private IServiceCollection _services;
        private ServiceProvider _provider;

        public ModuleService(IServiceCollection services)
        {
            _services = services;
            _provider = _services.BuildServiceProvider();
        }

        public ICommonModuleService GetModuleService(Guid id)
        {
            IEnumerable<ICommonModuleService> modulesServices = _provider.GetServices<ICommonModuleService>();
            return modulesServices.FirstOrDefault(s => s.ModuleInfo.Module_GId == id);
        }

        public RenderFragment CreateAndGetMainView(Guid module_gid) => builder =>
        {
            var temp = GetModuleService(module_gid).GetMainView();
            builder.OpenComponent(0, temp.GetType());
            //builder.AddAttribute(0, "ServiceCollection", GetModuleService(moduleService, module).GetServiceCollection());
            builder.CloseComponent();
        };

        public RenderFragment CreateAndGetTreeView(Guid module_gid) => builder =>
        {
            var temp = GetModuleService(module_gid).GetTreeView();
            builder.OpenComponent(0, temp.GetType());
            //builder.AddAttribute(0, "ServiceCollection", GetModuleService(moduleService, module).GetServiceCollection());
            builder.CloseComponent();
        };

        public List<ModuleInfo> GetModuleInfos()
        {
            IEnumerable<ICommonModuleService> modulesServices = _provider.GetServices<ICommonModuleService>();
            return modulesServices.Select(m => m.ModuleInfo).ToList();
        }
    }
}

using DynamicLoad.Contracts.Classes;
using Microsoft.AspNetCore.Components;

namespace DynamicLoad.Contracts
{
    public interface IModuleService
    {
        ICommonModuleService GetModuleService(Guid id);
        List<ModuleInfo> GetModuleInfos();
        RenderFragment CreateAndGetTreeView(Guid module_gid);
        RenderFragment CreateAndGetMainView(Guid module_gid);
    }
}

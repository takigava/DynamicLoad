using DynamicLoad.Contracts.Classes;
using Microsoft.AspNetCore.Components;

namespace DynamicLoad.Contracts
{
    public interface ICommonModuleService
    {
        ModuleInfo ModuleInfo { get; }
        ComponentBase GetTreeView();
        ComponentBase GetMainView();
    }
}

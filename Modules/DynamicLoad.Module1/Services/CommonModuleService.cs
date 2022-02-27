using DynamicLoad.Contracts;
using DynamicLoad.Contracts.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLoad.Module1.Services
{
    public class CommonModuleService : ICommonModuleService
    {
        IServiceCollection _services;
        public CommonModuleService(IServiceCollection services)
        {
            this._services = services;
        }

        ModuleInfo _moduleInfo;
        ModuleInfo ICommonModuleService.ModuleInfo
        {
            get
            {
                if (_moduleInfo != null)
                    return _moduleInfo;
                else
                {
                    _moduleInfo = new ModuleInfo()
                    {
                        Name = "Module 1",
                        Module_GId = new Guid("{62D4F363-9557-4D87-90C7-9D832517C5C7}")
                    };

                    return _moduleInfo;
                }
            }
        }

        public ComponentBase GetMainView()
        {
            return new MainView(this._services);
        }

        public ComponentBase GetTreeView()
        {
            return new TreeView(this._services);
        }
    }
}

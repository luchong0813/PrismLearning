using ModuleA.View;
using ModuleA.ViewModle;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    public class ModuleAProfile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
            //注册时指定ViewMode并指定别名
            //containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>("ViewAVM");
        }
    }
}

using MainModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using ModuleB;
using ModuleA;

namespace MainModule
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<ModuleAProfile>();
            //moduleCatalog.AddModule<ModuleBProfile>();
            //base.ConfigureModuleCatalog(moduleCatalog);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        }
    }
}

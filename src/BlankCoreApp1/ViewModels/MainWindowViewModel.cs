using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace BlankCoreApp1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private readonly IRegionManager _regionManage;
        public DelegateCommand<string> OpenCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManage = regionManager;
            OpenCommand = new DelegateCommand<string>(OpenMethod);
        }

        private void OpenMethod(string obj)
        {
            //Tips:只能具有Window或Frame父级才可以请求导航

            //通过IRegionManager获取全局定义可用的区域
            //通过注册的区域名称找到区域动态的去设置内容
            _regionManage.Regions["ModuleContent"].RequestNavigate(obj);
        }
    }
}

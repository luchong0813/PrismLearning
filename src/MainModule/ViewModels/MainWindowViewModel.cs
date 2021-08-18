using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace MainModule.ViewModels
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
        private  IRegionNavigationJournal journal;
        public DelegateCommand<string> OpenCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }
        public DelegateCommand NextCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManage = regionManager;
            OpenCommand = new DelegateCommand<string>(OpenMethod);
            BackCommand = new DelegateCommand(Back);
            NextCommand = new DelegateCommand(Next);
        }

        private void Next()
        {
            if (journal.CanGoForward)
            {
                journal.GoForward();
            }
        }

        private void Back()
        {
            if (journal.CanGoBack)
            {
                journal.GoBack();
            }
        }

        private void OpenMethod(string obj)
        {
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("Keys1", "Hello Prism！");

            _regionManage.Regions["ModuleContent"].RequestNavigate(obj, navigationCallback =>
            {
                if ((bool)navigationCallback.Result)
                {
                    journal = navigationCallback.Context.NavigationService.Journal;
                }
            }, pairs);
        }
    }
}

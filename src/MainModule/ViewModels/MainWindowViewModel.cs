using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

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
        private readonly IDialogService _dialogService;
        private  IRegionNavigationJournal journal;
        public DelegateCommand<string> OpenCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }
        public DelegateCommand NextCommand { get; private set; }
        public DelegateCommand<string> OpenDialogCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager,IDialogService dialogAware)
        {
            _regionManage = regionManager;
            _dialogService = dialogAware;
            OpenCommand = new DelegateCommand<string>(OpenMethod);
            BackCommand = new DelegateCommand(Back);
            NextCommand = new DelegateCommand(Next);
            OpenDialogCommand = new DelegateCommand<string>(OpenDialog);
        }

        private void OpenDialog(string obj)
        {
            DialogParameters pairs = new DialogParameters
            {
                { "Title", "我是标题" }
            };
            _dialogService.ShowDialog("DialogView", pairs,callback=> {
                if (callback.Result==ButtonResult.OK)
                {
                    MessageBox.Show($"参数1：{callback.Parameters.GetValue<string>("Parameters1")}\r\n" +
                        $"参数2：{callback.Parameters.GetValue<string>("Parameters2")}");
                }
            });
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

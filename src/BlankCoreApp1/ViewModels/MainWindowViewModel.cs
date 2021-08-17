using DryIoc;
using Prism.Mvvm;

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

        private string _content="Hello Prism!";

        public string Content
        {
            get { return _content="Hello Prism!"; }
            set { _content = value; }
        }


        public MainWindowViewModel()
        {
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogSample.ViewModels
{
    public class DialogViewViewModel : IDialogAware
    {
        public string Title { get; set; }

        public string Parameters1 { get; set; }
        public string Parameters2 { get; set; }

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand CancelCmd { get; set; }
        public DelegateCommand SaveCmd { get; set; }

        public DialogViewViewModel()
        {
            CancelCmd = new DelegateCommand(Cancel);
            SaveCmd = new DelegateCommand(Save);
        }

        private void Save()
        {
            OnDialogClosed();
        }

        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            DialogParameters pairs = new DialogParameters
            {
                { "Parameters1", Parameters1 },
                { "Parameters2", Parameters2 }
            };
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, pairs));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");
        }
    }
}

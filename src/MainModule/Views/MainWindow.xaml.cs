using MainModule.Event;
using Prism.Events;
using System;
using System.Windows;

namespace MainModule.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator _aggregator;

        public MainWindow(IEventAggregator aggregator)
        {
            InitializeComponent();
            _aggregator = aggregator;

            _aggregator.GetEvent<MessageEvent>().Subscribe(ShowMethod, arg => arg.Code == 500); 
        }

        private void ShowMethod(MessageModel obj)
        {
            MessageBox.Show($"Code:{obj.Code}\r\nMessage:{obj.Message}\r\nData:{obj.Data}", "系统提示");
            //_aggregator.GetEvent<MessageEvent>().Unsubscribe(ShowMethod);
        }
    }
}

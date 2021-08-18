using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleA.ViewModle
{
    public class ViewAViewModel : BindableBase,IConfirmNavigationRequest
    {
        public ViewAViewModel()
        {

        }

        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }


        /// <summary>
        /// 每次重新导航的时候，是否使用原来已创建的实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns>True：使用原来的实例，False：重新创建实例</returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 拦截导航请求
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        /// <summary>
        /// 导航上下文（用于获取传递的参数等）
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("Keys1"))
            {
                Content = navigationContext.Parameters.GetValue<string>("Keys1");
            }

        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;

            if (MessageBox.Show("确认是否要离开当前模块？","系统提示",MessageBoxButton.YesNo)==MessageBoxResult.No)
            {
                result = false;
            }

            continuationCallback(result);
        }
    }
}

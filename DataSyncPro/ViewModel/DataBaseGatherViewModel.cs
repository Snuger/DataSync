using DataSyncPro.UserControls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSyncPro.ViewModel
{
    public class DataBaseGatherViewModel:ViewModelBase
    {
        public DataBaseGatherViewModel()
        {
            //打开窗口
            OpenDbConfigDilogCommand = new RelayCommand(OpenDbConfigDilog);            
        }

        public ICommand OpenDbConfigDilogCommand { get;  } 

        public ICommand SaveDbConfigDilogCommand { get; set; }



        private async void OpenDbConfigDilog()
        {
            var view = new DataBaeConfigPanel();
            var result = await DialogHost.Show(view, DbConfigDilogCloseEventHanle);
          }
        private void DbConfigDilogCloseEventHanle(object Sender,DialogClosingEventArgs args) {
            if ((bool)args.Parameter == false) return;
            args.Cancel();
        }
    }
}

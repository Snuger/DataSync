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
using DataSyncPro.Contract.IService;
using DataSyncPro.Db;

namespace DataSyncPro.ViewModel
{
    public class DataBaseGatherViewModel:ViewModelBase
    {
        private IDataBaseService dataBaseService;      

        public DataBaseGatherViewModel(IDataBaseService baseService)
        {
            this.dataBaseService = baseService;
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
            DataBaeConfigViewModel model =((System.Windows.FrameworkElement)args.Session.Content).DataContext as DataBaeConfigViewModel;
            //SynchronousDb db = new SynchronousDb();
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap< DataBaeConfigViewModel,SynchronousDb>());
            //AutoMapper.Mapper.Map(model, db);
            SynchronousDb db= AutoMapper.Mapper.Map<SynchronousDb>(model);
            dataBaseService.Add(db);
            args.Cancel();
        }
    }
}

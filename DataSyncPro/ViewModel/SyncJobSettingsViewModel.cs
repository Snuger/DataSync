using DataSyncPro.Model;
using DataSyncPro.UserControls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.ViewModel
{
   public  class SyncJobSettingsViewModel
    {
        private List<BasicMenu> _menus;

        public List<BasicMenu> Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        public SyncJobSettingsViewModel()
        {
            Menus = new List<BasicMenu>() {
                 new BasicMenu(){Id="1", Name="任务列表",Discription="显示设置所有的任务", Kiind=PackIconKind.Ballot, ParentId="0", Content=new SyncJobGatherPanel() },
                 new BasicMenu(){Id="2", Name="正在执行",Discription="显示设置正运行任务", Kiind=PackIconKind.ArrowUpBoldBox, ParentId="0", Content=new SyncJobRuningGatherPanel() },
                 new BasicMenu(){Id="3", Name="已完成",Discription="显示设置已完成任务", Kiind=PackIconKind.ChevronDownCircleOutline, ParentId="0", Content=new SyncJobComplatedGatherPanel() },
                 new BasicMenu(){Id="4", Name="已作废",Discription="显示设置已作废任务", Kiind=PackIconKind.DeleteForeverOutline, ParentId="0", Content=new SyncJobObsoleteGatherPanel() }
            };
        }
    }
}

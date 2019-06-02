﻿using DataSyncPro.Contract;
using DataSyncPro.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSyncPro.UserControls;

namespace DataSyncPro.Design
{
    public class SpecialMenuService : ISpecialMenuService
    {
        public void GetBasicMenu(Action<IEnumerable<BasicMenu>, Exception> callback)
        {
            List<BasicMenu> basicMenus = new List<BasicMenu>() {
                  new BasicMenu(){Id="1", Name="系统设置", ParentId="0", Kiind=PackIconKind.Settings},
                  new BasicMenu(){Id="2", Name="用户设置", ParentId="0", Kiind=PackIconKind.AccountSettings},
                  new BasicMenu(){Id="3", Name="数据同步", ParentId="0", Kiind=PackIconKind.UploadNetwork, Content=new AutomaticUploadPnel()},
                  new BasicMenu(){Id="4", Name="用户设置", ParentId="0", Kiind=PackIconKind.PrinterSettings},
                  new BasicMenu(){Id="5", Name="用户设置", ParentId="0", Kiind=PackIconKind.SettingsBox},
                  new BasicMenu(){Id="6", Name="用户设置", ParentId="0", Kiind=PackIconKind.RouterWirelessSettings},
                  new BasicMenu(){Id="7", Name="用户设置", ParentId="0", Kiind=PackIconKind.SettingsHelper}

            };
            callback(basicMenus, null);
        }
    }
}

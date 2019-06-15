using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.ViewModel.DBViewModel
{
    public class SynchronousDbViewModel
    {
        public int ID { get; set; }

        public int DbType { get; set; }

        public string Ip { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string InstanceName { get; set; }

        public int Enable { get; set; }

        public bool IsChecked { get; set; }
    }
}

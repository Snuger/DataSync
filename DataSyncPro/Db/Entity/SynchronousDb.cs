using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.Db
{
    /// <summary>
    /// 数据库配置
    /// </summary>
    public class SynchronousDb
    {
        public int Id { get; set; }

        public string DbType { get; set; }


        public string Ip { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string InstanceName { get; set; }

        public int enable { get; set; }

    }
}

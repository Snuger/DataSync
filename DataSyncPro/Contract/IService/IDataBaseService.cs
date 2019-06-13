using DataSyncPro.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.Contract.IService
{
    public interface IDataBaseService
    {
        Task<SynchronousDb> Add(SynchronousDb synchronousDb);
    }
}

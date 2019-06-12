using DataSyncPro.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.Contract.IRepository
{
    public interface IDataBaseRepository:IQueryRepostry<SynchronousDb,int>,IUpdateRepostry<SynchronousDb,int>
    {
      
    }
}

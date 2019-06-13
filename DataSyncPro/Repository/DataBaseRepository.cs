using DataSyncPro.Db;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSyncPro.Contract.IRepository;

namespace DataSyncPro.Repository
{
    public class DataBaseRepository : IDataBaseRepository
    {
        public Task<SynchronousDb> Add(SynchronousDb model, Action<SynchronousDb, Exception> callBack)
        {
            try
            {
                using (DataSyncContext context = new DataSyncContext())
                {
                    context.SynchronousDb.Add(model);
                    context.SaveChanges();
                }
                callBack(model, null);
            }
            catch (Exception ex)
            {
                callBack(model, ex);               
            }
            return Task.FromResult(model);
        }

        public Task<SynchronousDb> Delete(int key, Action<SynchronousDb, Exception> callBack)
        {
            throw new NotImplementedException();
        }

        public SynchronousDb GetItemByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SynchronousDb> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task<SynchronousDb> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SynchronousDb> GetItemsByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SynchronousDb> Update(SynchronousDb model, Action<SynchronousDb, Exception> callBack)
        {
            throw new NotImplementedException();
        }
    }
}

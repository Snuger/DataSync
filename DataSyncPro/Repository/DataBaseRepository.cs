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
            try
            {
                using (DataSyncContext context = new DataSyncContext())
                {
                   var obj= context.SynchronousDb.Where(c => c.ID == key).FirstOrDefault();
                    context.SynchronousDb.Remove(obj);
                    callBack(obj, null);
                    context.SaveChangesAsync();
                   return  Task.FromResult(obj);
                }
            }
            catch (Exception ex)
            {
                callBack(null, ex);
                return null;
            }
        }

        public SynchronousDb GetItemByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SynchronousDb> GetItems()
        {           
            using (DataSyncContext context = new DataSyncContext()) {
                return context.SynchronousDb.ToList();
            }                      
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

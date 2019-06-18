using DataSyncPro.Contract.IService;
using DataSyncPro.Contract.IRepository;
using DataSyncPro.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DataSyncPro.Services
{
    public class DataBaseService : IDataBaseService
    {
        private IDataBaseRepository repository;

        public DataBaseService(IDataBaseRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SynchronousDb> Add(SynchronousDb synchronousDb)
        {
            SynchronousDb db = null;
            await repository.Add(synchronousDb, (item, error) =>
            {
                if (error != null)
                    return;
                db = item;
            });
            return db;
        }

        public async Task<bool> Delete(int ID)
        {
            bool result = false;
            await repository.Delete(ID, (item, err) => {
                if (err != null)                
                    return;   
                result = true;
            });
            return result;
        }

        public  IEnumerable<SynchronousDb>GetSynchronousDbs()=>repository.GetItems();

        public async Task<SynchronousDb> Update(SynchronousDb synchronousDb)
        {
            SynchronousDb db = new SynchronousDb();
            await repository.Update(synchronousDb,(item,err)=> {
                if (err != null)
                    return;
                db = item;
            });
            return db;
        }
    }
}

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
                    db = item;
            });
            return db;
        }

        public async Task<bool> Delete(int ID)
        {
            bool result = false;
            await repository.Delete(ID, (item, err) => {
                if (err != null)
                {
                    result = true;
                }
            });
            return true;
        }

        public  IEnumerable<SynchronousDb>GetSynchronousDbs()=>repository.GetItems();
    
    }
}

using DataSyncPro.Contract.IService;
using DataSyncPro.Contract.IRepository;
using DataSyncPro.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

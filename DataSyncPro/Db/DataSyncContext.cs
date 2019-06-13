using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.Db
{
    public class DataSyncContext : DbContext
    {
        private const string ConnectionString = "DataSyncPro";

        public DataSyncContext():base(ConnectionString)
        {
        }

        public DataSyncContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<SynchronousDb> SynchronousDb { get; set; }

    }
}

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
        private const string ConnectionString = @"data source=DataSyncPro.db";

        public DataSyncContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<SynchronousDb> SynchronousDbs { get; set; }

    }
}

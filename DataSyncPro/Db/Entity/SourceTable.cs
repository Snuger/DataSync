using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.Db.Entity
{
    [Table("SourceTables")]
    public  class SourceTable
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string TableName { get; set; }

        public string Discription { get; set; }
                          
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSync.Model;

namespace DataSync.Api
{
    public class TaskQueue
    {
        public delegate void NewTaskJobAddHadle(List<DataCell> dataCells);

        protected List<DataCell> TaskQueus { get; set; }

        public TaskQueue()
        {
            TaskQueus = new List<DataCell>();
        }

        /// <summary>
        /// 获取所有的
        /// </summary>
        /// <returns></returns>
        public List<DataCell> GetIncomplate() => TaskQueus.ToList();


    }
}

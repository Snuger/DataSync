using DataSync.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataSync.Api
{
    public class UploadCompontent
    {
        /// <summary>
        /// 任务执行完毕时
        /// </summary>
        /// <param name="dataCell"></param>
        public delegate void CompontentComplatedHadel(DataCell dataCell);
        public event CompontentComplatedHadel CompontentComplatedEvent;

        /// <summary>
        /// 线程数
        /// </summary>
        protected int UploadThreadNum { get; set; }

        /// <summary>
        /// 当前线程工作的任务是否完成
        /// </summary>
        protected bool IsComplated { get; set; }

        /// <summary>
        /// 当前线程工作的数据单元
        /// </summary>
        public DataCell CurrentDataCell { get; set; }

        /// <summary>
        /// 工作线程
        /// </summary>
        protected Thread WorkingTread { get; set; }


        public UploadCompontent(DataCell currentDataCell)
        {
            CurrentDataCell = currentDataCell;
            this.UploadThreadNum = CurrentDataCell.Id;
            this.IsComplated = false;
        }


        public void CreateCompontentWorkThrad()
        {
            WorkingTread = new Thread(new ThreadStart(CompontentDoWork));
            WorkingTread.IsBackground = true;          
        }

        protected void CompontentDoWork()
        {
            Random random = new Random();
            while (true)
            {
                if (this.CurrentDataCell.UploadedTotal < this.CurrentDataCell.Total)
                {
                    int uploadTotal = CurrentDataCell.UploadedTotal + random.Next(1, 500);
                    this.CurrentDataCell.UploadedTotal = uploadTotal >= CurrentDataCell.Total?CurrentDataCell.Total: uploadTotal;
                    Thread.Sleep(new Random().Next(100, 2000));
                }
                else
                {
                    CompontentComplatedEvent?.Invoke(this.CurrentDataCell);
                }
            }
        }

        public void Start() => WorkingTread?.Start();

        public void Suspend() => WorkingTread?.Suspend();


        /// <summary>
        /// 
        /// </summary>
        public void Resume() => WorkingTread?.Resume();

        /// <summary>
        /// 注销线程
        /// </summary>
        public void Abort() => WorkingTread?.Abort();

    }
}

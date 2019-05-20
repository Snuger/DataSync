using DataSync.Api;
using DataSync.Model;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSync.ViewModel
{
    public class MainViewModel:Screen
    {

        private BindableCollection<DataCell> dataCells;

        public BindableCollection<DataCell> DataCells
        {
            get { return dataCells; }
            set
            {
                SetAndNotify(ref this.dataCells, value);
            }
        }
        private int currentNum;

        public MainViewModel()
        {
            this.CurrentNum = 0;
            this.DataCells = new BindableCollection<DataCell>();

            TaskThradManagement = new ThreadManagement(10);
            TaskThradManagement.UploadCompontentComplatedEvent += OnUploadCompontentComplatedEvent;
        }

        public int CurrentNum
        {
            get { return currentNum; }
            set
            {
                SetAndNotify(ref this.currentNum, value);
            }
        }

        public ThreadManagement TaskThradManagement { get; private set; }

        public void AddNewTaskComman() {
            CurrentNum = CurrentNum + 1;          
            DataCell dataCell=   new DataCell() { Id = this.CurrentNum, Name = "用户基本信息", Total = new Random().Next(1000, 10000), UploadedTotal = 0, BusinessDate = "2019-01-01", Complated = false };
            this.DataCells.Add(dataCell);
        }

        public void AllTaskStartCommand()
        {

            foreach (var item in this.DataCells)
            {
                if (item.Complated == false)
                {
                    UploadCompontent compontent = new UploadCompontent(item);
                    compontent.CompontentComplatedEvent += TaskThradManagement.OnCompontentComplated;
                    TaskThradManagement.Compontents.Add(compontent);
                    compontent.CreateCompontentWorkThrad();
                    compontent.Start();
                }
            }    
        }

        protected void OnUploadCompontentComplatedEvent(DataCell cell)
        {
            this.DataCells.Where(c => c.Id == cell.Id).FirstOrDefault().Complated = true;
            this.DataCells.Where(c => c.Id == cell.Id).FirstOrDefault().UploadedTotal = cell.UploadedTotal;
            this.DataCells.Refresh();
        }

    }
}

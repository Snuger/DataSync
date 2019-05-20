using System;
using System.Collections.Generic;
using DataSyncPro.Model;
using Stylet;

namespace DataSyncPro.Pages
{
    public class ShellViewModel : Screen
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

        public ShellViewModel()
        {
            this.CurrentNum = 0;
            this.DataCells = new BindableCollection<DataCell>();         
        }

        public int CurrentNum
        {
            get { return currentNum; }
            set
            {
                SetAndNotify(ref this.currentNum, value);
            }
        }


        public void AddNewTaskComman()
        {
            CurrentNum = CurrentNum + 1;
            List<DataCell> cells = new List<DataCell>();
            cells.Add( new DataCell() { Id = this.CurrentNum, Name = "用户基本信息", Total = new Random().Next(1000, 10000), UploadedTotal = new Random().Next(1000, 9000), BusinessDate = "2019-01-01", Complated = false });
            this.DataCells.AddRange(cells);
        }

    }
}

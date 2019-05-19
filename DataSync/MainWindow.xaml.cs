using DataSync.Api;
using DataSync.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataSync
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow 
    {

        public ThreadManagement TaskThradManagement { get; set; }

        List<DataCell> DataCells = new List<DataCell>();

        public int CurrentNum { get; set; } = 0;

        public MainWindow()
        {
            InitializeComponent();
            TaskThradManagement = new ThreadManagement(10);
            TaskThradManagement.UploadCompontentComplatedEvent += OnUploadCompontentComplatedEvent;
        }       

        private void Btn_add_task_Click(object sender, RoutedEventArgs e)
        {
            CurrentNum=CurrentNum+1;
            List<DataCell> dataCells = new List<DataCell>();
             dataCells.Add(new DataCell() { Id = this.CurrentNum, Name = "用户基本信息", Total=new Random().Next(1000,10000),UploadedTotal= 0, BusinessDate="2019-01-01",Complated=false });
             this.DataCells.AddRange(dataCells);
            this.grd_jobs.ItemsSource = this.DataCells.ToList();
        }

        private void Tlb_item_click(object sender, RoutedEventArgs e)
        {
            ToggleButton button = sender as ToggleButton;
            if (button.IsChecked==true)
            {
                DataCell cell = button.DataContext as DataCell;

                UploadCompontent compontent = new UploadCompontent(cell);
                compontent.CompontentComplatedEvent += TaskThradManagement.OnCompontentComplated;
                TaskThradManagement.Compontents.Add(compontent);
                compontent.CreateCompontentWorkThrad();
                compontent.Start();
            }
           
        }
      
        protected void OnUploadCompontentComplatedEvent(DataCell cell)
        {
            this.DataCells.Where(c => c.Id == cell.Id).FirstOrDefault().Complated = true;
            this.DataCells.Where(c => c.Id == cell.Id).FirstOrDefault().UploadedTotal = cell.UploadedTotal;            
        }

        private void On_btn_start_all_Click(object sender, RoutedEventArgs e)
        {
            this.DataCells.ForEach(c =>
            {
                if (c.Complated == false) { 
                UploadCompontent compontent = new UploadCompontent(c);
                compontent.CompontentComplatedEvent += TaskThradManagement.OnCompontentComplated;
                TaskThradManagement.Compontents.Add(compontent);
                compontent.CreateCompontentWorkThrad();
                compontent.Start();
                }
            });
        }
    }
}

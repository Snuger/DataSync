using DataSyncPro.Compontent;
using DataSyncPro.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataSyncPro.ViewModel
{
    public class AutomaticUploadViewModel : ViewModelBase
    {
        protected object LockObject = new object();


        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        protected DateTime BeginDate { get; set; } = new DateTime(2018, 1, 1);
        /// <summary>
        /// 最大的线程数
        /// </summary>
        protected int MaxThreadNum { get; set; } =1;

        /// <summary>
        /// 
        /// </summary>
        public ThreadManagement ThreadManagement { get; private set; }


        private readonly IDataService _dataService;

        /// <summary>
        /// 自动上传
        /// </summary>
        public ICommand AutomaticUploadCommand { get; set; }

        /// <summary>
        /// 启动所有线程
        /// </summary>
        public ICommand StatrtAllUploadThreadCommand { get; set; }


        private ObservableCollection<UploadEntity> uploadEnities;

        public AutomaticUploadViewModel(IDataService dataService)
        {
            _dataService = dataService;
            AutomaticUploadCommand = new RelayCommand(AutomaticUpload);

            this.ThreadManagement = new ThreadManagement(MaxThreadNum);
            this.ThreadManagement.UploadCompontentComplatedEvent += UploadCompontentComplated;
            AutomaticUploadCommand = new RelayCommand(AutomaticUpload);
            this.UploadEnities = new ObservableCollection<UploadEntity>();

            _dataService.GetUploadDataOptions(5, (item, error) =>
            {
                if (error != null)
                    return;
                this.UploadDataOptions = item;
            });
        }

        public ObservableCollection<UploadEntity> UploadEnities
        {
            get { return uploadEnities; }
            set { Set(ref uploadEnities, value); }
        }

        protected void AutomaticUpload()
        {
            if (isAutomatic)
            {
                return;
            }
            isAutomatic = true;
            AutomaticLoadingData();
            StatrtAllUploadThread();

        }


        private int workingThreadNum;

        /// <summary>
        /// 工作中的线程数
        /// </summary>
        public int WorkingThreadNUm
        {
            get { return workingThreadNum; }
            set { Set(ref workingThreadNum, value); }
        }


        private bool isAutomatic;

        /// <summary>
        /// 是否自动模式
        /// </summary>
        public bool IsAutomatic
        {
            get { return isAutomatic; }
            set { Set(ref isAutomatic, value); }
        }

        private IEnumerable<UploadDataOption> uploadDataOptions;

        /// <summary>
        ///待上传数据
        /// </summary>
        public IEnumerable<UploadDataOption> UploadDataOptions
        {
            get { return uploadDataOptions; }
            set { Set(ref uploadDataOptions, value); }
        }


        protected void AutomaticLoadingData()
        {
            if (IsAutomatic)
            {
                foreach (UploadDataOption option in UploadDataOptions)
                {
                    lock (LockObject)
                    {
                        option.Id = Id;
                        option.OperatingRange = BeginDate.ToString("yyyy-MM-dd");
                        _dataService.GetData(option, (item, error) =>
                        {
                            if (error != null)
                                return;
                            UploadEnities.Add(item.FirstOrDefault());
                        });
                        Id = Id + 1;
                    }
                }

            }
        }

        protected void StatrtAllUploadThread()
        {
            var query = this.UploadEnities.Where(c => c.IsComplated == false);
            if (query.Any())
            {

                foreach (var entity in query)
                {
                    if (workingThreadNum < MaxThreadNum)
                    {
                        UploadCompontent compontent = new UploadCompontent(entity);
                        compontent.UploadCompontentComplatedEvent += this.ThreadManagement.OnCompontentComplated;
                        compontent.CreateCompontentWorkThrad();
                        this.ThreadManagement.UploadCompontents.Add(compontent);
                        WorkingThreadNUm = WorkingThreadNUm + 1;
                    }
                    else
                    {
                        break;
                    }
                }
                this.ThreadManagement.StartAllThread();

            }

        }

        public void UploadCompontentComplated(UploadEntity entity)
        {

            lock (LockObject)
            {
                this.UploadEnities.Where(xc => xc.Id == entity.Id).FirstOrDefault().Uploaded = entity.Uploaded; 
                
                if (entity.Uploaded >= entity.Total)
                {
                    this.UploadEnities.Where(xc => xc.Id == entity.Id).FirstOrDefault().IsComplated = true;
                    workingThreadNum = workingThreadNum - 1;
                    if (isAutomatic)
                    {
                        Id = Id + 1;
                        UploadDataOption option = new UploadDataOption()
                        {
                            Id = Id,
                            IsComplated = false,
                            TableName = entity.TableName,
                            TableDiscription = entity.TableDiscription,
                            OperatingRange = DateTime.ParseExact(entity.ToString(), "yyyy-mm-dd", System.Globalization.CultureInfo.CurrentCulture).AddDays(1).ToString("yyyy-MM-dd")
                        };

                        _dataService.GetData(option, (item, error) =>
                        {
                            if (error != null)
                            {
                                UploadEnities.Add(item.FirstOrDefault());
                            }
                        });                        

                    }

                    StatrtAllUploadThread();
                }
              
            }
        }
    }
}

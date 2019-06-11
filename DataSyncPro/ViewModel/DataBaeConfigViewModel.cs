using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.ViewModel
{
    public class DataBaeConfigViewModel:ViewModelBase
    {

        private int _id;

        public int Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private string _dbtype;

        public string DbType
        {
            get { return _dbtype; }
            set { Set(ref _dbtype, value); }
        }

        private string _ip;

        public string Ip
        {
            get { return _ip; }
            set { Set(ref _ip, value); }
        }

        private int _port;

        public int Port
        {
            get { return _port; }
            set { Set(ref _port, value); }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { Set(ref _userName, value); }
        }

        private string _password;

        public string PassWord
        {
            get { return _password; }
            set { Set(ref _password, value); }
        }

        private string _intancename;

        public string InstanceName
        {
            get { return _intancename; }
            set { Set(ref _intancename, value); }
        }

        private bool _enable;

        public bool Enable
        {
            get { return _enable; }
            set { Set(ref _enable, value); }
        }
    }
}

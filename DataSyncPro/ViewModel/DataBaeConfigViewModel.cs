using DataSyncPro.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.ViewModel
{
    public class DataBaeConfigViewModel:ViewModelBase
    {

        public DataBaeConfigViewModel()
        {
            DataBaseTypes = new ObservableCollection<DataBaseType>() {
                 new DataBaseType(){ DatabseTypeId=1, DatabseTypeName="Oracle",DbPort=1521 },
                 new DataBaseType(){ DatabseTypeId=2, DatabseTypeName="MySql",DbPort=3306 },
                 new DataBaseType(){ DatabseTypeId=3, DatabseTypeName="PostgreSql",DbPort=5432 },
                 new DataBaseType(){ DatabseTypeId=4, DatabseTypeName="SqlServer",DbPort=1433 },
                 new DataBaseType(){ DatabseTypeId=5, DatabseTypeName="HiBase",DbPort=60000 },
                 new DataBaseType(){ DatabseTypeId=6, DatabseTypeName="MangoDB",DbPort=27107 }
            };
        }

        private DataBaseType selectDataBaseType;

        public DataBaseType SelectDataBaseType
        {
            get { return selectDataBaseType; }
            set {
                DataBaseType dataBaseType = ((DataBaseType)value);
                DbType = dataBaseType.DatabseTypeId;
                Port = dataBaseType.DbPort;
                Set(ref selectDataBaseType,value);
            }
        }

        private ObservableCollection<DataBaseType> dataBaseTypes;
       
        public ObservableCollection<DataBaseType> DataBaseTypes
        {
            get { return dataBaseTypes; }
            set { Set(ref dataBaseTypes, value); }
        }


        private int _id;

        public int Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        private int _dbtype;

        public int DbType
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

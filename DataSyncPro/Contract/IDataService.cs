using DataSyncPro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSyncPro
{
    public interface IDataService
    {
        void GetData(Action<IEnumerable<UploadEntity>, Exception> callback);


        void GetData(UploadDataOption option, Action<IEnumerable<UploadEntity>, Exception> callback);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        void GetUploadDataOptions(int MaxThreadNum,Action<IEnumerable<UploadDataOption>, Exception> callback);
    }
}

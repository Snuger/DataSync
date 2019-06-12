using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.Contract
{
    public interface IUpdateRepostry<T,in TKey> where T :class
    {
        Task<T> Add(Action<T, Exception> callBack);

        Task<T> Update(Action<T, Exception> callBack);

        Task<T> Delete(Action<T, Exception> callBack);

    }
}

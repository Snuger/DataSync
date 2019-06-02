﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSyncPro.Model
{
    /// <summary>
    /// 上传任务实例
    /// </summary>
    public class UploadEntity: UploadDataOption
    {       
        /// <summary>
        /// 总量
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 上传量
        /// </summary>
        public int Uploaded { get; set; }

        

    }
}

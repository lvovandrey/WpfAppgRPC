using GrpcService1;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
   public interface IGrpcDataSourceProvider:IDisposable
    {
        public DataSource.DataSourceClient GetDataSourceClient();
    }
}

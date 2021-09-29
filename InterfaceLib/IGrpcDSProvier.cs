using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLib
{
    public interface IGrpcDSProvier: IDisposable
        {
            public DataSource.DataSourceClient GetDataSourceClient();
        }
    }
}

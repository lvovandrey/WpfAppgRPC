using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcServiceDataSource
{
    public class DataSourceService : DataSource.DataSourceBase
    {
        private readonly ILogger<GreeterService> _logger;
        public DataSourceService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<DataReply> ReturnData(DataRequest request, ServerCallContext context)
        {
            return Task.FromResult(new DataReply
            {
                Data = "Data ---- 1 2 3 4"
            });
        }
    }
}

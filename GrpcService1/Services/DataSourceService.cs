using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService1
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
                Data = GetData(request.Id)
            });
        }

        private string GetData(int id)
        {
            using (DBCardContext db = new DBCardContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Cards.ToList();
                var user = users.Where(i => i.Id == id).FirstOrDefault();
                if (user == null) return "No data";
                return user.Id.ToString() + "   " + user.Name;
            }
        }
    }
}

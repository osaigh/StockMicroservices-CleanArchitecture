using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Infrastructure.Persistence
{
    public class DatabaseSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string AdminUser { get; set; } = null!;

        public string AdminPassword { get; set; } = null!;

        public string DbUser { get; set; } = null!;

        public string DbPassword { get; set; } = null!;

        public string Hostname { get; set; } = null!;
    }
}

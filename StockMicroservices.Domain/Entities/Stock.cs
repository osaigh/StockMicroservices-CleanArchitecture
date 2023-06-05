using StockMicroservices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Domain.Entities
{
    public class Stock : EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Volume { get; set; }
        public List<StockHistory> StockHistories { get; set; }
    }
}

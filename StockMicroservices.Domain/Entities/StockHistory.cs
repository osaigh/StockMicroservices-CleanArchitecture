using StockMicroservices.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Domain.Entities
{
    public class StockHistory : EntityBase
    {
        public string StockId { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Domain.Common
{
    public abstract class EntityBase
    {
        public string Id { get; set; }
    }
}

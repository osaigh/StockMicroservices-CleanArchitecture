using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOSTOCK = StockMicroservices.Domain.Entities.Stock;

namespace StockMicroservices.Domain.Repository
{
    public interface IStockRepository : IRepository<DAOSTOCK>
    {
    }
}

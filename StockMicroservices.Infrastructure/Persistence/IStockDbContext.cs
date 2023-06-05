using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = StockMicroservices.Domain.Entities;

namespace StockMicroservices.Infrastructure.Persistence
{
    public interface IStockDbContext
    {
        Task<List<Models.Stock>> GetStocksAsync();

        Task<Models.Stock?> GetStockByIdAsync(string id);
        
        Task<Models.Stock?> GetStockByNameAsync(string name);

        Task CreateStockAsync(Models.Stock stock);

        Task UpdateStockAsync(string id, Models.Stock stock);

        Task RemoveStockAsync(string id);

    }
}


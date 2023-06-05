using StockMicroservices.Domain.Repository;
using StockMicroservices.Infrastructure.Persistence;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        #region fields
        private readonly IStockDbContext _StockDbContext;
        #endregion

        #region Constructor
        public StockRepository(IStockDbContext stockDbContext)
        {
            _StockDbContext = stockDbContext;
        }
        #endregion

        #region IStockRepository
        public async Task<Domain.Entities.Stock> AddAsync(Domain.Entities.Stock entity)
        {
            await _StockDbContext.CreateStockAsync(entity);

            return entity;
        }

        public async Task DeleteAsync(Domain.Entities.Stock entity)
        {
            await _StockDbContext.RemoveStockAsync(entity.Id);
        }

        public async Task<IEnumerable<Domain.Entities.Stock>> GetAllAsync()
        {
            return await _StockDbContext.GetStocksAsync();
        }

        public async Task<Domain.Entities.Stock> GetAsync(object id)
        {
            return await _StockDbContext.GetStockByIdAsync(id.ToString());
        }

        public async Task<IEnumerable<Domain.Entities.Stock>> SearchForAsync(Expression<Func<Domain.Entities.Stock, bool>> predicate)
        {
            var stocks = await _StockDbContext.GetStocksAsync();
            return stocks.Where<Domain.Entities.Stock>(predicate.Compile());
        }

        public async Task<Domain.Entities.Stock> UpdateAsync(Domain.Entities.Stock entity)
        {
            await _StockDbContext.UpdateStockAsync(entity.Id, entity);

            return entity;
        }

        #endregion
    }
}

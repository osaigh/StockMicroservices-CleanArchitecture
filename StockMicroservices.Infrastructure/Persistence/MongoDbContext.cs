using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = StockMicroservices.Domain.Entities;

namespace StockMicroservices.Infrastructure.Persistence
{
    public class MongoDbContext : IStockDbContext
    {
        #region Properties
        private readonly IMongoCollection<Models.Stock> _stocksCollection;
        #endregion

        #region Constructor
        public MongoDbContext(IOptions<DatabaseSetting> databaseSettings)
        {
            string connectionString = string.Format("mongodb://{0}:{1}@{2}:27017/{3}", databaseSettings.Value.DbUser, databaseSettings.Value.DbPassword, databaseSettings.Value.Hostname, databaseSettings.Value.Name);

            var mongoClient = new MongoClient(connectionString);

            var stockDatabase = mongoClient.GetDatabase(databaseSettings.Value.Name);

            this._stocksCollection = stockDatabase.GetCollection<Models.Stock>("Stock");
        }
        #endregion

        #region Methods (CRUD)
        public async Task<List<Models.Stock>> GetStocksAsync() =>
            await _stocksCollection.Find(_ => true).ToListAsync();

        public async Task<Models.Stock?> GetStockByIdAsync(string id) =>
            await _stocksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Models.Stock?> GetStockByNameAsync(string name) =>
            await _stocksCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

        public async Task CreateStockAsync(Models.Stock stock) =>
            await _stocksCollection.InsertOneAsync(stock);

        public async Task UpdateStockAsync(string id, Models.Stock stock) =>
            await _stocksCollection.ReplaceOneAsync(x => x.Id == id, stock);

        public async Task RemoveStockAsync(string id) =>
            await _stocksCollection.DeleteOneAsync(x => x.Id == id);

        #endregion
    }
}

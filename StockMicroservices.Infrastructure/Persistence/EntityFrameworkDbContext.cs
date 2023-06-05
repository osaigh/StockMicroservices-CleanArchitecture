using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = StockMicroservices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockMicroservices.Infrastructure.Persistence
{
    public class EntityFrameworkDbContext : DbContext, IStockDbContext
    {
        #region Properties
        public DbSet<Models.Stock> Stocks { get; set; }
        public DbSet<Models.StockHistory> StockHistories { get; set; }

        #endregion

        #region Constructor
        public EntityFrameworkDbContext(DbContextOptions options) : base(options)
        {

        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Stock>()
                        .ToTable("Stock")
                        .HasKey(s => s.Id);

            modelBuilder.Entity<Models.StockHistory>()
                        .ToTable("StockHistory")
                        .HasKey(s => s.Id);

            modelBuilder.Entity<Models.StockHistory>()
                        .HasOne<Models.Stock>()
                        .WithMany(s => s.StockHistories)
                        .HasForeignKey(s => s.StockId);


        }

        #endregion

        #region IStockDbContext
        public async Task<List<Models.Stock>> GetStocksAsync()
        {
            return await this.Stocks.ToListAsync();
        }

        public async Task<Models.Stock?> GetStockByIdAsync(string id)
        {
            return await this.Stocks.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Models.Stock?> GetStockByNameAsync(string name)
        {
            return await this.Stocks.FirstOrDefaultAsync(s => s.Name == name);
        }

        public async Task CreateStockAsync(Models.Stock stock)
        {
            await this.Stocks.AddAsync(stock);
            await this.SaveChangesAsync();
        }

        public async Task UpdateStockAsync(string id, Models.Stock stock)
        {
            var stockDao = await this.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockDao != null)
            {
                stockDao.Price = stock.Price;
                stockDao.Volume = stock.Volume;
            }

            await this.SaveChangesAsync();
        }

        public async Task RemoveStockAsync(string id)
        {
            var stock = await this.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (stock != null)
            {
                this.Stocks.Remove(stock);
            }

            await this.SaveChangesAsync();
        }
        #endregion
    }
}

﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using StockMicroservices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Infrastructure.Persistence
{
    public class SeedData
    {
        private static List<Stock> GetStocks()
        {
            List<Stock> stocks = new List<Stock>();

            //Microsoft
            var microsoft = new Stock()
            {
                Id = (new ObjectId("e656bb6f9a358bcc3ae63c61")).ToString(),
                Name = "Microsoft",
                Price = 89,
                Volume = 2000,
                StockHistories = new List<StockHistory>()
                {
                    new StockHistory()
                    {
                        Price = 60,
                        Date = new DateTimeOffset(2020, 11, 30, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 62,
                        Date = new DateTimeOffset(2020, 12, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 69,
                        Date = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                     new StockHistory()
                    {
                        Price = 72,
                        Date = new DateTimeOffset(2021, 2, 27, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 80,
                        Date = new DateTimeOffset(2021, 3, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 89,
                        Date = new DateTimeOffset(2021, 4, 30, 0, 0, 0, TimeSpan.Zero)
                    }
                }
            };

            //Slim Stack
            var slimStack = new Stock()
            {
                Id = (new ObjectId("057340ee83ddedcbeef5b1ab")).ToString(),
                Name = "Slim Stack",
                Price = 23,
                Volume = 700,
                StockHistories = new List<StockHistory>()
                {
                    new StockHistory()
                    {
                         Price = 20,
                         Date = new DateTimeOffset(2020, 11, 30, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 26,
                        Date = new DateTimeOffset(2020, 12, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 33,
                        Date = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 29,
                        Date = new DateTimeOffset(2021, 2, 27, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 19,
                        Date = new DateTimeOffset(2021, 3, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 23,
                        Date = new DateTimeOffset(2024, 4, 30, 0, 0, 0, TimeSpan.Zero)
                    }
                }
            };

            //Apple
            var apple = new Stock()
            {
                Id = (new ObjectId("b8a9349f4c8ab79e0d4b2228")).ToString(),
                Name = "Apple",
                Price = 120,
                Volume = 2400,
                StockHistories = new List<StockHistory>()
                {
                     new StockHistory()
                     {
                         Price = 80,
                         Date = new DateTimeOffset(2020, 11, 30, 0, 0, 0, TimeSpan.Zero)
                     },
                    new StockHistory()
                    {
                        Price = 85,
                        Date = new DateTimeOffset(2020, 12, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 91,
                        Date = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 100,
                        Date = new DateTimeOffset(2021, 2, 27, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 110,
                        Date = new DateTimeOffset(2021, 3, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 150,
                        Date = new DateTimeOffset(2021, 4, 30, 0, 0, 0, TimeSpan.Zero)
                    }
                }
            };

            //Google
            var google = new Stock()
            {
                Id = (new ObjectId("f9fa93989154de3f9ffa5a90")).ToString(),
                Name = "Google",
                Price = 104,
                Volume = 2100,
                StockHistories = new List<StockHistory>()
                {
                    new StockHistory()
                    {
                        Price = 70,
                        Date = new DateTimeOffset(2020, 11, 30, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 76,
                        Date = new DateTimeOffset(2020, 12, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 82,
                        Date = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 93,
                        Date = new DateTimeOffset(2021, 2, 27, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 100,
                        Date = new DateTimeOffset(2021, 3, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 104,
                        Date = new DateTimeOffset(2021, 4, 30, 0, 0, 0, TimeSpan.Zero)
                    }
                }
            };

            //RedSpace
            var redSpace = new Stock()
            {
                Id = (new ObjectId("e0daaa97b6266f01d30b188f")).ToString(),
                Name = "Red Space",
                Price = 19,
                Volume = 560,
                StockHistories = new List<StockHistory>()
                {
                    new StockHistory()
                    {
                        Price = 9,
                        Date = new DateTimeOffset(2020, 11, 30, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 13,
                        Date = new DateTimeOffset(2020, 12, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 15,
                        Date = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 18,
                        Date = new DateTimeOffset(2021, 2, 27, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 23,
                        Date = new DateTimeOffset(2021, 3, 31, 0, 0, 0, TimeSpan.Zero)
                    },

                    new StockHistory()
                    {
                        Price = 19,
                        Date = new DateTimeOffset(2021, 4, 30, 0, 0, 0, TimeSpan.Zero)
                    }
                }
            };

            //Yahoo
            var yahoo = new Stock()
            {
                Id = (new ObjectId("c5b3d9f944262bfd890eb841")).ToString(),
                Name = "Yahoo",
                Price = 12,
                Volume = 300,
                StockHistories = new List<StockHistory>()
                {
                    new StockHistory()
                    {
                        Price = 79,
                        Date = new DateTimeOffset(2020, 11, 30, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 76,
                        Date = new DateTimeOffset(2020, 12, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 56,
                        Date = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 38,
                        Date = new DateTimeOffset(2021, 2, 27, 0, 0, 0, TimeSpan.Zero)
                    },

                    new StockHistory()
                    {

                        Price = 26,
                        Date = new DateTimeOffset(2021, 3, 31, 0, 0, 0, TimeSpan.Zero)
                    },

                    new StockHistory()
                    {
                        Price = 12,
                        Date = new DateTimeOffset(2021, 4, 30, 0, 0, 0, TimeSpan.Zero)
                    }
                }
            };

            //Alliance
            var alliance = new Stock()
            {
                Id = (new ObjectId("2ea3ea047cec3636122eefc3")).ToString(),
                Name = "Alliance",
                Price = 15,
                Volume = 690,
                StockHistories = new List<StockHistory>()
                {
                    new StockHistory()
                    {
                        Price = 14,
                        Date = new DateTimeOffset(2020, 11, 30, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 18,
                        Date = new DateTimeOffset(2020, 12, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 20,
                        Date = new DateTimeOffset(2021, 1, 31, 0, 0, 0, TimeSpan.Zero)
                    },
                    new StockHistory()
                    {
                        Price = 22,
                        Date = new DateTimeOffset(2021, 2, 27, 0, 0, 0, TimeSpan.Zero)
                    },

                    new StockHistory()
                    {
                        Price = 18,
                        Date = new DateTimeOffset(2021, 3, 31, 0, 0, 0, TimeSpan.Zero)
                    },

                    new StockHistory()
                    {
                        Price = 15,
                        Date = new DateTimeOffset(2021, 4, 30, 0, 0, 0, TimeSpan.Zero)
                    }
                }
            };

            stocks.Add(microsoft);
            stocks.Add(apple);
            stocks.Add(alliance);
            stocks.Add(google);
            stocks.Add(redSpace);
            stocks.Add(yahoo);

            return stocks;
        }

        public static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope())
            {
                Debug.WriteLine("Attempting seeding of Database");
                Console.WriteLine("Attempting seeding of Database");

                //Get database Settings
                var databaseSettings = serviceScope.ServiceProvider.GetRequiredService<IOptions<DatabaseSetting>>();

                //create db User
                try
                {
                    MongoCredential adminCred = MongoCredential.CreateCredential("admin", databaseSettings.Value.AdminUser, databaseSettings.Value.AdminPassword);
                    MongoClientSettings setting = new MongoClientSettings();
                    setting.Credential = adminCred;
                    setting.Server = new MongoServerAddress(databaseSettings.Value.Hostname, 27017);
                    var user = new BsonDocument { { "createUser", databaseSettings.Value.DbUser }, { "pwd", databaseSettings.Value.DbPassword }, { "roles", new BsonArray { new BsonDocument { { "role", "readWrite" }, { "db", databaseSettings.Value.Name } } } } };
                    new MongoClient(setting).GetDatabase(databaseSettings.Value.Name).RunCommand<BsonDocument>(user);


                    //get database using the DbUser created above
                    string connectionString = string.Format("mongodb://{0}:{1}@{2}:27017/{3}", databaseSettings.Value.DbUser, databaseSettings.Value.DbPassword, databaseSettings.Value.Hostname, databaseSettings.Value.Name);
                    var mongoClient = new MongoClient(connectionString);

                    var stocksDatabase = mongoClient.GetDatabase(databaseSettings.Value.Name);
                    var stocksCollection = stocksDatabase.GetCollection<Stock>("Stock");
                    
                    //Add sample stocks
                    foreach (var stock in GetStocks())
                    {
                        stocksCollection.InsertOneAsync(stock);
                    }

                    Debug.WriteLine("Database Seeding completed!");
                    Console.WriteLine("Database Seeding completed!");
                }
                catch (MongoCommandException me)
                {
                    //if user already exist
                    Debug.WriteLine(me.Message);
                    Console.WriteLine(me.Message);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }
    }
}

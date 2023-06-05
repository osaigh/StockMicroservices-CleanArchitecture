﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Abstractions.Models
{
    public class Stock
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Volume { get; set; }
        public List<StockHistory> StockHistories { get; set; }
    }
}

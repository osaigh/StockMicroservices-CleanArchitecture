using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOStock = StockMicroservices.Abstractions.Models.Stock;

namespace StockMicroservices.Application.Features.Stocks.Queries.GetStock
{
    public class GetStockQuery: IRequest<DTOStock>
    {
        public string Id { get; set; }
    }
}

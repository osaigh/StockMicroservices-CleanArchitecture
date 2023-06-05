using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOStock = StockMicroservices.Abstractions.Models.Stock;

namespace StockMicroservices.Application.Features.Stocks.Queries.GetStocks
{
    public class GetStockListQuery : IRequest<List<DTOStock>>
    {

    }
}

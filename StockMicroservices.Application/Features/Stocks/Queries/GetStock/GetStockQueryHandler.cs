using AutoMapper;
using MediatR;
using StockMicroservices.Application.Features.Stocks.Queries.GetStocks;
using StockMicroservices.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOStock = StockMicroservices.Abstractions.Models.Stock;

namespace StockMicroservices.Application.Features.Stocks.Queries.GetStock
{
    public class GetStockQueryHandler: IRequestHandler<GetStockQuery, DTOStock>
    {
        #region Fields
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetStockQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<DTOStock> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var stockDao = await _stockRepository.GetAsync(request.Id);

            return _mapper.Map<DTOStock>(stockDao);
        }
        #endregion
    }
}

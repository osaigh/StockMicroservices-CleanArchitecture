using AutoMapper;
using MediatR;
using StockMicroservices.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOStock = StockMicroservices.Abstractions.Models.Stock;

namespace StockMicroservices.Application.Features.Stocks.Queries.GetStocks
{
    public class GetStockListQueryHandler : IRequestHandler<GetStockListQuery, List<DTOStock>>
    {
        #region Fields
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetStockListQueryHandler(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<List<DTOStock>> Handle(GetStockListQuery request, CancellationToken cancellationToken)
        {
            var stockDaos = await _stockRepository.GetAllAsync();

            return _mapper.Map<List<DTOStock>>(stockDaos);
        }
        #endregion
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMicroservices.Application.Features.Stocks.Queries.GetStock;
using StockMicroservices.Application.Features.Stocks.Queries.GetStocks;
using StockMicroservices.Domain.Repository;
using System.Net;
using DTOStock = StockMicroservices.Abstractions.Models.Stock;

namespace StockMicroservices.API.Controllers.api
{
    [Authorize("StockAPIPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Constructor
        public StockController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region Methods
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DTOStock>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<DTOStock>>> Get()
        {
            var query = new GetStockListQuery();
            var dtoStocks = await _mediator.Send(query);
            return Ok(dtoStocks);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(DTOStock), (int)(HttpStatusCode.OK))]
        public async Task<ActionResult<DTOStock>> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new BadRequestObjectResult("id is null");
            }

            var query = new GetStockQuery()
            {
                Id = id
            };

            var dtoStock = await _mediator.Send(query);

            return Ok(dtoStock);
        }

        #endregion
    }
}

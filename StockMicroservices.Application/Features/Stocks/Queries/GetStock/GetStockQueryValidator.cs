using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMicroservices.Application.Features.Stocks.Queries.GetStock
{
    public class GetStockQueryValidator: AbstractValidator<GetStockQuery>
    {
        public GetStockQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotNull()
                .MinimumLength(1);
        }
    }
}

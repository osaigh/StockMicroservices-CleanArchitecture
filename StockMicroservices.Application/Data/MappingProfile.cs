using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOS = StockMicroservices.Domain.Entities;
using DTOs = StockMicroservices.Abstractions.Models;

namespace StockMicroservices.Application.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Stocks
            CreateMap<DAOS.Stock, DTOs.Stock>();
            CreateMap<DTOs.Stock, DAOS.Stock>();

            //StockHistory
            CreateMap<DAOS.StockHistory, DTOs.StockHistory>();
            CreateMap<DTOs.StockHistory, DAOS.StockHistory>();


        }
    }
}

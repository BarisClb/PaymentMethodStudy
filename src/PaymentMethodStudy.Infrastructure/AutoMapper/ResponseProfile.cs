using AutoMapper;
using PaymentMethodStudy.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentMethodStudy.Infrastructure.AutoMapper
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            // SortData
            CreateMap<SortingRequest, SortingResponse>().ReverseMap();
        }
    }
}

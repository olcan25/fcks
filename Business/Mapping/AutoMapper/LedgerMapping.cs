using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Concrete;
using Entity.Dto.Ledger;

namespace Business.Mapping.AutoMapper
{
    class LedgerMapping:Profile
    {
        public LedgerMapping()
        {
            CreateMap<LedgerDto, Ledger>().ReverseMap();
        }
    }
}

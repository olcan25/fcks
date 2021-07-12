using AutoMapper;
using Entity.Concrete;
using Entity.Dto.LedgerEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping.AutoMapper
{
    public class LedgerEntryMapping : Profile
    {
        public LedgerEntryMapping()
        {
            //CreateMap<LedgerEntryDebtCredit, LedgerEntry>()
            //    .ForMember(dest => dest.EntryType, opt =>
            //     {
            //         opt.PreCondition(x => x.Debt.Value > 0);
            //         opt.MapFrom(x => true);

            //     }).AfterMap((src, dest) => dest.EntryType = true)
            //    .ForMember(dest => dest.Amount, opt =>
            //    {
            //        opt.PreCondition(x => x.Credit > 0);
            //        opt.MapFrom(x => x.Credit);
            //    });
        }
    }
}

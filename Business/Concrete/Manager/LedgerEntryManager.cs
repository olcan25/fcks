using AutoMapper;
using Business.Abstract.Service;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto.LedgerEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Manager
{
    public class LedgerEntryManager : ILedgerEntryService
    {
        private readonly ILedgerEntryDal _ledgerEntryDal;
        private readonly IMapper _mapper;

        public LedgerEntryManager(ILedgerEntryDal ledgerEntryDal, IMapper mapper)
        {
            _ledgerEntryDal = ledgerEntryDal;
            _mapper = mapper;
        }
        public IResult Add(LedgerEntry ledgerEntry)
        {
            _ledgerEntryDal.Add(ledgerEntry);
            return new SuccessResult(Messages.Added);
        }

        public IResult AddBulk(List<LedgerEntry> ledgerEntries)
        {
            _ledgerEntryDal.BulkInsert(ledgerEntries);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(LedgerEntry ledgerEntry)
        {
            _ledgerEntryDal.Delete(ledgerEntry);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult DeleteBulk(List<LedgerEntry> ledgerEntries)
        {
            _ledgerEntryDal.BulkDelete(ledgerEntries);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<LedgerEntry>> GetAllByLedgerIdLedgerEntries(long ledgerId)
        {
            return new SuccessDataResult<List<LedgerEntry>>(_ledgerEntryDal.GetAll(x => x.LedgerId == ledgerId));
        }

        public IDataResult<List<LedgerAccountDto>> GetAllLedgerAccountsDtoList()
        {
            return new SuccessDataResult<List<LedgerAccountDto>>(_ledgerEntryDal.GetAllLedgerAccountsDto());
        }

        public IDataResult<List<LedgerAccountDto>> GetAllLedgerAccountsDtoList(DateTime startDate, DateTime endDate)
        {
            return new SuccessDataResult<List<LedgerAccountDto>>(_ledgerEntryDal.GetAllLedgerAccountsDto(x => x.RegisterDate >= startDate && x.RegisterDate <= endDate));
        }

        public IDataResult<List<LedgerEntry>> GetAllLedgerEntries()
        {
            return new SuccessDataResult<List<LedgerEntry>>(_ledgerEntryDal.GetAll());
        }

        public IDataResult<LedgerEntry> GetByIdLedgerEntry(int id)
        {
            return new SuccessDataResult<LedgerEntry>(_ledgerEntryDal.Get(x => x.Id == id));
        }

        public IResult Update(LedgerEntry ledgerEntry)
        {
            _ledgerEntryDal.Update(ledgerEntry);
            return new SuccessResult(Messages.Modified);
        }

        public IResult UpdateBulk(List<LedgerEntry> ledgerEntries)
        {
            _ledgerEntryDal.BulkSynchronize(ledgerEntries);
            return new SuccessResult(Messages.Modified);
        }
    }
}

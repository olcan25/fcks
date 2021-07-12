using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract.Service;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto.Warehouse;

namespace Business.Concrete.Manager
{
    public class WarehouseManager : IWarehousesService
    {
        private readonly IWarehousesDal _warehousesDal;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public WarehouseManager(IWarehousesDal warehousesDal, IAccountService accountService, IMapper mapper)
        {
            _warehousesDal = warehousesDal;
            _accountService = accountService;
            _mapper = mapper;
        }
        public IDataResult<List<DtoWarehouse>> GetAllDtoWarehouses()
        {
            return new SuccessDataResult<List<DtoWarehouse>>(_warehousesDal.GetAllDtoWarehouses());
        }

        public IDataResult<DtoWarehouse> GetByIdDtoWarehouse(int id)
        {
            return new SuccessDataResult<DtoWarehouse>(_warehousesDal.GetDtoWarehouse(x => x.Id == id));
        }

        public IDataResult<List<Warehouse>> GetComapnyIdWarehouses(short companyId)
        {
            return new SuccessDataResult<List<Warehouse>>(_warehousesDal.GetAll(x => x.CompanyId == companyId));
        }

        public IDataResult<Warehouse> DeleteForId(int id)
        {
            return new SuccessDataResult<Warehouse>(_warehousesDal.Get(x => x.Id == id));
        }

        [ValidationAspect(typeof(WarehouseValidator))]
        [TransactionScopeAspect]
        public IResult AddWarehouse(Warehouse warehouse)
        {
            IResult result = BusinessRules.Run(CheckIfWarehouseNameExists(warehouse.Name));
            if (result != null) return result;
            _warehousesDal.Add(warehouse);
            var account = _mapper.Map<Account>(warehouse);
            _accountService.Add(account);

            return new SuccessResult(Messages.Added);
        }

        [TransactionScopeAspect]
        public IResult DeleteWarehouse(Warehouse warehouse)
        {
            _warehousesDal.Delete(warehouse);
            var account = _mapper.Map<Account>(warehouse);
            _accountService.Delete(account);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(WarehouseValidator))]
        [TransactionScopeAspect]
        public IResult UpdateWarehouse(Warehouse warehouse)
        {
            _warehousesDal.Update(warehouse);
            var account = _mapper.Map<Account>(warehouse);
            _accountService.Update(account);
            return new SuccessResult(Messages.Modified);
        }


        //Business Rules Codes

        private IResult CheckIfWarehouseNameExists(string name)
        {
            var result = _warehousesDal.GetIsTrue(x => x.Name == name);
            return result
                ? (IResult)new ErrorResult("Bu Depo Ismi Zaten Var")
                : new SuccessResult();
        }
    }
}

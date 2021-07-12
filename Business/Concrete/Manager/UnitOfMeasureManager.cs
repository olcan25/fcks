using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete.Manager
{
    public class UnitOfMeasureManager : IUnitOfMeasureService
    {
        private readonly IUnitOfMeasureDal _unitOfMeasureDal;

        public UnitOfMeasureManager(IUnitOfMeasureDal unitOfMeasureDal)
        {
            _unitOfMeasureDal = unitOfMeasureDal;
        }


        public IDataResult<List<UnitOfMeasure>> GetAllUnitOfMeasures()
        {
            return new SuccessDataResult<List<UnitOfMeasure>>(_unitOfMeasureDal.GetAll());
        }

        public IDataResult<UnitOfMeasure> GetByIdUnitOfMeasure(short id)
        {
            return new SuccessDataResult<UnitOfMeasure>(_unitOfMeasureDal.Get(x => x.Id == id));
        }

        [ValidationAspect(typeof(UnitOfMeasureValidator))]
        public IResult AddUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            IResult result =
                BusinessRules.Run(CheckIfUnitOfMeasureNameExists(unitOfMeasure.Name),
                   CheckIfUnitOfMeasureShortNameExists(unitOfMeasure.ShortName));
            if (result != null) return result;
            
            _unitOfMeasureDal.Add(unitOfMeasure);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            _unitOfMeasureDal.Delete(unitOfMeasure);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(UnitOfMeasureValidator))]
        public IResult UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            _unitOfMeasureDal.Update(unitOfMeasure);
            return new SuccessResult(Messages.Modified);
        }



        //Business Rules Codes

        private IResult CheckIfUnitOfMeasureNameExists(string name)
        {
            var result = _unitOfMeasureDal.GetIsTrue(x => x.Name == name);
            return result
                ? (IResult)new ErrorResult("Bu Birim Ismi Zaten Var")
                : new SuccessResult();
        }

        private IResult CheckIfUnitOfMeasureShortNameExists(string shortName)
        {
            var result = _unitOfMeasureDal.GetIsTrue(x => x.ShortName == shortName);
            return result
                ? (IResult)new ErrorResult("Bu Birim Kisaltmasi Zaten Var")
                : new SuccessResult();
        }
    }
}

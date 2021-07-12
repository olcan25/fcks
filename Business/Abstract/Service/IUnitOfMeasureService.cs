using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
    public interface IUnitOfMeasureService
    {
        IDataResult<List<UnitOfMeasure>> GetAllUnitOfMeasures();
        IDataResult<UnitOfMeasure> GetByIdUnitOfMeasure(short id);
        IResult AddUnitOfMeasure(UnitOfMeasure unitOfMeasure);
        IResult DeleteUnitOfMeasure(UnitOfMeasure unitOfMeasure);
        IResult UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure);
    }
}

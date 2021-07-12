using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;
using Entity.Dto.Warehouse;

namespace Business.Abstract.Service
{
    public interface IWarehousesService
    {
        IDataResult<List<DtoWarehouse>> GetAllDtoWarehouses();
        IDataResult<DtoWarehouse> GetByIdDtoWarehouse(int id);
        IDataResult<List<Warehouse>> GetComapnyIdWarehouses(short companyId);
        IDataResult<Warehouse> DeleteForId(int id);
        IResult AddWarehouse(Warehouse warehouse);
        IResult DeleteWarehouse(Warehouse warehouse);
        IResult UpdateWarehouse(Warehouse warehouse);


        //IDataResult<List<DtoBranch>> GetAllBranchesDto();
        //IDataResult<DtoBranch> GetByIdBranchDto(short id);
        //IDataResult<Branch> GetByCompanyIdBranch(short id);
        //IDataResult<Branch> DeleteForId(short id);
        //IResult AddBranch(Branch branch);
        //IResult DeleteBranch(Branch branch);
        //IResult UpdateBranch(Branch branch);
    }
}

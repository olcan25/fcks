using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entity.Concrete;

namespace Business.Abstract.Service
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAllACategories();
        IDataResult<Category> GetByIdCategory(int id);
        IResult AddCategory(Category category);
        IResult DeleteCategory(Category category);
        IResult UpdateCategory(Category category);
    }
}

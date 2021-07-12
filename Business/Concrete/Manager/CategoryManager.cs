using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract.Service;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete.Manager
{
    //[SecuredOperation("admin")]
    [LogAspect(typeof(FileLogger))]
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        //[CacheAspect(1)]
        [PerformanceAspect(2)]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<List<Category>> GetAllACategories()
        {
           // Thread.Sleep(6000);
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        //[CacheAspect(10)]
        [PerformanceAspect(2)]//5 saniye demek
        public IDataResult<Category> GetByIdCategory(int id)
        {
            //Thread.Sleep(6000);
            return new SuccessDataResult<Category>(_categoryDal.Get(x => x.Id == id));
        }
        
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
    //    [SecuredOperation("admin,category.add")]
        public IResult AddCategory(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameExists(category.Name));
            if (result != null) return result;
            _categoryDal.Add(category);
            return new SuccessResult(Messages.Added);
        }

        public IResult DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Modified);
        }


        //Business Rules Codes

        private IResult CheckIfCategoryNameExists(string name)
        {
            var result = _categoryDal.GetIsTrue(x => x.Name == name);
            return result
                ? (IResult)new ErrorResult("Bu Kategori Ismi Zaten Var")
                : new SuccessResult();
        }
    }
}

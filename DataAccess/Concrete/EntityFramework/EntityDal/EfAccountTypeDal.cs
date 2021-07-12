﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EntityDal
{
    public class EfAccountTypeDal : EfEntityRepositoryBase<AccountType, InventoryManagementContext>, IAccountTypeDal
    {
    }
}

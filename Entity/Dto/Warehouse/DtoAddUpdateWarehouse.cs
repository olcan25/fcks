using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Dto.Warehouse
{
    public class DtoAddUpdateWarehouse :IDto
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
    }
}

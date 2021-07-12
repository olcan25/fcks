using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Warehouse
{
    public class GetDtoWarehouse : IDto
    {
        public byte Id { get; set; }
        public string BranchName { get; set; }
        public string Name { get; set; }
    }
}

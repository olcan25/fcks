using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Category
{
    public class DtoCategory : IDto
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

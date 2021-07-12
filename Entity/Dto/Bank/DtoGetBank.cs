using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Bank
{
    public class DtoGetBank : IDto
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;

namespace Entity.Dto.Vat
{
    public class GetDtoVat : IDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
    }
}

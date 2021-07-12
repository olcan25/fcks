using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DtoLinq
{
    public class DtoModel<T> : LinqModel where T : IDto
    {
        public T Data { get; set; }
    }
}

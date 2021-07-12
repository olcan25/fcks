using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DtoLinq
{
    public class ListDtoModel<T> : LinqModel where T : IDto
    {
        public ListDtoModel()
        {
            Data = new List<T>();
        }
        public List<T> Data { get; set; }
    }
}

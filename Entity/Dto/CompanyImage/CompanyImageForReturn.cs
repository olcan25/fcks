using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.CompanyImage
{
    public class CompanyImageForReturn
    {
        public int Id { get; set; }
        public short CompanyId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string PublicId { get; set; }
    }
}

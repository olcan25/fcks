using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.ViewModel
{
    public class CompanyModel
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string VatNumber { get; set; }
        public string UniqueIdentificationNumber { get; set; }
        public string Period { get; set; }
        // public Company Company { get; set; }
        public IFormFile File { get; set; }
    }
}

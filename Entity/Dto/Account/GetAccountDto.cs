using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Account
{
    public class GetAccountDto : IDto
    {
        public string Id { get; set; }
        public string AccountTypeName { get; set; }
        public string Name { get; set; }
        public string OfficialCode { get; set; }
        public string Description { get; set; }
    }
}

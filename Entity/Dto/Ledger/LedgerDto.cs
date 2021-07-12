using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Dto.Ledger
{
    public class LedgerDto
    {
        public long Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Description { get; set; }
    }
}

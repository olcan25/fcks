using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Account
{
    public class DtoConditionOfAccount : IDto
    {
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal? SumDebt { get; set; }
        public decimal? SumCredit { get; set; }
        public decimal? Balance { get; set; }
    }
}

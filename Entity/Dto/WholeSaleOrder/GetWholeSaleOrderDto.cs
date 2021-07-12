using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.WholeSaleOrder
{
    public class GetWholeSaleOrderDto
    {
        public long Id { get; set; }
        public long LedgerId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string PartnerName { get; set; }

        public int WholeSaleOrderNumber { get; set; }
        public string LedgerDescription { get; set; }
        public string WholeSaleOrderDescription { get; set; }
        public bool Foreign { get; set; }
        public bool IsPaid { get; set; } = false;

        public decimal? AmountVatValue { get; set; }
        public decimal? Amount { get; set; }

        public decimal? AmountWithVat { get; set; }
    }
}

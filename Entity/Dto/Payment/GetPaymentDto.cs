using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Dto.Payment
{
    public class GetPaymentDto : IDto
    {
        public long Id { get; set; }
        public long LedgerId { get; set; }
        public byte PaymentTypeId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string LedgerDescription { get; set; }
        public string PartnerName { get; set; }
        public string AccountName { get; set; }
        public string PaymentDescription { get; set; }
        public string Note { get; set; }
        public string PaymentType { get; set; }
        public decimal? Amount { get; set; }
    }
}

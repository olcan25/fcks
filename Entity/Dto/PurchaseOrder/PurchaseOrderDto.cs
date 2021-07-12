using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Abstract;

namespace Entity.Dto.PurchaseOrder
{
    public class PurchaseOrderDto
    {
        public int Id { get; set; }
        public long LedgerId { get; set; }
        public int PartnerId { get; set; }

        public int PurchaseOrderNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public bool IsPaid { get; set; }


    }
}

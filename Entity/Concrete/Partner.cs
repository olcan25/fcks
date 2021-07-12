using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Partner : BaseEntity, IEntity
    {
        public Partner()
        {
            PartnerBankAccounts = new HashSet<PartnerBankAccount>();
            WholeSaleOrders = new HashSet<WholeSaleOrder>();
            PartnerPurchaseOrders = new HashSet<PurchaseOrder>();
            TransporterPurchaseOrders = new HashSet<PurchaseOrder>();
            Payments = new HashSet<Payment>();
        }
        public long Id { get; set; }
        public byte PartnerTypeId { get; set; }
        public string Name { get; set; }
        public string UniqueIdentificationNumber { get; set; }
        public string VatNumber { get; set; }
        public string ContactName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string AdditionalInformation { get; set; }
        public byte[] Logo { get; set; }

        public PartnerType PartnerType { get; set; }


        public ICollection<PartnerBankAccount> PartnerBankAccounts { get; set; }
        public ICollection<PurchaseOrder> PartnerPurchaseOrders { get; set; }
        public ICollection<PurchaseOrder> TransporterPurchaseOrders { get; set; }
        public ICollection<WholeSaleOrder> WholeSaleOrders { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}

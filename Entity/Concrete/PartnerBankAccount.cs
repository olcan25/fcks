using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class PartnerBankAccount : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public long PartnerId { get; set; }
        public short BankId { get; set; }
        public string AccountNumber { get; set; }
        public string SwiftCode { get; set; }
        public string Iban { get; set; }

        public Bank Bank { get; set; }
        public Partner Partner { get; set; }
    }
}

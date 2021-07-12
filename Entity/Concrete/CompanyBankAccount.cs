using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class CompanyBankAccount : BaseEntity, IEntity
    {
        public short Id { get; set; }
        public short CompanyId { get; set; }
        public short BankId { get; set; }
        public string AccountNumber { get; set; }
        public string SwiftCode { get; set; }
        public string Iban { get; set; }

        public Bank Bank { get; set; }
        public Company Company { get; set; }
    }
}

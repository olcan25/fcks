using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Payment : BaseEntity, IEntity
    {
        public long Id { get; set; }
        public long LedgerId { get; set; }
        public long PartnerId { get; set; }
        public string AccountId { get; set; }
        public byte PaymentTypeId { get; set; }
        public short CurrencyId { get; set; }
        public decimal? CurrencyRate { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public decimal? Amount { get; set; }


        public PaymentType PaymentType { get; set; }
        public Ledger Ledger { get; set; }
        public Partner Partner { get; set; }
        public Account Account { get; set; }
        public Currency Currency { get; set; }
    }
}

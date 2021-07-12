using Core.Entity.Abstract;

namespace Entity.Dto.Partner
{
    public class DtoConditionOfPartner : IDto
    {
        public long PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string UniqueIdentificationNumber { get; set; }
        public string VatNumber { get; set; }
        public decimal? Debt { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
    }
}

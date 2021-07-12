using System.Collections.Generic;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Company : BaseEntity, IEntity
    {
        public Company()
        {
            Warehouses = new HashSet<Warehouse>();
            CompanyBankAccounts = new HashSet<CompanyBankAccount>();
        }
        public short Id { get; set; }
        public string Name { get; set; }
        public string UniqueIdentificationNumber { get; set; }
        public string VatNumber { get; set; }
        public short Period { get; set; }
        
        //Cloudinary Icin Resim
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }
        public ICollection<CompanyBankAccount> CompanyBankAccounts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WarehouseType>().HasData(new List<WarehouseType>
            {
                new WarehouseType
                {
                    Id=1,
                    Name = "Ticari Mallar Depolari",
                    Description= "",
                    Created=DateTime.Now,
                    Modified= DateTime.Now,
                    Status=true
                }
            });

            #region Types Product Payment Partner

            modelBuilder.Entity<PartnerType>().HasData(new List<PartnerType>
            {
                new PartnerType
                {
                    Id = 1, Name = "Yerel KDV'li Sirket", Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new PartnerType
                {
                    Id = 2, Name = "Yerel KDV'siz Sirket", Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new PartnerType
                {
                    Id = 3, Name = "KDV Muaf Sirket", Created = DateTime.Now,
                    Modified = DateTime.Now
                }
            });

            modelBuilder.Entity<ProductType>().HasData(new List<ProductType>
            {
                new ProductType
                {
                    Id = 1,
                    Name = "Ticari Mal",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Bitmis Urun",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new ProductType
                {
                    Id = 3,
                    Name = "Yari Mamul",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new ProductType
                {
                    Id = 4,
                    Name = "Ham Madde",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new ProductType
                {
                    Id = 5,
                    Name = "Hizmet",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new ProductType
                {
                    Id = 6,
                    Name = "Demirbas",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new ProductType
                {
                    Id = 7,
                    Name = "Gider",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                },
                new ProductType
                {
                    Id = 8,
                    Name = "Finans",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                }
            });

            modelBuilder.Entity<PaymentType>().HasData(new List<PaymentType>
            {
                new PaymentType {Id = 1, Name = "Alis", Created = DateTime.Now, Modified = DateTime.Now},
                new PaymentType {Id = 2, Name = "Satis", Created = DateTime.Now, Modified = DateTime.Now}
            });

            #endregion


            modelBuilder.Entity<Vat>().HasData(new List<Vat>
                {
                    new Vat
                    {
                        Id = 1,
                        Name = "TVSH 0",
                        Rate = 0,
                        Created = DateTime.Now,
                        Modified = DateTime.Now
                    },
                    new Vat
                    {
                        Id = 2,
                        Name = "TVSH %8",
                        Rate = 8,
                        Created = DateTime.Now,
                        Modified = DateTime.Now
                    },
                    new Vat
                    {
                        Id = 3,
                        Name = "TVSH %18",
                        Rate = 18,
                        Created = DateTime.Now,
                        Modified = DateTime.Now
                    }
                });

            modelBuilder.Entity<UnitOfMeasure>().HasData(new List<UnitOfMeasure>
            {
                new UnitOfMeasure
                {
                    Id = 1, Name = "Adet", ShortName = "Adet", Created = DateTime.Now, Modified = DateTime.Now
                },
                new UnitOfMeasure
                {
                    Id = 2, Name = "Kilogram", ShortName = "Kg", Created = DateTime.Now, Modified = DateTime.Now
                },
                new UnitOfMeasure
                {
                    Id = 3, Name = "Litre", ShortName = "L", Created = DateTime.Now, Modified = DateTime.Now
                }
            });

            modelBuilder.Entity<Bank>().HasData(new List<Bank>
                {
                    new Bank
                    {
                        Id = 1, Name = "TEB SH.A.", ShortName = "TEB Main", Created = DateTime.Now, Modified = DateTime.Now
                    },
                    new Bank
                    {
                        Id = 2, Name = "ProCredit Bank SH.A.", ShortName = "PCB Main", Created = DateTime.Now,
                        Modified = DateTime.Now
                    },
                    new Bank
                    {
                        Id = 3, Name = "Banka Për Biznes SH.A.", ShortName = "BpB Main", Created = DateTime.Now,
                        Modified = DateTime.Now
                    },
                    new Bank
                    {
                        Id = 4, Name = "Banka Ekonomike SH.A.", ShortName = "BEK Main", Created = DateTime.Now,
                        Modified = DateTime.Now
                    },
                    new Bank
                    {
                        Id = 5, Name = "Raiffeisen Bank Kosovo J.S.C. SH.A.", ShortName = "RBK Main", Created = DateTime.Now,
                        Modified = DateTime.Now
                    },
                    new Bank
                    {
                        Id = 6, Name = "Turkiye Cumhuriyeti Ziraat Bankasi A.S - Dega në Kosovë", ShortName = "ZBK Main",
                        Created = DateTime.Now, Modified = DateTime.Now
                    },
                    new Bank
                    {
                        Id = 7, Name = "TURKIYE IS BANKASI A.S. Dega në Kosovë", ShortName = "ISB Main",
                        Created = DateTime.Now, Modified = DateTime.Now
                    },
                    new Bank
                    {
                        Id = 8, Name = "Banka Kombëtare Tregtare Kosovë SH.A.", ShortName = "BKT Main",
                        Created = DateTime.Now, Modified = DateTime.Now
                    },
                    new Bank
                    {
                        Id = 9, Name = "NLB Banka SH.A.", ShortName = "NLB Main", Created = DateTime.Now,
                        Modified = DateTime.Now
                    },
                });

            modelBuilder.Entity<Currency>().HasData(new List<Currency>
            {
                new Currency{Id=1, Name="Euro", ShortName="EUR", Symbol="€", Created=DateTime.Now,Modified=DateTime.Now},
                new Currency{Id=2, Name="US Dollar", ShortName="USD", Symbol="$", Created=DateTime.Now,Modified=DateTime.Now},
                new Currency{ Id=3, Name="Albanian Lek",ShortName="LEK",Symbol="ALL", Created=DateTime.Now,Modified=DateTime.Now },
                new Currency{Id=4,Name="British Pound Sterling",ShortName="GBP", Symbol="£", Created=DateTime.Now,Modified=DateTime.Now},
                new Currency{ Id=5,Name="Turkish Lira",ShortName="TRY",Symbol="₺",Created=DateTime.Now,Modified=DateTime.Now}
            });
        }

    }
}

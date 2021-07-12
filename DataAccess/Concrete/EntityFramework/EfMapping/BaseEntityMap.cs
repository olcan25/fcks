using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.EfMapping
{
    public class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.Modified)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Created)
                .ValueGeneratedOnUpdate();
        }
    }
}
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredifyGaming.Infra.Mappings
{
    public abstract class BaseMapping<T> : IEntityTypeConfiguration<T> where T : class
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey("Id");
            builder.Property("Id").IsRequired().HasColumnName("Id");
        }
    }
}

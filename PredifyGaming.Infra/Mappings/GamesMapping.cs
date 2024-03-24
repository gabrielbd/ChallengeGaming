using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Infra.Mappings
{
    public class GamesMapping : BaseMapping<Games>
    {
        public override void Configure(EntityTypeBuilder<Games> builder)
        {
            base.Configure(builder);
            builder.HasKey(g => g.Id);
            builder.ToTable("Games");
            builder.Property(g => g.Name)
                .IsRequired()
                .HasColumnName("nome")
                .HasMaxLength(100);

            builder.Property(p => p.DateTimeCreate)
             .IsRequired()
             .HasColumnName("DataHoraCriacao")
             .ValueGeneratedOnAdd()
             .HasDefaultValueSql("GETUTCDATE()");

        }
    }
}

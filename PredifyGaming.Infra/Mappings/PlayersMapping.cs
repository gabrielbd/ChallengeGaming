using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Infra.Mappings
{
    public class PlayersMapping : BaseMapping<Players>
    {
        public override void Configure(EntityTypeBuilder<Players> builder)
        {
            base.Configure(builder);
            
            builder.HasKey(p => p.Id);
            
            builder.ToTable("Players");
            
            builder.Property(p => p.Name)
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

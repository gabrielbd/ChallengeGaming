using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PredifyGaming.Domain.Entities;


namespace PredifyGaming.Infra.Mappings
{
    public class PlaysResultMapping : BaseMapping<PlaysResult>
    {
        public override void Configure(EntityTypeBuilder<PlaysResult> builder)
        {
            base.Configure(builder);
            builder.HasKey(pr => pr.Id);
            builder.ToTable("ResultadoJogadas");

            builder.Property(pr => pr.PointsResult)
                .IsRequired();

            builder.HasOne(pr => pr.Players)
                .WithMany(p => p.PlaysResults)
                .HasForeignKey(pr => pr.PlayerId)
                .IsRequired();

            builder.HasOne(pr => pr.Games)
                .WithMany(g => g.PlaysResults)
                .HasForeignKey(pr => pr.GameId)
                .IsRequired();

            builder.Property(p => p.TimeStamp)
            .IsRequired()
            .HasColumnName("DataHoraJogada")
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETUTCDATE()");


        }
    }
}

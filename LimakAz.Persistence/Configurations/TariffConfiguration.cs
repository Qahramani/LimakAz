using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LimakAz.Persistence.Configurations;

internal class TariffConfiguration : IEntityTypeConfiguration<Tariff>
{
    public void Configure(EntityTypeBuilder<Tariff> builder)
    {
        builder.Property(x => x.MinValue).HasColumnType("decimal(6,3)");
        builder.Property(x => x.MaxValue).HasColumnType("decimal(6,3)");
        builder.Property(x => x.Price).HasColumnType("decimal(10,3)");
    }
}

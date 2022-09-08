using static Domain.Entities.Product;

namespace Infrastructure.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => new { p.Id });

        builder.ToTable("Product");

        builder.Property(s => s.Name)
            .HasMaxLength(100);

        builder.Property(p => p.Type)
            .HasMaxLength(20)
            .HasConversion(
            v => v.ToString(),
            v => (TariffType)Enum.Parse(typeof(TariffType), v));

        builder.Property(p => p.BaseCost)
            .HasColumnType("decimal(7,2)");

        builder.Property(p => p.CostPerKWh)
            .HasColumnType("decimal(7,2)");
    }
}

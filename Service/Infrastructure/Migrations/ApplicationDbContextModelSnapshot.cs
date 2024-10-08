﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Service.Infrastructure.Persistence;

#nullable disable

namespace Service.Infrastructure.Migrations
{
	[DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Cost", "Cost", b1 =>
                        {
                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<int>("AllowedConsumption")
                                .HasColumnType("int")
                                .HasColumnName("AllowedConsumption");

                            b1.Property<decimal>("BaseCost")
                                .HasColumnType("decimal(7,2)")
                                .HasColumnName("BaseCost");

                            b1.Property<decimal>("CostPerKWh")
                                .HasColumnType("decimal(7,2)")
                                .HasColumnName("CostPerKWh");

                            b1.Property<string>("TariffType")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("nvarchar(20)")
                                .HasColumnName("TariffType");

                            b1.HasKey("ProductId");

                            b1.ToTable("Product");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Cost");
                });
#pragma warning restore 612, 618
        }
    }
}

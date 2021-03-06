// <auto-generated />
using System;
using CEABS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CEABS.Infrastructure.Migrations
{
    [DbContext(typeof(CeabsContext))]
    partial class CeabsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CEABS.Domain.Entities.ModelCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ModelCars");
                });

            modelBuilder.Entity("CEABS.Domain.Entities.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("CEABS.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ModelCarId")
                        .HasColumnType("integer");

                    b.Property<string>("Plate")
                        .HasColumnType("text");

                    b.Property<int>("ProducerId")
                        .HasColumnType("integer");

                    b.Property<int>("YearFabrication")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModelCarId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CEABS.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("CEABS.Domain.Entities.ModelCar", "ModelCar")
                        .WithMany()
                        .HasForeignKey("ModelCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CEABS.Domain.Entities.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelCar");

                    b.Navigation("Producer");
                });
#pragma warning restore 612, 618
        }
    }
}

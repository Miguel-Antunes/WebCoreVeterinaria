﻿// <auto-generated />
using System;
using ClinicaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicaVeterinaria.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicaVeterinaria.Models.Dominio.Animal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cpfProp")
                        .HasColumnType("Int");

                    b.Property<string>("especieAnimal")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("nascimentoProp")
                        .HasColumnType("datetime2");

                    b.Property<string>("nomeAnimal")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("nomeProp")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<double>("pesoAnimal")
                        .HasColumnType("float");

                    b.Property<string>("racaAnimal")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("id");

                    b.HasIndex("cpfProp")
                        .IsUnique();

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Dominio.Procedimento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("dataProcedimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("descricaoVacinaid")
                        .HasColumnType("int");

                    b.Property<int>("idAnimal")
                        .HasColumnType("int");

                    b.Property<int>("idVacina")
                        .HasColumnType("int");

                    b.Property<int>("idVeterinario")
                        .HasColumnType("int");

                    b.Property<int?>("nomeVeterinarioid")
                        .HasColumnType("int");

                    b.Property<string>("procedimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("queixa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("statusDor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("statusEstado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("statusFebre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("descricaoVacinaid");

                    b.HasIndex("idAnimal");

                    b.HasIndex("nomeVeterinarioid");

                    b.ToTable("Procedimentos");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Dominio.Vacina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricaoVacina")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("fabricacaoVacina")
                        .HasColumnType("datetime2");

                    b.Property<string>("fabricanteVacina")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTime>("validadeVacina")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Vacina");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Dominio.Veterinario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cidadeVeterinario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cpfVeterinario")
                        .HasColumnType("int");

                    b.Property<string>("enderecoVeterinario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nascimentoVeterinario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomeVeterinario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefoneVeterinario")
                        .HasColumnType("int");

                    b.Property<string>("ufVeterinario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Dominio.Procedimento", b =>
                {
                    b.HasOne("ClinicaVeterinaria.Models.Dominio.Vacina", "descricaoVacina")
                        .WithMany("Procedimentos")
                        .HasForeignKey("descricaoVacinaid");

                    b.HasOne("ClinicaVeterinaria.Models.Dominio.Animal", "nomeAnimal")
                        .WithMany("Procedimentos")
                        .HasForeignKey("idAnimal")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.Models.Dominio.Veterinario", "nomeVeterinario")
                        .WithMany("Procedimentos")
                        .HasForeignKey("nomeVeterinarioid");

                    b.Navigation("descricaoVacina");

                    b.Navigation("nomeAnimal");

                    b.Navigation("nomeVeterinario");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Dominio.Animal", b =>
                {
                    b.Navigation("Procedimentos");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Dominio.Vacina", b =>
                {
                    b.Navigation("Procedimentos");
                });

            modelBuilder.Entity("ClinicaVeterinaria.Models.Dominio.Veterinario", b =>
                {
                    b.Navigation("Procedimentos");
                });
#pragma warning restore 612, 618
        }
    }
}

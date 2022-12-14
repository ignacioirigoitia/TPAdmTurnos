// <auto-generated />
using System;
using MVCBasico.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCBasico.Migrations
{
    [DbContext(typeof(AdmTurnosDatabaseContext))]
    [Migration("20221117233349_MVCBasico.Context.AdmTurnosDatabaseContext")]
    partial class MVCBasicoContextAdmTurnosDatabaseContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCBasico.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<int?>("TurneraIdTurnera")
                        .HasColumnType("int");

                    b.HasKey("IdCliente");

                    b.HasIndex("TurneraIdTurnera");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MVCBasico.Models.Turnera", b =>
                {
                    b.Property<int>("IdTurnera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTurnera");

                    b.ToTable("Turneras");
                });

            modelBuilder.Entity("MVCBasico.Models.Turno", b =>
                {
                    b.Property<int>("IdTurno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaTurno")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdTurnera")
                        .HasColumnType("int");

                    b.Property<int?>("TurneraIdTurnera")
                        .HasColumnType("int");

                    b.HasKey("IdTurno");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("TurneraIdTurnera");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("MVCBasico.Models.Cliente", b =>
                {
                    b.HasOne("MVCBasico.Models.Turnera", null)
                        .WithMany("clientes")
                        .HasForeignKey("TurneraIdTurnera");
                });

            modelBuilder.Entity("MVCBasico.Models.Turno", b =>
                {
                    b.HasOne("MVCBasico.Models.Cliente", "Cliente")
                        .WithMany("historialTurnos")
                        .HasForeignKey("ClienteIdCliente");

                    b.HasOne("MVCBasico.Models.Turnera", "Turnera")
                        .WithMany("turnos")
                        .HasForeignKey("TurneraIdTurnera");
                });
#pragma warning restore 612, 618
        }
    }
}

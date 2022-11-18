using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBasico.Migrations
{
    public partial class MVCBasicoContextAdmTurnosDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turneras",
                columns: table => new
                {
                    IdTurnera = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turneras", x => x.IdTurnera);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Saldo = table.Column<double>(nullable: false),
                    TurneraIdTurnera = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Turneras_TurneraIdTurnera",
                        column: x => x.TurneraIdTurnera,
                        principalTable: "Turneras",
                        principalColumn: "IdTurnera",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    IdTurno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: true),
                    ClienteIdCliente = table.Column<int>(nullable: true),
                    IdTurnera = table.Column<int>(nullable: true),
                    TurneraIdTurnera = table.Column<int>(nullable: true),
                    FechaTurno = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.IdTurno);
                    table.ForeignKey(
                        name: "FK_Turnos_Clientes_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Turneras_TurneraIdTurnera",
                        column: x => x.TurneraIdTurnera,
                        principalTable: "Turneras",
                        principalColumn: "IdTurnera",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TurneraIdTurnera",
                table: "Clientes",
                column: "TurneraIdTurnera");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ClienteIdCliente",
                table: "Turnos",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_TurneraIdTurnera",
                table: "Turnos",
                column: "TurneraIdTurnera");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Turneras");
        }
    }
}

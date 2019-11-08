using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QDCeValutazioni.DA.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Qdcs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CognomeFormatore = table.Column<string>(nullable: true),
                    CognomePerito = table.Column<string>(nullable: true),
                    DataConsegna = table.Column<DateTime>(nullable: true),
                    DataInizio = table.Column<DateTime>(nullable: true),
                    Descrizione = table.Column<string>(nullable: true),
                    MailFormatore = table.Column<string>(nullable: true),
                    MailPerito = table.Column<string>(nullable: true),
                    NomeFormatore = table.Column<string>(nullable: true),
                    NomePerito = table.Column<string>(nullable: true),
                    NumeroOre = table.Column<int>(nullable: true),
                    OraFine = table.Column<DateTime>(nullable: true),
                    OraInizio = table.Column<DateTime>(nullable: true),
                    Titolo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qdcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requisiti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descrizione = table.Column<string>(nullable: true),
                    Titolo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisiti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assegnazioni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codice = table.Column<int>(nullable: false),
                    Motivazione = table.Column<string>(nullable: true),
                    QdcId = table.Column<int>(nullable: true),
                    RequisitoId = table.Column<int>(nullable: true),
                    Voto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assegnazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assegnazioni_Qdcs_QdcId",
                        column: x => x.QdcId,
                        principalTable: "Qdcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assegnazioni_Requisiti_RequisitoId",
                        column: x => x.RequisitoId,
                        principalTable: "Requisiti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assegnazioni_QdcId",
                table: "Assegnazioni",
                column: "QdcId");

            migrationBuilder.CreateIndex(
                name: "IX_Assegnazioni_RequisitoId",
                table: "Assegnazioni",
                column: "RequisitoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assegnazioni");

            migrationBuilder.DropTable(
                name: "Qdcs");

            migrationBuilder.DropTable(
                name: "Requisiti");
        }
    }
}

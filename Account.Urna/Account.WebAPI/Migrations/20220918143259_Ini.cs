using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.WebAPI.Migrations
{
    public partial class Ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidato",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome_completo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    nome_vice = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    data_registro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    legenda = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidato_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "voto",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    id_candidato = table.Column<int>(type: "INTEGER", nullable: true),
                    data_voto = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voto_id", x => x.id);
                    table.ForeignKey(
                        name: "FK_voto_candidato_id_candidato",
                        column: x => x.id_candidato,
                        principalTable: "candidato",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_voto_id_candidato",
                table: "voto",
                column: "id_candidato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "voto");

            migrationBuilder.DropTable(
                name: "candidato");
        }
    }
}

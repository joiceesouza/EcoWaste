using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoWaste.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelasIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PONTO_COLETA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ENDERECO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CIDADE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PONTO_COLETA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESIDUO",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TIPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PONTOCOLETAID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESIDUO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RESIDUO_PONTO_COLETA_PONTOCOLETAID",
                        column: x => x.PONTOCOLETAID,
                        principalTable: "PONTO_COLETA",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "COLETA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RESIDUO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    USUARIO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    QUANTIDADE_KG = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DATA_HORA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLETA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COLETA_RESIDUO_RESIDUO_ID",
                        column: x => x.RESIDUO_ID,
                        principalTable: "RESIDUO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PONTO_COLETA_RESIDUO",
                columns: table => new
                {
                    PONTO_COLETA_ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RESIDUO_ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PONTO_COLETA_RESIDUO", x => new { x.PONTO_COLETA_ID, x.RESIDUO_ID });
                    table.ForeignKey(
                        name: "FK_PONTOCOLETA_RESIDUO_PONTOCOLETA",
                        column: x => x.PONTO_COLETA_ID,
                        principalTable: "PONTO_COLETA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PONTOCOLETA_RESIDUO_RESIDUO",
                        column: x => x.RESIDUO_ID,
                        principalTable: "RESIDUO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COLETA_RESIDUO_ID",
                table: "COLETA",
                column: "RESIDUO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PONTO_COLETA_RESIDUO_RESIDUO_ID",
                table: "PONTO_COLETA_RESIDUO",
                column: "RESIDUO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESIDUO_PONTOCOLETAID",
                table: "RESIDUO",
                column: "PONTOCOLETAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COLETA");

            migrationBuilder.DropTable(
                name: "PONTO_COLETA_RESIDUO");

            migrationBuilder.DropTable(
                name: "RESIDUO");

            migrationBuilder.DropTable(
                name: "PONTO_COLETA");
        }
    }
}

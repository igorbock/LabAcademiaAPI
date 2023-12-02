using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LabAcademiaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "academia");

            migrationBuilder.CreateTable(
                name: "Historicos",
                schema: "academia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Treino = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treinos",
                schema: "academia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<char>(type: "character(1)", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                schema: "academia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Series = table.Column<int>(type: "integer", nullable: true),
                    Repeticao = table.Column<int>(type: "integer", nullable: true),
                    Tempo = table.Column<double>(type: "double precision", nullable: true),
                    Carga = table.Column<double>(type: "double precision", nullable: true),
                    Concluido = table.Column<bool>(type: "boolean", nullable: true),
                    CodigoTreino = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Treinos_CodigoTreino",
                        column: x => x.CodigoTreino,
                        principalSchema: "academia",
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosTreinos",
                schema: "academia",
                columns: table => new
                {
                    CodigoUsuario = table.Column<int>(type: "integer", nullable: false),
                    CodigoTreino = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_UsuariosTreinos_Treinos_CodigoTreino",
                        column: x => x.CodigoTreino,
                        principalSchema: "academia",
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_CodigoTreino",
                schema: "academia",
                table: "Exercicios",
                column: "CodigoTreino");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosTreinos_CodigoTreino",
                schema: "academia",
                table: "UsuariosTreinos",
                column: "CodigoTreino");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercicios",
                schema: "academia");

            migrationBuilder.DropTable(
                name: "Historicos",
                schema: "academia");

            migrationBuilder.DropTable(
                name: "UsuariosTreinos",
                schema: "academia");

            migrationBuilder.DropTable(
                name: "Treinos",
                schema: "academia");
        }
    }
}

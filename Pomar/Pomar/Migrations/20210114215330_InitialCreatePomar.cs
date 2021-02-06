using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pomar.Migrations
{
    public partial class InitialCreatePomar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bdPomar");

            migrationBuilder.CreateTable(
                name: "tb_colheita",
                schema: "bdPomar",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Informacoes = table.Column<string>(nullable: false),
                    DataColheita = table.Column<DateTime>(nullable: false),
                    PesoBruto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Colheita", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "tb_especie",
                schema: "bdPomar",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Especie", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "tb_grupoarvore",
                schema: "bdPomar",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Grupoarvore", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                schema: "bdPomar",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Cargo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_User", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "tb_arvore",
                schema: "bdPomar",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: false),
                    DataPlantio = table.Column<DateTime>(nullable: false),
                    EspecieId = table.Column<int>(nullable: false),
                    GrupoArvoreId = table.Column<int>(nullable: false),
                    Idade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Arvore", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_tb_arvore_tb_especie_EspecieId",
                        column: x => x.EspecieId,
                        principalSchema: "bdPomar",
                        principalTable: "tb_especie",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_arvore_tb_grupoarvore_GrupoArvoreId",
                        column: x => x.GrupoArvoreId,
                        principalSchema: "bdPomar",
                        principalTable: "tb_grupoarvore",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_colheitaarvore",
                schema: "bdPomar",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColheitaId = table.Column<int>(nullable: false),
                    ArvoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_ColheitaArvore", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_tb_colheitaarvore_tb_arvore_ArvoreId",
                        column: x => x.ArvoreId,
                        principalSchema: "bdPomar",
                        principalTable: "tb_arvore",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_colheitaarvore_tb_colheita_ColheitaId",
                        column: x => x.ColheitaId,
                        principalSchema: "bdPomar",
                        principalTable: "tb_colheita",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_arvore_EspecieId",
                schema: "bdPomar",
                table: "tb_arvore",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_arvore_GrupoArvoreId",
                schema: "bdPomar",
                table: "tb_arvore",
                column: "GrupoArvoreId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_colheitaarvore_ArvoreId",
                schema: "bdPomar",
                table: "tb_colheitaarvore",
                column: "ArvoreId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_colheitaarvore_ColheitaId",
                schema: "bdPomar",
                table: "tb_colheitaarvore",
                column: "ColheitaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_Usuario",
                schema: "bdPomar",
                table: "tb_user",
                column: "Usuario",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_colheitaarvore",
                schema: "bdPomar");

            migrationBuilder.DropTable(
                name: "tb_user",
                schema: "bdPomar");

            migrationBuilder.DropTable(
                name: "tb_arvore",
                schema: "bdPomar");

            migrationBuilder.DropTable(
                name: "tb_colheita",
                schema: "bdPomar");

            migrationBuilder.DropTable(
                name: "tb_especie",
                schema: "bdPomar");

            migrationBuilder.DropTable(
                name: "tb_grupoarvore",
                schema: "bdPomar");
        }
    }
}

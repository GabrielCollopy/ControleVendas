using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleVendas.Migrations
{
    /// <inheritdoc />
    public partial class Versao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensVenda");

            migrationBuilder.AddColumn<int>(
                name: "produtoId",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantidade",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_produtoId",
                table: "Vendas",
                column: "produtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_produtoId",
                table: "Vendas",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_produtoId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_produtoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "produtoId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "Vendas");

            migrationBuilder.CreateTable(
                name: "ItensVenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produtoId = table.Column<int>(type: "int", nullable: false),
                    vendaId = table.Column<int>(type: "int", nullable: false),
                    precoUnitario = table.Column<double>(type: "float", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensVenda_Vendas_vendaId",
                        column: x => x.vendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_produtoId",
                table: "ItensVenda",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVenda_vendaId",
                table: "ItensVenda",
                column: "vendaId");
        }
    }
}

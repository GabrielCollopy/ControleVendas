using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleVendas.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Produtos_produtoId",
                table: "ItemVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemVenda_Vendas_vendaId",
                table: "ItemVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda");

            migrationBuilder.RenameTable(
                name: "ItemVenda",
                newName: "ItensVenda");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVenda_vendaId",
                table: "ItensVenda",
                newName: "IX_ItensVenda_vendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemVenda_produtoId",
                table: "ItensVenda",
                newName: "IX_ItensVenda_produtoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensVenda",
                table: "ItensVenda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_Produtos_produtoId",
                table: "ItensVenda",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensVenda_Vendas_vendaId",
                table: "ItensVenda",
                column: "vendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_Produtos_produtoId",
                table: "ItensVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensVenda_Vendas_vendaId",
                table: "ItensVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensVenda",
                table: "ItensVenda");

            migrationBuilder.RenameTable(
                name: "ItensVenda",
                newName: "ItemVenda");

            migrationBuilder.RenameIndex(
                name: "IX_ItensVenda_vendaId",
                table: "ItemVenda",
                newName: "IX_ItemVenda_vendaId");

            migrationBuilder.RenameIndex(
                name: "IX_ItensVenda_produtoId",
                table: "ItemVenda",
                newName: "IX_ItemVenda_produtoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemVenda",
                table: "ItemVenda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Produtos_produtoId",
                table: "ItemVenda",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemVenda_Vendas_vendaId",
                table: "ItemVenda",
                column: "vendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

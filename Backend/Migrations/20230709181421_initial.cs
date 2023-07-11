using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    razaoSocial = table.Column<string>(type: "TEXT", nullable: false),
                    cnpj = table.Column<string>(type: "TEXT", nullable: false),
                    uf = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    contato = table.Column<string>(type: "TEXT", nullable: false),
                    nomeContato = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    codigoPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dataPedido = table.Column<string>(type: "TEXT", nullable: false),
                    produtoId = table.Column<int>(type: "INTEGER", nullable: false),
                    quantidadeProdutos = table.Column<int>(type: "INTEGER", nullable: false),
                    fornecedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    valorTotalPedido = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.codigoPedido);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    produtoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    codigo = table.Column<int>(type: "INTEGER", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    dataCadastro = table.Column<string>(type: "TEXT", nullable: false),
                    valorProduto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.produtoId);
                });

            migrationBuilder.CreateTable(
                name: "FornecedorPedido",
                columns: table => new
                {
                    fornecedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    pedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorPedido", x => new { x.fornecedorId, x.pedidoId });
                    table.ForeignKey(
                        name: "FK_FornecedorPedido_Fornecedor_fornecedorId",
                        column: x => x.fornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FornecedorPedido_Pedido_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "Pedido",
                        principalColumn: "codigoPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Fornecedor",
                columns: new[] { "Id", "cnpj", "contato", "email", "nomeContato", "razaoSocial", "uf" },
                values: new object[,]
                {
                    { 1, "1200005555555555", "33888888888", "helio@gmail", "Helio", "Pre Moldados Janauba", "MG" },
                    { 2, "88888555555555555", "885555555555", "maicon@gmail", "Maicon", "MagnoOn Digital", "MG" }
                });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "codigoPedido", "dataPedido", "fornecedorId", "produtoId", "quantidadeProdutos", "valorTotalPedido" },
                values: new object[,]
                {
                    { 1, "08/07/2023", 1, 1, 5000, 15000 },
                    { 2, "08/07/2023", 2, 2, 50, 15000 },
                    { 3, "08/07/2023", 1, 1, 1000, 3000 },
                    { 4, "08/07/2023", 2, 2, 30, 9000 },
                    { 5, "08/07/2023", 1, 1, 10000, 30000 },
                    { 6, "08/07/2023", 2, 2, 10, 3000 }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "produtoId", "codigo", "dataCadastro", "descricao", "valorProduto" },
                values: new object[,]
                {
                    { 1, 5, "01/04/2023", "blocos", 3 },
                    { 2, 10, "30/09/2022", "artes digitais", 300 }
                });

            migrationBuilder.InsertData(
                table: "FornecedorPedido",
                columns: new[] { "fornecedorId", "pedidoId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 5 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorPedido_pedidoId",
                table: "FornecedorPedido",
                column: "pedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FornecedorPedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}

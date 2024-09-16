using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetOrderAI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaItemPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    quantidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    preco = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    recomendacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaItemPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    num_cartao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nome_cartao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_validade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cvv = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    apelido_cartao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ValorTotal = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    FreteEntrega = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    DataPedido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataEntrega = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dataCadastro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dataNascimento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    sexo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaUsuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaItemPedido");

            migrationBuilder.DropTable(
                name: "TabelaPagamento");

            migrationBuilder.DropTable(
                name: "TabelaPedido");

            migrationBuilder.DropTable(
                name: "TabelaUsuario");
        }
    }
}

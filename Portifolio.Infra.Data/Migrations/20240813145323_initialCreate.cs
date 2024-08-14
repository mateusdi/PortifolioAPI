using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portifolio.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projeto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    pessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projeto", x => x.id);
                    table.ForeignKey(
                        name: "FK_projeto_pessoa_pessoaId",
                        column: x => x.pessoaId,
                        principalTable: "pessoa",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: false),
                    pessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_pessoa_pessoaId",
                        column: x => x.pessoaId,
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_email",
                table: "pessoa",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_projeto_pessoaId",
                table: "projeto",
                column: "pessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_login",
                table: "usuario",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_pessoaId",
                table: "usuario",
                column: "pessoaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projeto");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartRecruiters.Api.Infra.Migrations
{
    public partial class initialDatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credito",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    numero_credito = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    numero_nfse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    data_constituicao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    valor_nfse = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    tipo_credito = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    simples_nacional = table.Column<bool>(type: "INTEGER", nullable: false),
                    aliquota = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    valor_faturado = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    valor_deducao = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    base_calculo = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credito", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credito");
        }
    }
}
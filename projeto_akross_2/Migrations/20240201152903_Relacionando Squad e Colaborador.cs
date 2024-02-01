using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto_akross_2.Migrations
{
    public partial class RelacionandoSquadeColaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SquadId",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Squad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squad", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_SquadId",
                table: "Colaboradores",
                column: "SquadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Squad_SquadId",
                table: "Colaboradores",
                column: "SquadId",
                principalTable: "Squad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Squad_SquadId",
                table: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Squad");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_SquadId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "SquadId",
                table: "Colaboradores");
        }
    }
}

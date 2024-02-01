using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projeto_akross_2.Migrations
{
    public partial class atualizando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Squad_SquadId",
                table: "Colaboradores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Squad",
                table: "Squad");

            migrationBuilder.RenameTable(
                name: "Squad",
                newName: "Squads");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Squads",
                table: "Squads",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Squads_SquadId",
                table: "Colaboradores",
                column: "SquadId",
                principalTable: "Squads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Squads_SquadId",
                table: "Colaboradores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Squads",
                table: "Squads");

            migrationBuilder.RenameTable(
                name: "Squads",
                newName: "Squad");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Squad",
                table: "Squad",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Squad_SquadId",
                table: "Colaboradores",
                column: "SquadId",
                principalTable: "Squad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

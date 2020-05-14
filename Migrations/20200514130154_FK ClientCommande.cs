using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class FKClientCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Client_ClientId",
                table: "Commandes");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Commandes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Client_ClientId",
                table: "Commandes",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Client_ClientId",
                table: "Commandes");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Commandes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Client_ClientId",
                table: "Commandes",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

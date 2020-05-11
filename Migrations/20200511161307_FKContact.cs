using Microsoft.EntityFrameworkCore.Migrations;

namespace HDV_Online.Migrations
{
    public partial class FKContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_TypeContacts_TypeContactId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "TypeContactId",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_TypeContacts_TypeContactId",
                table: "Contacts",
                column: "TypeContactId",
                principalTable: "TypeContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_TypeContacts_TypeContactId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "TypeContactId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_TypeContacts_TypeContactId",
                table: "Contacts",
                column: "TypeContactId",
                principalTable: "TypeContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

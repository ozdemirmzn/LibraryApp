using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryApp.Migrations
{
    public partial class adressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LibraryAddressCity",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LibraryAddressState",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LibraryAddressStreet",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LibraryAddressZip",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LibraryAddressCity",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LibraryAddressState",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LibraryAddressStreet",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LibraryAddressZip",
                table: "Books");
        }
    }
}

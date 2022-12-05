using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eduhome.Migrations
{
    public partial class AddContactWayColumnToContactTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactWay",
                table: "ContactTypes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactWay",
                table: "ContactTypes");
        }
    }
}

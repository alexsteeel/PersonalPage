using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalPage.Data.Migrations
{
    public partial class AddUserIdForAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Authors",
                maxLength: 450,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Authors");
        }
    }
}

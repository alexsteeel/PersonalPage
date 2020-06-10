using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalPage.Data.Migrations
{
    public partial class AddShortDescriptionForPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Posts",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Posts");
        }
    }
}

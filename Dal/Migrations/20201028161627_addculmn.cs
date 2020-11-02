using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class addculmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChoiceText",
                table: "choices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChoiceText",
                table: "choices");
        }
    }
}

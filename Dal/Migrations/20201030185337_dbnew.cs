using Microsoft.EntityFrameworkCore.Migrations;

namespace Dal.Migrations
{
    public partial class dbnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "answers");

            migrationBuilder.AlterColumn<bool>(
                name: "AnswerIstrue",
                table: "choices",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "AnswerIstrue",
                table: "choices",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "answers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

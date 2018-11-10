using Microsoft.EntityFrameworkCore.Migrations;

namespace seminarski.Data.Migrations
{
    public partial class dvica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Auto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Auto");
        }
    }
}

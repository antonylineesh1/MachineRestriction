using Microsoft.EntityFrameworkCore.Migrations;

namespace Sample.Restrct.Data.Migrations
{
    public partial class added_truststat_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrustStatus",
                table: "UserMachines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrustStatus",
                table: "UserMachines");
        }
    }
}

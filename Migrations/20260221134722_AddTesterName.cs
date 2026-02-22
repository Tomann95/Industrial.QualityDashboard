using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Industrial.QualityDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddTesterName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TesterName",
                table: "TestReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TesterName",
                table: "TestReports");
        }
    }
}

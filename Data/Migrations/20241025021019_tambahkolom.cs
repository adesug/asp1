using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace belajarASPDB.Data.Migrations
{
    /// <inheritdoc />
    public partial class tambahkolom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usia",
                table: "NamaSiswaModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usia",
                table: "NamaSiswaModel");
        }
    }
}

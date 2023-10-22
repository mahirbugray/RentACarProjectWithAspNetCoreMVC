using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removePlakaPropWithAraba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plaka",
                table: "ArabaDetaylar");

            migrationBuilder.AddColumn<string>(
                name: "Plaka",
                table: "Arabalar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plaka",
                table: "Arabalar");

            migrationBuilder.AddColumn<string>(
                name: "Plaka",
                table: "ArabaDetaylar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

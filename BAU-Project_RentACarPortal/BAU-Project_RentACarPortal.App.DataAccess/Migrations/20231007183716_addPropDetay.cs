using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addPropDetay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Açıklama",
                table: "ArabaDetaylar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Açıklama",
                table: "ArabaDetaylar");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class editHasarProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevirId",
                table: "Teslimler");

            migrationBuilder.DropColumn(
                name: "HasarDurumu",
                table: "Teslimler");

            migrationBuilder.AlterColumn<int>(
                name: "FaturaNo",
                table: "Kiralamalar",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "HasarDurumu",
                table: "Arabalar",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasarDurumu",
                table: "Arabalar");

            migrationBuilder.AddColumn<int>(
                name: "DevirId",
                table: "Teslimler",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HasarDurumu",
                table: "Teslimler",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaturaNo",
                table: "Kiralamalar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addPropAciklama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Açıklama",
                table: "ArabaDetaylar",
                newName: "Aciklama");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Aciklama",
                table: "ArabaDetaylar",
                newName: "Açıklama");
        }
    }
}

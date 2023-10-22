using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAU_Project_RentACarPortal.App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class degerlendirmeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degerlendirmeler_Firmalar_FirmaId",
                table: "Degerlendirmeler");

            migrationBuilder.DropTable(
                name: "FiltrelemeSecenekleri");

            migrationBuilder.RenameColumn(
                name: "Puan",
                table: "Degerlendirmeler",
                newName: "ArabaId");

            migrationBuilder.AlterColumn<int>(
                name: "FirmaId",
                table: "Degerlendirmeler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Degerlendirmeler_ArabaId",
                table: "Degerlendirmeler",
                column: "ArabaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degerlendirmeler_Arabalar_ArabaId",
                table: "Degerlendirmeler",
                column: "ArabaId",
                principalTable: "Arabalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Degerlendirmeler_Firmalar_FirmaId",
                table: "Degerlendirmeler",
                column: "FirmaId",
                principalTable: "Firmalar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degerlendirmeler_Arabalar_ArabaId",
                table: "Degerlendirmeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Degerlendirmeler_Firmalar_FirmaId",
                table: "Degerlendirmeler");

            migrationBuilder.DropIndex(
                name: "IX_Degerlendirmeler_ArabaId",
                table: "Degerlendirmeler");

            migrationBuilder.RenameColumn(
                name: "ArabaId",
                table: "Degerlendirmeler",
                newName: "Puan");

            migrationBuilder.AlterColumn<int>(
                name: "FirmaId",
                table: "Degerlendirmeler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FiltrelemeSecenekleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArabaId = table.Column<int>(type: "int", nullable: false),
                    Deger1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deger8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Ozellik = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiltrelemeSecenekleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiltrelemeSecenekleri_Arabalar_ArabaId",
                        column: x => x.ArabaId,
                        principalTable: "Arabalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiltrelemeSecenekleri_ArabaId",
                table: "FiltrelemeSecenekleri",
                column: "ArabaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degerlendirmeler_Firmalar_FirmaId",
                table: "Degerlendirmeler",
                column: "FirmaId",
                principalTable: "Firmalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

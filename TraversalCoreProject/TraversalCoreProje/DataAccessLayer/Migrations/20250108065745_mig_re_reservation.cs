using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_re_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "TblReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblReservations_AppUserId",
                table: "TblReservations",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblReservations_AspNetUsers_AppUserId",
                table: "TblReservations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblReservations_AspNetUsers_AppUserId",
                table: "TblReservations");

            migrationBuilder.DropIndex(
                name: "IX_TblReservations_AppUserId",
                table: "TblReservations");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TblReservations");
        }
    }
}

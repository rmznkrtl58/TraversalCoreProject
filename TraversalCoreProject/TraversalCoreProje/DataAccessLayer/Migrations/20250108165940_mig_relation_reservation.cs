using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_relation_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "TblReservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblReservations_DestinationId",
                table: "TblReservations",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblReservations_Destinations_DestinationId",
                table: "TblReservations",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblReservations_Destinations_DestinationId",
                table: "TblReservations");

            migrationBuilder.DropIndex(
                name: "IX_TblReservations_DestinationId",
                table: "TblReservations");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "TblReservations");
        }
    }
}

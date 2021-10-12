using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelResAPI.Migrations
{
    public partial class TotalAmountAddedToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Reservations");
        }
    }
}

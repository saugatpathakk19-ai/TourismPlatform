using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismPlatform.Migrations
{
    /// <inheritdoc />
    public partial class FixBookingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TourDate",
                table: "Bookings",
                newName: "BookingDate");

            migrationBuilder.RenameColumn(
                name: "PeopleCount",
                table: "Bookings",
                newName: "NumberOfPeople");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfPeople",
                table: "Bookings",
                newName: "PeopleCount");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "Bookings",
                newName: "TourDate");
        }
    }
}

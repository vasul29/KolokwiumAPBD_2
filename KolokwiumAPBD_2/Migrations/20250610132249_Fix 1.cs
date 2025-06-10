using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolokwiumAPBD_2.Migrations
{
    /// <inheritdoc />
    public partial class Fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Participation_Track_Race_TrackRaceId",
                table: "Race_Participation");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Participation_Track_Race_TrackRaceId",
                table: "Race_Participation",
                column: "TrackRaceId",
                principalTable: "Track_Race",
                principalColumn: "TrackRaceId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Participation_Track_Race_TrackRaceId",
                table: "Race_Participation");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Participation_Track_Race_TrackRaceId",
                table: "Race_Participation",
                column: "TrackRaceId",
                principalTable: "Track_Race",
                principalColumn: "TrackRaceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

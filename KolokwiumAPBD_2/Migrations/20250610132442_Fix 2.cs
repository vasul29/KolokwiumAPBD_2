using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolokwiumAPBD_2.Migrations
{
    /// <inheritdoc />
    public partial class Fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Participation_Racer_RacerId",
                table: "Race_Participation");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Participation_Racer_RacerId",
                table: "Race_Participation",
                column: "RacerId",
                principalTable: "Racer",
                principalColumn: "RacerId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Participation_Racer_RacerId",
                table: "Race_Participation");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Participation_Racer_RacerId",
                table: "Race_Participation",
                column: "RacerId",
                principalTable: "Racer",
                principalColumn: "RacerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

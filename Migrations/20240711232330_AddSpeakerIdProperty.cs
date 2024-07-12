using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpeakerManagerApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSpeakerIdProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpeakerId",
                table: "UserTexts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpeakerId",
                table: "UserTexts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_WebAPP_JokeSite.Migrations
{
    /// <inheritdoc />
    public partial class createrelationship_user_and_joke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "JokeModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JokeModel_ApplicationUserId",
                table: "JokeModel",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JokeModel_AspNetUsers_ApplicationUserId",
                table: "JokeModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JokeModel_AspNetUsers_ApplicationUserId",
                table: "JokeModel");

            migrationBuilder.DropIndex(
                name: "IX_JokeModel_ApplicationUserId",
                table: "JokeModel");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "JokeModel");
        }
    }
}

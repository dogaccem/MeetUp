using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetUp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dockerV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendedEvent_AspNetUsers_ApplicationUserId",
                table: "AttendedEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendedEvent_Events_EventId",
                table: "AttendedEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteEvent_AspNetUsers_ApplicationUserId",
                table: "FavoriteEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteEvent_Events_EventId",
                table: "FavoriteEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendedEvent_AspNetUsers_ApplicationUserId",
                table: "AttendedEvent",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendedEvent_Events_EventId",
                table: "AttendedEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteEvent_AspNetUsers_ApplicationUserId",
                table: "FavoriteEvent",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteEvent_Events_EventId",
                table: "FavoriteEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendedEvent_AspNetUsers_ApplicationUserId",
                table: "AttendedEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendedEvent_Events_EventId",
                table: "AttendedEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteEvent_AspNetUsers_ApplicationUserId",
                table: "FavoriteEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteEvent_Events_EventId",
                table: "FavoriteEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendedEvent_AspNetUsers_ApplicationUserId",
                table: "AttendedEvent",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendedEvent_Events_EventId",
                table: "AttendedEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteEvent_AspNetUsers_ApplicationUserId",
                table: "FavoriteEvent",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteEvent_Events_EventId",
                table: "FavoriteEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

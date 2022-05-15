using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class _213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemCollectionUserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BlackTheme",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isEnglish",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_ItemCollectionUserId",
                table: "Collections",
                column: "ItemCollectionUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_ItemCollectionUserId",
                table: "Collections",
                column: "ItemCollectionUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_ItemCollectionUserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_ItemCollectionUserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "ItemCollectionUserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "BlackTheme",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isEnglish",
                table: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class zxczxc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Images_ImageCollectionId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ImageCollectionId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ImageCollectionId",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageCollectionId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ImageCollectionId",
                table: "Items",
                column: "ImageCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Images_ImageCollectionId",
                table: "Items",
                column: "ImageCollectionId",
                principalTable: "Images",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

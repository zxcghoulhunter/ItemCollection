using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class imageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Images_ImageId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_ImageId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Collections");

            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CollectionId",
                table: "Images",
                column: "CollectionId",
                unique: true,
                filter: "[CollectionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Collections_CollectionId",
                table: "Images",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Collections_CollectionId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CollectionId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_ImageId",
                table: "Collections",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Images_ImageId",
                table: "Collections",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

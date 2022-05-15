using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class imageTRY30000000000000000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Images_ImageId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CollectionId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Items",
                newName: "ImageCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ImageId",
                table: "Items",
                newName: "IX_Items_ImageCollectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Images_ImageCollectionId",
                table: "Items",
                column: "ImageCollectionId",
                principalTable: "Images",
                principalColumn: "CollectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Images_ImageCollectionId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageCollectionId",
                table: "Items",
                newName: "ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_ImageCollectionId",
                table: "Items",
                newName: "IX_Items_ImageId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CollectionId",
                table: "Images",
                column: "CollectionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Images_ImageId",
                table: "Items",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

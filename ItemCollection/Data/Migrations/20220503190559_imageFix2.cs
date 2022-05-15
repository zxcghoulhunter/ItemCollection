using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class imageFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Collections_CollectionId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CollectionId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Images",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CollectionId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CollectionId",
                table: "Images",
                column: "CollectionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Collections_CollectionId",
                table: "Images",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Collections_CollectionId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CollectionId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Images",
                newName: "ImageId");

            migrationBuilder.AlterColumn<int>(
                name: "CollectionId",
                table: "Images",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}

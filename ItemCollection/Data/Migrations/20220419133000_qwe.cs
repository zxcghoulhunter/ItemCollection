using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class qwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Collections_CollectionKey",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CollectionKey",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CollectionKey",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollectionId",
                table: "Items",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Collections_CollectionId",
                table: "Items",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Collections_CollectionId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CollectionId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "CollectionKey",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollectionKey",
                table: "Items",
                column: "CollectionKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Collections_CollectionKey",
                table: "Items",
                column: "CollectionKey",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

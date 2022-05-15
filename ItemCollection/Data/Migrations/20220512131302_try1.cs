using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class try1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Collections_CollectionId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CollectionId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CollectionId",
                table: "Comments",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Collections_CollectionId",
                table: "Comments",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

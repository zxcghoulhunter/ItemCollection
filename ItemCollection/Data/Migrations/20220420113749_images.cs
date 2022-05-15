using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

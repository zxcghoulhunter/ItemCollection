using Microsoft.EntityFrameworkCore.Migrations;

namespace ItemCollection.Data.Migrations
{
    public partial class fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BoolFieldOne",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BoolFieldThree",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BoolFieldTwo",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntFieldOne",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntFieldThree",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IntFieldTwo",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringFieldOne",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringFieldThree",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringFieldTwo",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoolFieldOneName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoolFieldThreeName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoolFieldTwoName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntFieldOneName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntFieldThreeName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IntFieldTwoName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringFieldOneName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringFieldThreeName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringFieldTwoName",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoolFieldOne",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BoolFieldThree",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BoolFieldTwo",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IntFieldOne",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IntFieldThree",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IntFieldTwo",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StringFieldOne",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StringFieldThree",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StringFieldTwo",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BoolFieldOneName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "BoolFieldThreeName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "BoolFieldTwoName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IntFieldOneName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IntFieldThreeName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IntFieldTwoName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "StringFieldOneName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "StringFieldThreeName",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "StringFieldTwoName",
                table: "Collections");
        }
    }
}

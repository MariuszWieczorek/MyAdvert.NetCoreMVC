using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAdvert.Data.Migrations
{
    public partial class add_value_and_picture_to_adverb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Adverts",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Adverts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Adverts");
        }
    }
}

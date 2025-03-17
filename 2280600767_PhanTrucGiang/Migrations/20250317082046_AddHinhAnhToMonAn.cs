using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2280600767_PhanTrucGiang.Migrations
{
    public partial class AddHinhAnhToMonAn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "MonAn",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "MonAn");
        }
    }
}

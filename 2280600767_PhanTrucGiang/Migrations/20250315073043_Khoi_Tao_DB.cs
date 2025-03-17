using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2280600767_PhanTrucGiang.Migrations
{
    public partial class Khoi_Tao_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoaiMonAn",
                columns: table => new
                {
                    MaLoaiMonAn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoaiMonAn = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiMonAn", x => x.MaLoaiMonAn);
                });

            migrationBuilder.CreateTable(
                name: "MonAn",
                columns: table => new
                {
                    MaMonAn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenMonAn = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Soluongton = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<float>(type: "real", nullable: false),
                    MaLoaiMonAn = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAn", x => x.MaMonAn);
                    table.ForeignKey(
                        name: "FK_MonAn_LoaiMonAn_MaLoaiMonAn",
                        column: x => x.MaLoaiMonAn,
                        principalTable: "LoaiMonAn",
                        principalColumn: "MaLoaiMonAn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonAn_MaLoaiMonAn",
                table: "MonAn",
                column: "MaLoaiMonAn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonAn");

            migrationBuilder.DropTable(
                name: "LoaiMonAn");
        }
    }
}

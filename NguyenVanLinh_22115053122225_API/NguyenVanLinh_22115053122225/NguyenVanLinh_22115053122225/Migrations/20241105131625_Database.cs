using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenVanLinh_22115053122225.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucHoa",
                columns: table => new
                {
                    MaDM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucHoa", x => x.MaDM);
                });

            migrationBuilder.CreateTable(
                name: "Hoa",
                columns: table => new
                {
                    MaH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDM = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Donvitinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dongia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoa", x => x.MaH);
                    table.ForeignKey(
                        name: "FK_Hoa_DanhMucHoa_MaDM",
                        column: x => x.MaDM,
                        principalTable: "DanhMucHoa",
                        principalColumn: "MaDM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_MaDM",
                table: "Hoa",
                column: "MaDM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hoa");

            migrationBuilder.DropTable(
                name: "DanhMucHoa");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioAmsterdam.Migrations
{
    public partial class TableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableData",
                columns: table => new
                {
                    TabeleDataID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TableHeaderTableID = table.Column<int>(nullable: true),
                    RowData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableData", x => x.TabeleDataID);
                    table.ForeignKey(
                        name: "FK_TableData_TableHeaders_TableHeaderTableID",
                        column: x => x.TableHeaderTableID,
                        principalTable: "TableHeaders",
                        principalColumn: "TableID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableData_TableHeaderTableID",
                table: "TableData",
                column: "TableHeaderTableID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableData");
        }
    }
}

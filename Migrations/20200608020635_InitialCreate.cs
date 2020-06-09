using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyManagerTool.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyDb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyCode = table.Column<string>(type: "varchar(250)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", nullable: true),
                    WrongEmail = table.Column<string>(type: "varchar(250)", nullable: true),
                    ContactNumber = table.Column<string>(type: "varchar(250)", nullable: true),
                    County = table.Column<string>(type: "varchar(250)", nullable: true),
                    VMVT = table.Column<string>(type: "varchar(250)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "varchar(250)", nullable: true),
                    Activities = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDb", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDb");
        }
    }
}

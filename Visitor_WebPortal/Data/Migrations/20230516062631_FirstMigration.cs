using Microsoft.EntityFrameworkCore.Migrations;

namespace Visitor_WebPortal.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "VisitType",
             columns: table => new
             {
                 VisitTypeId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 VisitTypeName = table.Column<string>(maxLength: 100, nullable: true),
            
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_VisitType", x => x.VisitTypeId);
             });
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    VisitTypeId = table.Column<int>(nullable: true),
                    IsForeigner = table.Column<bool>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Designation = table.Column<string>(maxLength: 100, nullable: true),
                    LicensePlate = table.Column<string>(nullable: false),
                    NRIC = table.Column<string>(maxLength: 50, nullable: false),
                    Quarantine = table.Column<bool>(nullable: false),
                    Symptoms = table.Column<bool>(nullable: false),
                    Contact_CovidCase = table.Column<bool>(nullable: false),
                    Acknowledge = table.Column<bool>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                    name: "FK_Visitor_VisitType",
                    column: x => x.VisitTypeId,
                    principalTable: "VisitType",
                    principalColumn: "VisitTypeId",
                    onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
            name: "IX_Visitor_VisitTypeId",
            table: "Visitors",
            column: "VisitTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitors");
                migrationBuilder.DropTable(
                name: "VisitType");
        }
    }
}

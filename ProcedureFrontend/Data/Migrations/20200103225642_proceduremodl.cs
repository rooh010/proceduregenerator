using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcedureFrontend.Data.Migrations
{
    public partial class proceduremodl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcedureModel",
                columns: table => new
                {
                    ProcedureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StepNumber = table.Column<int>(nullable: false),
                    StepDescription = table.Column<string>(nullable: true),
                    StepType = table.Column<string>(nullable: true),
                    Version = table.Column<double>(nullable: false),
                    ProcedureName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureModel", x => x.ProcedureId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcedureModel");
        }
    }
}

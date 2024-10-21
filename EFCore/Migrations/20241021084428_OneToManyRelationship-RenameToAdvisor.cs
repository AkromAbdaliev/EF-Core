using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class OneToManyRelationshipRenameToAdvisor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.AddColumn<int>(
                name: "AdvisorId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    AdvisorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.AdvisorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdvisorId",
                table: "Students",
                column: "AdvisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Advisors_AdvisorId",
                table: "Students",
                column: "AdvisorId",
                principalTable: "Advisors",
                principalColumn: "AdvisorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Advisors_AdvisorId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Advisors");

            migrationBuilder.DropIndex(
                name: "IX_Students_AdvisorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AdvisorId",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VolunteerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VolunteerId);
                });
        }
    }
}

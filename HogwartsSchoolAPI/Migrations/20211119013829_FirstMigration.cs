using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsSchoolAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Identification = table.Column<long>(nullable: false),
                    Age = table.Column<short>(nullable: false),
                    Id_House = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmissionApplications_Houses_Id_House",
                        column: x => x.Id_House,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Gryffindor" },
                    { 2, "Hufflepuff" },
                    { 3, "Ravenclaw" },
                    { 4, "Slytherin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionApplications_Id_House",
                table: "AdmissionApplications",
                column: "Id_House");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionApplications");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}

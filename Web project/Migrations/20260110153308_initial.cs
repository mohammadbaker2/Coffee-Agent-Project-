using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_project.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                    table.ForeignKey(
                        name: "FK_Agents_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Jenin" },
                    { 2, "Nablus" },
                    { 3, "Ramallah" },
                    { 4, "Jerusalem" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "AgentId", "CityId", "Name", "Password", "PhoneNumber", "Role", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "Ahmad", "123", "0599004201", "Admin", 4000m },
                    { 2, 2, "Sara", "456", "0599540002", "User", 3500m },
                    { 3, 2, "Mohammad", "453", "0599005502", "User", 3500m },
                    { 4, 1, "Dania", "436", "0599044002", "User", 3530m },
                    { 5, 2, "Sami", "156", "0599034002", "User", 3500m },
                    { 6, 4, "Ameed", "236", "0599004302", "User", 3500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CityId",
                table: "Agents",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}

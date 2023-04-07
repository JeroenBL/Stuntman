#nullable disable

namespace Stuntman.Web.Migrations;

public partial class initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Departments",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ExternalId = table.Column<int>(type: "INTEGER", nullable: false),
                DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                ManagerExternalId = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Departments", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Stuntman",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                UserId = table.Column<int>(type: "INTEGER", nullable: false),
                ExternalId = table.Column<string>(type: "TEXT", nullable: true),
                GivenName = table.Column<string>(type: "TEXT", nullable: true),
                FamilyName = table.Column<string>(type: "TEXT", nullable: true),
                DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                UserName = table.Column<string>(type: "TEXT", nullable: true),
                Initials = table.Column<string>(type: "TEXT", nullable: true),
                PersonalEmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                PersonalPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                BusinessEmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                BusinessPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                BirthPlace = table.Column<string>(type: "TEXT", nullable: true),
                Language = table.Column<string>(type: "TEXT", nullable: true),
                City = table.Column<string>(type: "TEXT", nullable: true),
                Street = table.Column<string>(type: "TEXT", nullable: true),
                HouseNumber = table.Column<int>(type: "INTEGER", nullable: false),
                ZipCode = table.Column<string>(type: "TEXT", nullable: true),
                IsActive = table.Column<int>(type: "INTEGER", nullable: false),
                UserGuid = table.Column<string>(type: "TEXT", nullable: true),
                Company = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Stuntman", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Contracts",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                UserId = table.Column<int>(type: "INTEGER", nullable: false),
                UserExternalId = table.Column<string>(type: "TEXT", nullable: true),
                Title = table.Column<string>(type: "TEXT", nullable: true),
                IsManager = table.Column<int>(type: "INTEGER", nullable: false),
                StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                HoursPerWeek = table.Column<int>(type: "INTEGER", nullable: false),
                Department = table.Column<string>(type: "TEXT", nullable: true),
                DepartmentExternalId = table.Column<int>(type: "INTEGER", nullable: false),
                CostCenter = table.Column<string>(type: "TEXT", nullable: true),
                ContractGuid = table.Column<string>(type: "TEXT", nullable: true),
                StuntmanModelId = table.Column<int>(type: "INTEGER", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Contracts", x => x.Id);
                table.ForeignKey(
                    name: "FK_Contracts_Stuntman_StuntmanModelId",
                    column: x => x.StuntmanModelId,
                    principalTable: "Stuntman",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Contracts_StuntmanModelId",
            table: "Contracts",
            column: "StuntmanModelId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Contracts");

        migrationBuilder.DropTable(
            name: "Departments");

        migrationBuilder.DropTable(
            name: "Stuntman");
    }
}

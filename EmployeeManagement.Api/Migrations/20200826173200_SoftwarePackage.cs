using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Api.Migrations
{
    public partial class SoftwarePackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoftwaredPackage",
                columns: table => new
                {
                    SoftwarePackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwarePackageCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SoftwarePackageDescription = table.Column<string>(maxLength: 300, nullable: false),
                    LinkAdd = table.Column<string>(nullable: true),
                    SoftwarePackageImage = table.Column<byte[]>(nullable: true),
                    SoftwarePackageImagePath = table.Column<string>(nullable: true),
                    SoftwarePackageFileExtension = table.Column<string>(nullable: true),
                    PackageStartDate = table.Column<string>(nullable: true),
                    PackageEndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwaredPackage", x => x.SoftwarePackageId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoftwaredPackage");
        }
    }
}

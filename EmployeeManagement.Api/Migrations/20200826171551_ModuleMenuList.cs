using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Api.Migrations
{
    public partial class ModuleMenuList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageCriteria",
                columns: table => new
                {
                    ImageCriteriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageCriteriaCaption = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCriteria", x => x.ImageCriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission_Master",
                columns: table => new
                {
                    MenuPermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    useridPermission = table.Column<string>(maxLength: 128, nullable: true),
                    comid = table.Column<string>(maxLength: 128, nullable: true),
                    userid = table.Column<string>(maxLength: 128, nullable: true),
                    useridUpdate = table.Column<string>(maxLength: 128, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    Updatedby = table.Column<string>(maxLength: 50, nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission_Master", x => x.MenuPermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCode = table.Column<string>(nullable: false),
                    ModuleName = table.Column<string>(nullable: false),
                    ModuleCaption = table.Column<string>(nullable: false),
                    ModuleDescription = table.Column<string>(maxLength: 300, nullable: false),
                    ModuleLink = table.Column<string>(nullable: true),
                    ModuleClassa = table.Column<string>(nullable: true),
                    ModuleClassi = table.Column<string>(nullable: true),
                    ModuleImage = table.Column<byte[]>(nullable: true),
                    ModuleImagePath = table.Column<string>(nullable: true),
                    ModuleImageExtension = table.Column<string>(nullable: true),
                    isInactive = table.Column<int>(nullable: false),
                    SLNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "ModuleGroup",
                columns: table => new
                {
                    ModuleGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleGroupName = table.Column<string>(maxLength: 100, nullable: false),
                    ModuleGroupCaption = table.Column<string>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    ModuleGroupImage = table.Column<byte[]>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageExtension = table.Column<string>(nullable: true),
                    SLNo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleGroup", x => x.ModuleGroupId);
                    table.ForeignKey(
                        name: "FK_ModuleGroup_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModuleMenu",
                columns: table => new
                {
                    ModuleMenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleMenuName = table.Column<string>(maxLength: 100, nullable: false),
                    ModuleMenuCaption = table.Column<string>(nullable: false),
                    ModuleGroupId = table.Column<int>(nullable: false),
                    ImageCriteriaId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false),
                    ModuleMenuImage = table.Column<byte[]>(nullable: true),
                    ModuleImagePath = table.Column<string>(nullable: true),
                    ModuleImageExtension = table.Column<string>(nullable: true),
                    ModuleMenuController = table.Column<string>(nullable: true),
                    ModuleMenuLink = table.Column<string>(nullable: true),
                    isInactive = table.Column<int>(nullable: false),
                    isParent = table.Column<int>(nullable: false),
                    SLNo = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    ModuleMenuClassi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMenu", x => x.ModuleMenuId);
                    table.ForeignKey(
                        name: "FK_ModuleMenu_ImageCriteria_ImageCriteriaId",
                        column: x => x.ImageCriteriaId,
                        principalTable: "ImageCriteria",
                        principalColumn: "ImageCriteriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMenu_ModuleGroup_ModuleGroupId",
                        column: x => x.ModuleGroupId,
                        principalTable: "ModuleGroup",
                        principalColumn: "ModuleGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleMenu_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "ModuleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModuleMenu_ModuleMenu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ModuleMenu",
                        principalColumn: "ModuleMenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermission_Details",
                columns: table => new
                {
                    MenuPermissionDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuPermissionId = table.Column<int>(nullable: false),
                    ModuleMenuId = table.Column<int>(nullable: false),
                    IsCreate = table.Column<bool>(nullable: false),
                    IsEdit = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    IsView = table.Column<bool>(nullable: false),
                    IsReport = table.Column<bool>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission_Details", x => x.MenuPermissionDetailsId);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Details_MenuPermission_Master_MenuPermissionId",
                        column: x => x.MenuPermissionId,
                        principalTable: "MenuPermission_Master",
                        principalColumn: "MenuPermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPermission_Details_ModuleMenu_ModuleMenuId",
                        column: x => x.ModuleMenuId,
                        principalTable: "ModuleMenu",
                        principalColumn: "ModuleMenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_Details_MenuPermissionId",
                table: "MenuPermission_Details",
                column: "MenuPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermission_Details_ModuleMenuId",
                table: "MenuPermission_Details",
                column: "ModuleMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleGroup_ModuleId",
                table: "ModuleGroup",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenu_ImageCriteriaId",
                table: "ModuleMenu",
                column: "ImageCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenu_ModuleGroupId",
                table: "ModuleMenu",
                column: "ModuleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenu_ModuleId",
                table: "ModuleMenu",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleMenu_ParentId",
                table: "ModuleMenu",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuPermission_Details");

            migrationBuilder.DropTable(
                name: "MenuPermission_Master");

            migrationBuilder.DropTable(
                name: "ModuleMenu");

            migrationBuilder.DropTable(
                name: "ImageCriteria");

            migrationBuilder.DropTable(
                name: "ModuleGroup");

            migrationBuilder.DropTable(
                name: "Module");
        }
    }
}

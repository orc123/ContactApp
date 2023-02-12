using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Migrations
{
    /// <inheritdoc />
    public partial class renametableperson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersions_AbpUsers_CreatorId",
                table: "ContactPersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersions_AbpUsers_DeleterId",
                table: "ContactPersions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersions_AbpUsers_LastModifierId",
                table: "ContactPersions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPersions",
                table: "ContactPersions");

            migrationBuilder.RenameTable(
                name: "ContactPersions",
                newName: "ContactPersons");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersions_LastModifierId",
                table: "ContactPersons",
                newName: "IX_ContactPersons_LastModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersions_DeleterId",
                table: "ContactPersons",
                newName: "IX_ContactPersons_DeleterId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersions_CreatorId",
                table: "ContactPersons",
                newName: "IX_ContactPersons_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_AbpUsers_CreatorId",
                table: "ContactPersons",
                column: "CreatorId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_AbpUsers_DeleterId",
                table: "ContactPersons",
                column: "DeleterId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersons_AbpUsers_LastModifierId",
                table: "ContactPersons",
                column: "LastModifierId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_AbpUsers_CreatorId",
                table: "ContactPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_AbpUsers_DeleterId",
                table: "ContactPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPersons_AbpUsers_LastModifierId",
                table: "ContactPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPersons",
                table: "ContactPersons");

            migrationBuilder.RenameTable(
                name: "ContactPersons",
                newName: "ContactPersions");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersons_LastModifierId",
                table: "ContactPersions",
                newName: "IX_ContactPersions_LastModifierId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersons_DeleterId",
                table: "ContactPersions",
                newName: "IX_ContactPersions_DeleterId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPersons_CreatorId",
                table: "ContactPersions",
                newName: "IX_ContactPersions_CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPersions",
                table: "ContactPersions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersions_AbpUsers_CreatorId",
                table: "ContactPersions",
                column: "CreatorId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersions_AbpUsers_DeleterId",
                table: "ContactPersions",
                column: "DeleterId",
                principalTable: "AbpUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPersions_AbpUsers_LastModifierId",
                table: "ContactPersions",
                column: "LastModifierId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}

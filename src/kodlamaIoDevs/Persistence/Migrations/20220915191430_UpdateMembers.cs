using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GithubAccounts_Developers_DeveloperId",
                table: "GithubAccounts");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_GithubAccounts_DeveloperId",
                table: "GithubAccounts");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "GithubAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GithubAccounts_MemberId",
                table: "GithubAccounts",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_GithubAccounts_Members_MemberId",
                table: "GithubAccounts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GithubAccounts_Members_MemberId",
                table: "GithubAccounts");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropIndex(
                name: "IX_GithubAccounts_MemberId",
                table: "GithubAccounts");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "GithubAccounts");

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Developers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GithubAccounts_DeveloperId",
                table: "GithubAccounts",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_GithubAccounts_Developers_DeveloperId",
                table: "GithubAccounts",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

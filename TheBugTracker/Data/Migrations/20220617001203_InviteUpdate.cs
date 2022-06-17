using Microsoft.EntityFrameworkCore.Migrations;

namespace TheBugTracker.Data.Migrations
{
    public partial class InviteUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_AspNetUsers_InviteeID",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Companies_CompanyID",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Projects_ProjectID",
                table: "Invites");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Invites",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "InviteeID",
                table: "Invites",
                newName: "InviteeId");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "Invites",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_ProjectID",
                table: "Invites",
                newName: "IX_Invites_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_InviteeID",
                table: "Invites",
                newName: "IX_Invites_InviteeId");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_CompanyID",
                table: "Invites",
                newName: "IX_Invites_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "InviteeLastName",
                table: "Invites",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "InviteeFirstName",
                table: "Invites",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "InviteeEmail",
                table: "Invites",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_AspNetUsers_InviteeId",
                table: "Invites",
                column: "InviteeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Companies_CompanyId",
                table: "Invites",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Projects_ProjectId",
                table: "Invites",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invites_AspNetUsers_InviteeId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Companies_CompanyId",
                table: "Invites");

            migrationBuilder.DropForeignKey(
                name: "FK_Invites_Projects_ProjectId",
                table: "Invites");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Invites",
                newName: "ProjectID");

            migrationBuilder.RenameColumn(
                name: "InviteeId",
                table: "Invites",
                newName: "InviteeID");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Invites",
                newName: "CompanyID");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_ProjectId",
                table: "Invites",
                newName: "IX_Invites_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_InviteeId",
                table: "Invites",
                newName: "IX_Invites_InviteeID");

            migrationBuilder.RenameIndex(
                name: "IX_Invites_CompanyId",
                table: "Invites",
                newName: "IX_Invites_CompanyID");

            migrationBuilder.AlterColumn<int>(
                name: "InviteeLastName",
                table: "Invites",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InviteeFirstName",
                table: "Invites",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InviteeEmail",
                table: "Invites",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_AspNetUsers_InviteeID",
                table: "Invites",
                column: "InviteeID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Companies_CompanyID",
                table: "Invites",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invites_Projects_ProjectID",
                table: "Invites",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

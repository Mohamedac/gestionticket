using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gestionticket.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_MembreSupportTechnique_AssigneId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "AssigneId",
                table: "Ticket",
                newName: "AssigneeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_AssigneId",
                table: "Ticket",
                newName: "IX_Ticket_AssigneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_MembreSupportTechnique_AssigneeId",
                table: "Ticket",
                column: "AssigneeId",
                principalTable: "MembreSupportTechnique",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_MembreSupportTechnique_AssigneeId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "AssigneeId",
                table: "Ticket",
                newName: "AssigneId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_AssigneeId",
                table: "Ticket",
                newName: "IX_Ticket_AssigneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_MembreSupportTechnique_AssigneId",
                table: "Ticket",
                column: "AssigneId",
                principalTable: "MembreSupportTechnique",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Condo.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessControlTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessControl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnityId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessControl_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessControl_Unities_UnityId",
                        column: x => x.UnityId,
                        principalTable: "Unities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessControl_PersonId",
                table: "AccessControl",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessControl_UnityId",
                table: "AccessControl",
                column: "UnityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessControl");
        }
    }
}

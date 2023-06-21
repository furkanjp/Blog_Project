using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_RaytingTableRevize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogRayting",
                table: "BlogRayting");

            migrationBuilder.RenameTable(
                name: "BlogRayting",
                newName: "BlogRaytings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogRaytings",
                table: "BlogRaytings",
                column: "BlogRaytingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogRaytings",
                table: "BlogRaytings");

            migrationBuilder.RenameTable(
                name: "BlogRaytings",
                newName: "BlogRayting");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogRayting",
                table: "BlogRayting",
                column: "BlogRaytingID");
        }
    }
}

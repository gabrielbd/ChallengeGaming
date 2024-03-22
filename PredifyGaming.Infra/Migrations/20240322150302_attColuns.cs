using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PredifyGaming.Infra.Migrations
{
    /// <inheritdoc />
    public partial class attColuns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pontos",
                table: "Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "pontos",
                table: "Players",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

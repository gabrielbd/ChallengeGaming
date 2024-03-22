using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PredifyGaming.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Att_Db_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoJogadas_Players_PlayersId",
                table: "ResultadoJogadas");

            migrationBuilder.RenameColumn(
                name: "PlayersId",
                table: "ResultadoJogadas",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultadoJogadas_PlayersId",
                table: "ResultadoJogadas",
                newName: "IX_ResultadoJogadas_PlayerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "ResultadoJogadas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraCriacao",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraCriacao",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoJogadas_Players_PlayerId",
                table: "ResultadoJogadas",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoJogadas_Players_PlayerId",
                table: "ResultadoJogadas");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "ResultadoJogadas");

            migrationBuilder.DropColumn(
                name: "DataHoraCriacao",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DataHoraCriacao",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "ResultadoJogadas",
                newName: "PlayersId");

            migrationBuilder.RenameIndex(
                name: "IX_ResultadoJogadas_PlayerId",
                table: "ResultadoJogadas",
                newName: "IX_ResultadoJogadas_PlayersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoJogadas_Players_PlayersId",
                table: "ResultadoJogadas",
                column: "PlayersId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

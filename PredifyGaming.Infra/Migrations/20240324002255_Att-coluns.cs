using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PredifyGaming.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Attcoluns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "ResultadoJogadas",
                newName: "DataHoraJogada");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraJogada",
                table: "ResultadoJogadas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraCriacao",
                table: "Players",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraCriacao",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHoraJogada",
                table: "ResultadoJogadas",
                newName: "TimeStamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStamp",
                table: "ResultadoJogadas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraCriacao",
                table: "Players",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataHoraCriacao",
                table: "Games",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}

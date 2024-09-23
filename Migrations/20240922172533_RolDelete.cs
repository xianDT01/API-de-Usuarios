using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class RolDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UltimoAcceso",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Usuarios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimoAcceso",
                table: "Usuarios",
                type: "TEXT",
                nullable: true);
        }
    }
}

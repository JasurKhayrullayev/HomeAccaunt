using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Home.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entertainments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enname = table.Column<string>(type: "text", nullable: false),
                    encategory = table.Column<string>(type: "text", nullable: false),
                    enplace = table.Column<string>(type: "text", nullable: false),
                    enprice = table.Column<string>(type: "text", nullable: false),
                    encomment = table.Column<string>(type: "text", nullable: false),
                    endate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entertainments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    foodName = table.Column<string>(type: "text", nullable: false),
                    foodCategory = table.Column<string>(type: "text", nullable: false),
                    foodprice = table.Column<string>(type: "text", nullable: false),
                    foodcomment = table.Column<string>(type: "text", nullable: false),
                    fooddate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Internets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    inpcodenum = table.Column<int>(type: "integer", nullable: false),
                    inname = table.Column<string>(type: "text", nullable: false),
                    incategory = table.Column<string>(type: "text", nullable: false),
                    inprice = table.Column<string>(type: "text", nullable: false),
                    incomment = table.Column<string>(type: "text", nullable: false),
                    indate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mobnumber = table.Column<int>(type: "integer", nullable: false),
                    mobname = table.Column<string>(type: "text", nullable: false),
                    mobcategory = table.Column<string>(type: "text", nullable: false),
                    mobprice = table.Column<string>(type: "text", nullable: false),
                    mobcomment = table.Column<string>(type: "text", nullable: false),
                    mobdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    trname = table.Column<string>(type: "text", nullable: false),
                    trcategory = table.Column<string>(type: "text", nullable: false),
                    trprice = table.Column<string>(type: "text", nullable: false),
                    trcomment = table.Column<string>(type: "text", nullable: false),
                    trdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entertainments");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Internets");

            migrationBuilder.DropTable(
                name: "Mobiles");

            migrationBuilder.DropTable(
                name: "Transports");
        }
    }
}

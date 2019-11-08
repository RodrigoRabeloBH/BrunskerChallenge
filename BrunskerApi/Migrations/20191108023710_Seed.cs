using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrunskerApi.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Nickname = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Document = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Gender = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    DateOfBirth = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Phone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    State = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Zipcode = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

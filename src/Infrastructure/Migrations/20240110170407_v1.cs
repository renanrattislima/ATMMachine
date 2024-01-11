using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaperMoneys",
                columns: table => new
                {
                    PaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isWithdrawn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperMoneys", x => x.PaperId);
                });

            migrationBuilder.CreateTable(
                name: "Withdraws",
                columns: table => new
                {
                    WithdrawId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WithdrawDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraws", x => x.WithdrawId);
                    table.ForeignKey(
                        name: "FK_Withdraws_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Withdraws_ClientId",
                table: "Withdraws",
                column: "ClientId");


            migrationBuilder.Sql("INSERT INTO [ATMMachine].[dbo].[PaperMoneys]\r\nSELECT NEWID(),10,'00000001',GETDATE(),0  UNION\r\nSELECT NEWID(),10,'00000002',GETDATE(),0  UNION\r\nSELECT NEWID(),20,'00000003',GETDATE(),0  UNION\r\nSELECT NEWID(),20,'00000004',GETDATE(),0  UNION\r\nSELECT NEWID(),50,'00000005',GETDATE(),0  UNION\r\nSELECT NEWID(),50,'00000006',GETDATE(),0  UNION\r\nSELECT NEWID(),50,'00000007',GETDATE(),0  UNION\r\nSELECT NEWID(),100,'00000008',GETDATE(),0  UNION\r\nSELECT NEWID(),100,'00000009',GETDATE(),0"); // <<< Anything you want :)
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaperMoneys");

            migrationBuilder.DropTable(
                name: "Withdraws");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

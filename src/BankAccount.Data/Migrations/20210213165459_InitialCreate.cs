using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAccount.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BankCode = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(50)", nullable: false),
                    AuthenticatedUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdAccount = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Neighborhood = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    City = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    State = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Country = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    ZipCode = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdBank = table.Column<Guid>(nullable: false),
                    IdOwner = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(type: "varchar(200)", nullable: false),
                    BankCode = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbAccount_tbBank_IdBank",
                        column: x => x.IdBank,
                        principalTable: "tbBank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbAccount_tbOwner_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "tbOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbBankStatement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false),
                    AccountId = table.Column<Guid>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBankStatement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbBankStatement_tbAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tbAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbBankStatement_tbOwner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "tbOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdAccount = table.Column<byte[]>(type: "binary(32)", nullable: false),
                    IdBank = table.Column<byte[]>(type: "binary(32)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal", nullable: false),
                    MovDate = table.Column<DateTime>(type: "date", nullable: false),
                    BankId = table.Column<Guid>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbTransaction_tbAccount_Id",
                        column: x => x.Id,
                        principalTable: "tbAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbTransaction_tbBank_BankId",
                        column: x => x.BankId,
                        principalTable: "tbBank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbTransaction_tbAccount_Id1",
                        column: x => x.Id,
                        principalTable: "tbAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAccount_IdBank",
                table: "tbAccount",
                column: "IdBank");

            migrationBuilder.CreateIndex(
                name: "IX_tbAccount_IdOwner",
                table: "tbAccount",
                column: "IdOwner",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbBankStatement_AccountId",
                table: "tbBankStatement",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_tbBankStatement_OwnerId",
                table: "tbBankStatement",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_tbTransaction_BankId",
                table: "tbTransaction",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbBankStatement");

            migrationBuilder.DropTable(
                name: "tbTransaction");

            migrationBuilder.DropTable(
                name: "tbAccount");

            migrationBuilder.DropTable(
                name: "tbBank");

            migrationBuilder.DropTable(
                name: "tbOwner");
        }
    }
}

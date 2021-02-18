using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentProcessorFiled.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "paymentStates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    PayState = table.Column<byte>(nullable: false),
                    PaymentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    CreditCardNumber = table.Column<string>(maxLength: 20, nullable: false),
                    CardHolder = table.Column<string>(maxLength: 70, nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    SecurityCode = table.Column<string>(maxLength: 3, nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    PaymentStateId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_paymentStates_PaymentStateId",
                        column: x => x.PaymentStateId,
                        principalTable: "paymentStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentStateId",
                table: "Payments",
                column: "PaymentStateId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "paymentStates");
        }
    }
}

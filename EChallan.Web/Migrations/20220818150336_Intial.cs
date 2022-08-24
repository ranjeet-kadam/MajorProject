using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EChallan.Web.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    IID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Issues = table.Column<string>(maxLength: 50, nullable: false),
                    IssueDescription = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.IID);
                });

            migrationBuilder.CreateTable(
                name: "ChallaNumberDetails",
                columns: table => new
                {
                    CID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChallanNumber = table.Column<string>(nullable: false),
                    VehicalNumber = table.Column<string>(nullable: false),
                    IssueIID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallaNumberDetails", x => x.CID);
                    table.ForeignKey(
                        name: "FK_ChallaNumberDetails_Issues_IssueIID",
                        column: x => x.IssueIID,
                        principalTable: "Issues",
                        principalColumn: "IID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChallaDetails",
                columns: table => new
                {
                    CDID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CID = table.Column<int>(nullable: false),
                    IID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChallaDetails", x => x.CDID);
                    table.ForeignKey(
                        name: "FK_ChallaDetails_ChallaNumberDetails_CID",
                        column: x => x.CID,
                        principalTable: "ChallaNumberDetails",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChallaDetails_Issues_IID",
                        column: x => x.IID,
                        principalTable: "Issues",
                        principalColumn: "IID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodName = table.Column<string>(maxLength: 50, nullable: false),
                    MethodEnabled = table.Column<bool>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_ChallaDetails_Price",
                        column: x => x.Price,
                        principalTable: "ChallaDetails",
                        principalColumn: "CDID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChallaDetails_CID",
                table: "ChallaDetails",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_ChallaDetails_IID",
                table: "ChallaDetails",
                column: "IID");

            migrationBuilder.CreateIndex(
                name: "IX_ChallaNumberDetails_IssueIID",
                table: "ChallaNumberDetails",
                column: "IssueIID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_Price",
                table: "PaymentMethods",
                column: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ChallaDetails");

            migrationBuilder.DropTable(
                name: "ChallaNumberDetails");

            migrationBuilder.DropTable(
                name: "Issues");
        }
    }
}

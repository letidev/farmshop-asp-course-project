using Microsoft.EntityFrameworkCore.Migrations;

namespace FarmShop.Migrations
{
    public partial class TypesAdjust : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PriceSold",
                table: "OrderProducts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$9D0yrgSNR.orJvAaNEG3EOUllAIv9yMr4yd7YZmnr4lurZoCbOKY6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PriceSold",
                table: "OrderProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$t2Z563hcFqObsOjVYshV2OEfxcjALD3NY1Uc0cLYBULLE.8F41.7i");
        }
    }
}

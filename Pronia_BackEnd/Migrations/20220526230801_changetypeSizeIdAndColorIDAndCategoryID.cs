using Microsoft.EntityFrameworkCore.Migrations;

namespace Pronia_BackEnd.Migrations
{
    public partial class changetypeSizeIdAndColorIDAndCategoryID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Categories_CategoryId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Colors_ColorId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Sizes_SizeId",
                table: "Plants");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Plants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Categories_CategoryId",
                table: "Plants",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Colors_ColorId",
                table: "Plants",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Sizes_SizeId",
                table: "Plants",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Categories_CategoryId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Colors_ColorId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Sizes_SizeId",
                table: "Plants");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "Plants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Plants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Plants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Categories_CategoryId",
                table: "Plants",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Colors_ColorId",
                table: "Plants",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Sizes_SizeId",
                table: "Plants",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

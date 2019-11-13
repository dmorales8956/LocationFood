using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationFood.Web.Migrations
{
    public partial class CreateNewBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantImage_Restaurants_RestaurantId",
                table: "RestaurantImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantImage",
                table: "RestaurantImage");

            migrationBuilder.RenameTable(
                name: "RestaurantImage",
                newName: "RestaurantImages");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantImage_RestaurantId",
                table: "RestaurantImages",
                newName: "IX_RestaurantImages_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantImages",
                table: "RestaurantImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantImages_Restaurants_RestaurantId",
                table: "RestaurantImages",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantImages_Restaurants_RestaurantId",
                table: "RestaurantImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantImages",
                table: "RestaurantImages");

            migrationBuilder.RenameTable(
                name: "RestaurantImages",
                newName: "RestaurantImage");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantImages_RestaurantId",
                table: "RestaurantImage",
                newName: "IX_RestaurantImage_RestaurantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantImage",
                table: "RestaurantImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantImage_Restaurants_RestaurantId",
                table: "RestaurantImage",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

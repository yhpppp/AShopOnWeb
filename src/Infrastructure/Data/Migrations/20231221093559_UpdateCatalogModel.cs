using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCatalogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catalog_CatalogBrands_CatalogBrandId",
                table: "catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_catalog_CatalogTypes_CatalogTypeId",
                table: "catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_catalog",
                table: "catalog");

            migrationBuilder.RenameTable(
                name: "catalog",
                newName: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_catalog_CatalogTypeId",
                table: "Catalog",
                newName: "IX_Catalog_CatalogTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_catalog_CatalogBrandId",
                table: "Catalog",
                newName: "IX_Catalog_CatalogBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_CatalogBrands_CatalogBrandId",
                table: "Catalog",
                column: "CatalogBrandId",
                principalTable: "CatalogBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalog_CatalogTypes_CatalogTypeId",
                table: "Catalog",
                column: "CatalogTypeId",
                principalTable: "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_CatalogBrands_CatalogBrandId",
                table: "Catalog");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalog_CatalogTypes_CatalogTypeId",
                table: "Catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalog",
                table: "Catalog");

            migrationBuilder.RenameTable(
                name: "Catalog",
                newName: "catalog");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_CatalogTypeId",
                table: "catalog",
                newName: "IX_catalog_CatalogTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Catalog_CatalogBrandId",
                table: "catalog",
                newName: "IX_catalog_CatalogBrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_catalog",
                table: "catalog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_catalog_CatalogBrands_CatalogBrandId",
                table: "catalog",
                column: "CatalogBrandId",
                principalTable: "CatalogBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_catalog_CatalogTypes_CatalogTypeId",
                table: "catalog",
                column: "CatalogTypeId",
                principalTable: "CatalogTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

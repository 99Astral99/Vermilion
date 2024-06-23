using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vermilion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CateringImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("8f5a98d5-4ec8-46df-b112-28b964802e0c"));

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: new Guid("6dbae7d8-a56f-4456-b380-23806f014cc2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("51886939-d863-4454-a05a-a8fb556d0bf4"));

            migrationBuilder.AddColumn<Guid>(
                name: "CateringImageId",
                table: "DomainEvent",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CateringImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    CateringId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateringImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CateringImages_Caterings_CateringId",
                        column: x => x.CateringId,
                        principalTable: "Caterings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("dc2b11c7-466c-4df2-a0cc-7d59a7e945c9"), "Type1" });

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_CateringImageId",
                table: "DomainEvent",
                column: "CateringImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CateringImages_CateringId",
                table: "CateringImages",
                column: "CateringId");

            migrationBuilder.AddForeignKey(
                name: "FK_DomainEvent_CateringImages_CateringImageId",
                table: "DomainEvent",
                column: "CateringImageId",
                principalTable: "CateringImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DomainEvent_CateringImages_CateringImageId",
                table: "DomainEvent");

            migrationBuilder.DropTable(
                name: "CateringImages");

            migrationBuilder.DropIndex(
                name: "IX_DomainEvent_CateringImageId",
                table: "DomainEvent");

            migrationBuilder.DeleteData(
                table: "Cuisines",
                keyColumn: "Id",
                keyValue: new Guid("dc2b11c7-466c-4df2-a0cc-7d59a7e945c9"));

            migrationBuilder.DropColumn(
                name: "CateringImageId",
                table: "DomainEvent");

            migrationBuilder.InsertData(
                table: "Cuisines",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8f5a98d5-4ec8-46df-b112-28b964802e0c"), "Type1" });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6dbae7d8-a56f-4456-b380-23806f014cc2"), "Type1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Phone", "UpdatedAt" },
                values: new object[] { new Guid("51886939-d863-4454-a05a-a8fb556d0bf4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "email.com", "alex", "the terrible", "79797", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vermilion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caterings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    AverageRating = table.Column<double>(type: "double precision", nullable: false, defaultValue: 0.0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    WebSiteUrl = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caterings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DayOfWeek = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    IsDayOff = table.Column<bool>(type: "boolean", nullable: false),
                    CateringId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_Caterings_CateringId",
                        column: x => x.CateringId,
                        principalTable: "Caterings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CateringCuisine",
                columns: table => new
                {
                    CateringId = table.Column<Guid>(type: "uuid", nullable: false),
                    CuisinesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateringCuisine", x => new { x.CateringId, x.CuisinesId });
                    table.ForeignKey(
                        name: "FK_CateringCuisine_Caterings_CateringId",
                        column: x => x.CateringId,
                        principalTable: "Caterings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CateringCuisine_Cuisines_CuisinesId",
                        column: x => x.CuisinesId,
                        principalTable: "Cuisines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CateringFeature",
                columns: table => new
                {
                    CateringId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeaturesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateringFeature", x => new { x.CateringId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_CateringFeature_Caterings_CateringId",
                        column: x => x.CateringId,
                        principalTable: "Caterings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CateringFeature_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CateringId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Caterings_CateringId",
                        column: x => x.CateringId,
                        principalTable: "Caterings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CateringId = table.Column<Guid>(type: "uuid", nullable: true),
                    CuisineId = table.Column<Guid>(type: "uuid", nullable: true),
                    FeatureId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkScheduleId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainEvent_Caterings_CateringId",
                        column: x => x.CateringId,
                        principalTable: "Caterings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DomainEvent_Cuisines_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "Cuisines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DomainEvent_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DomainEvent_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DomainEvent_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DomainEvent_WorkSchedules_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "WorkSchedules",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CateringCuisine_CuisinesId",
                table: "CateringCuisine",
                column: "CuisinesId");

            migrationBuilder.CreateIndex(
                name: "IX_CateringFeature_FeaturesId",
                table: "CateringFeature",
                column: "FeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_Caterings_Address",
                table: "Caterings",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Caterings_Name",
                table: "Caterings",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_CateringId",
                table: "DomainEvent",
                column: "CateringId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_CuisineId",
                table: "DomainEvent",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_FeatureId",
                table: "DomainEvent",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_ReviewId",
                table: "DomainEvent",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_UserId",
                table: "DomainEvent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_WorkScheduleId",
                table: "DomainEvent",
                column: "WorkScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CateringId",
                table: "Reviews",
                column: "CateringId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_CateringId",
                table: "WorkSchedules",
                column: "CateringId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_DayOfWeek",
                table: "WorkSchedules",
                column: "DayOfWeek",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CateringCuisine");

            migrationBuilder.DropTable(
                name: "CateringFeature");

            migrationBuilder.DropTable(
                name: "DomainEvent");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WorkSchedules");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Caterings");
        }
    }
}

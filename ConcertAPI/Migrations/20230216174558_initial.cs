using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConcertAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PreformerCategory = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PreformerCategory = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BandModelMusicianModel",
                columns: table => new
                {
                    BandsId = table.Column<int>(type: "int", nullable: false),
                    MusiciansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandModelMusicianModel", x => new { x.BandsId, x.MusiciansId });
                    table.ForeignKey(
                        name: "FK_BandModelMusicianModel_Bands_BandsId",
                        column: x => x.BandsId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BandModelMusicianModel_Musicians_MusiciansId",
                        column: x => x.MusiciansId,
                        principalTable: "Musicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ConcertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcertGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concerts_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Bio", "FullName", "PreformerCategory", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { 5, "Great band, been together for years.", "Barenaked Ladies", 1, "https://www.barenakedladies.com/wp-content/uploads/2015/05/large.scyd5regTuwzFP5b4C-t66Qz7O_ftON3oFMxT1lWFUg-300x300.jpg" },
                    { 6, "Good solid music, for a simple evening.", "Two Friends", 2, "https://cdn.shopify.com/s/files/1/0015/2708/7192/products/DMYourCrush_1_2186932c-3e15-481b-9849-a2fb91b2def2_800x.png?v=1664902157" },
                    { 7, "Great Punck Rock Band", "Hippo Campusip", 4, "https://cdn.shopify.com/s/files/1/0219/6940/products/CD_MOCK_square_1024x1024.jpg?v=1623341625" }
                });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "Id", "Bio", "FullName", "PreformerCategory", "ProfilePictureUrl" },
                values: new object[,]
                {
                    { 1, "Punk musician played with Hippo Campusip in concerts", "Gus Dapperton", 4, "https://www.gusdapperton.com/sites/g/files/g2000015461/files/2022-10/artwork-440x440.jpg" },
                    { 2, "Punk musician", "Hippo Smith", 4, "https://www.gusdapperton.com/sites/g/files/g2000015461/files/2022-10/artwork-440x440.jpg" },
                    { 3, "Great country singer", "Johnny Cash", 2, "https://books.google.com/books/content?id=yL6MRZfrWjkC&pg=PP1&img=1&zoom=3&hl=en&bul=1&sig=ACfU3U02TmfmNvXIpXhrD026A0Nktcb3zw&w=1280" },
                    { 4, "Great country singer", "Jimmy Buffett", 2, "http://t1.gstatic.com/licensed-image?q=tbn:ANd9GcQD84Z5E5op_ZJJNwOl4W-YSizPPEAE9mZc7aTI8CNnfCA3Mzbi_DI_H7NxT-b8A6CiAai85Fla0ud_ZM4" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "LogoURL", "Name" },
                values: new object[,]
                {
                    { 1, "https://lh3.googleusercontent.com/p/AF1QipOCzZhPE1I7VOx6sqrXTbaaE9DZm2lYkrHYPzCF=s680-w680-h510", "KEMBA Live!" },
                    { 2, "https://lh3.googleusercontent.com/p/AF1QipOC8C3lLf-X-4yMGvg-GTNrg3bWMXDLWdj1LOnx=s680-w680-h510", "Newport Music Hall" },
                    { 3, "https://lh3.googleusercontent.com/p/AF1QipOC8C3lLf-X-4yMGvg-GTNrg3bWMXDLWdj1LOnx=s680-w680-h510", "Blossom Music Center" }
                });

            migrationBuilder.InsertData(
                table: "Concerts",
                columns: new[] { "Id", "ConcertDate", "ConcertGenre", "Description", "ImageURL", "Name", "Price", "VenueId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 4, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, "This is a good ole boys concert", "https://images.pexels.com/photos/1105666/pexels-photo-1105666.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Big Concert at the River", 10.0, 1 },
                    { 2, new DateTime(2023, 7, 8, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, "This is a good ole boys concert", "https://images.pexels.com/photos/1190297/pexels-photo-1190297.jpeg", "Concert at the Beach", 10.0, 2 },
                    { 3, new DateTime(2023, 8, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, "This is a good ole boys concert", "https://images.pexels.com/photos/995301/pexels-photo-995301.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Concert at the Beach", 10.0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BandModelMusicianModel_MusiciansId",
                table: "BandModelMusicianModel",
                column: "MusiciansId");

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_VenueId",
                table: "Concerts",
                column: "VenueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandModelMusicianModel");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Bands");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}

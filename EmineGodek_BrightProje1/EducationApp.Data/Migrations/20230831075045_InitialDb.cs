using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EducationApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    OrderStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    BirthOfYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    About = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    PhotoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Time = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    InstructorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "099df881-2a3e-4fe7-948b-54dd633fb2a8", null, "Diğer tüm kullanıcıların rolü bu.", "User", "USER" },
                    { "38464a90-b884-422c-a94f-2770354d0d49", null, "Yöneticilerin rolü bu.", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae64f068-85a5-4c70-ad59-90b7b5646781", 0, "Beykoz", "İstanbul", "cf783194-a1b6-4940-99f8-ede6c56262bd", new DateTime(1998, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "eminegodekk@gmail.com", true, "Emine", "KADIN", "GÖDEK", true, null, " ", "EMINEGODEKK@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEB4KMdXskmBeX8h2zzmrT84ydcHhB2ZXipDRxg8xovFrnrvz/jXWQiH4OnpyPKen+w==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9375), "Türk Mutfağının bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.", true, false, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9383), "Türk Mutfağı", "turk-mutfagi" },
                    { 2, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9387), "Uzak Doğunun bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.", true, false, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9387), "Uzak Doğu", "uzak-dogu" },
                    { 3, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9388), "Kalabalık gruplarla eğitimlere katılarak eşsiz anılar oluşturacaksınız.", true, false, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9389), "Kalabalık Sofra", "kalabalik-sofra" },
                    { 4, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9390), "En renkli tatlılar kutlama yemeklerinizin favorisi olacak.", true, false, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9390), "Pastacılık", "pastacilik" },
                    { 5, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9391), "İyi pişmiş bir et menüsünden daha iyi çok az şey vardır.", true, false, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9392), "Etler", "etler" },
                    { 6, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9393), "El açması hamur işleri için komşunuz yardımınızı isteyecek.", true, false, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9393), "Hamur İşleri", "hamur-isleri" },
                    { 7, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9394), "Evinizde kendi kafenizi kurun.", true, false, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(9394), "Kahveler", "kahveler" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "About", "BirthOfYear", "CreatedDate", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedDate", "PhotoUrl", "ProductId", "ProductId1", "Url" },
                values: new object[,]
                {
                    { 1, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1990, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2127), "Dominic", true, false, "Harmon", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2134), "1.png", 1, null, null },
                    { 2, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1990, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2141), "Justina", true, false, "Burch", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2141), "1.png", 2, null, null },
                    { 3, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1985, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2143), "Madison", true, false, "Beard", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2143), "1.png", 3, null, null },
                    { 4, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1982, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2145), "Sara", true, false, "Wade", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2146), "1.png", 4, null, null },
                    { 5, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1988, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2147), "Jacob", true, false, "Hunt", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2148), "1.png", 5, null, null },
                    { 6, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1989, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2149), "Osamu", true, false, "Dazai", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2149), "1.png", 6, null, null },
                    { 7, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1983, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2151), "Zachery", true, false, "Salas", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2152), "1.png", 7, null, null },
                    { 8, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1982, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2153), "Matt", true, false, "Haig", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2153), "1.png", 8, null, null },
                    { 9, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1982, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2155), "William", true, false, "Hawkingan", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2155), "1.png", 9, null, null },
                    { 10, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1990, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2156), "Geraldine", true, false, "Richmond", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2157), "1.png", 10, null, null },
                    { 11, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1983, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2158), "Steffan", true, false, "Ros", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2158), "1.png", 11, null, null },
                    { 12, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1991, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2160), "Nichole", true, false, "Talley", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2160), "1.png", 12, null, null },
                    { 13, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1979, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2161), "Yetta", true, false, "Sheppard", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2162), "1.png", 13, null, null },
                    { 14, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1978, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2163), "Elijah", true, false, "Farley", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2163), "1.png", 14, null, null },
                    { 15, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1991, new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2165), "Neil", true, false, "Wooten", new DateTime(2023, 8, 31, 10, 50, 45, 288, DateTimeKind.Local).AddTicks(2165), "1.png", 15, null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "38464a90-b884-422c-a94f-2770354d0d49", "ae64f068-85a5-4c70-ad59-90b7b5646781" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "UserId" },
                values: new object[] { 1, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(4366), true, false, new DateTime(2023, 8, 31, 10, 50, 45, 287, DateTimeKind.Local).AddTicks(4381), "ae64f068-85a5-4c70-ad59-90b7b5646781" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "InstructorId", "IsActive", "IsDeleted", "IsHome", "ModifiedDate", "Name", "Price", "Time", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(501), "Türk Mutfağının bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.", "14.jpg", 1, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(505), "Türk Mutfağı", 100m, 200, "turk-mutfagi" },
                    { 2, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(511), "Uzak Doğunun bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.", "12.jpg", 2, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(511), "Uzak Doğu", 100m, 200, "java" },
                    { 3, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(541), "Kalabalık gruplarla eğitimlere katılarak eşsiz anılar oluşturacaksınız", "3.jpg", 3, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(541), "Kalabalık Sofra", 100m, 200, "kalabalik-sofra" },
                    { 4, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(543), "En renkli tatlılar kutlama yemeklerinizin favorisi olacak.", "6.jpg", 4, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(543), "Pastacılık", 100m, 200, "pastacilik" },
                    { 5, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(545), "İyi pişmiş bir et menüsünden daha iyi çok az şey vardır.", "10.jpg", 5, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(546), "Etler", 100m, 200, "etler" },
                    { 6, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(547), "El açması hamur işleri için komşunuz yardımınızı isteyecek.", "7.jpg", 6, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(548), "Hamur İşleri", 100m, 200, "hamur-isleri" },
                    { 7, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(549), "Evinizde kendi kafenizi kurun.", "9.jpg", 7, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(550), "Kahveler", 100m, 200, "kahveler" },
                    { 8, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(551), "Türk Mutfağının bir birinden eşsiz lezzetleriyle sofralarınıza lezzet katacaksınız.", "1.jpg", 8, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(552), "Türk Mutfağı", 100m, 200, "turk-mutfagi" },
                    { 9, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(554), "El açması hamur işleri için komşunuz yardımınızı isteyecek.", "2.jpg", 9, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(554), "Hamur İşleri", 100m, 200, "hamur-isleri" },
                    { 10, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(556), "En renkli tatlılar kutlama yemeklerinizin favorisi olacak.", "8.jpg", 10, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(556), "Pastacılık", 100m, 200, "pastacilik" },
                    { 11, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(559), "El açması hamur işleri için komşunuz yardımınızı isteyecek.", "11.jpg", 11, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(559), "Hamur İşleri", 100m, 200, "hamur-isleri" },
                    { 12, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(561), "En renkli tatlılar kutlama yemeklerinizin favorisi olacak.", "13.png", 12, true, false, true, new DateTime(2023, 8, 31, 10, 50, 45, 290, DateTimeKind.Local).AddTicks(561), "Pastacılık", 100m, 200, "pastacilik" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 1, 8 },
                    { 6, 9 },
                    { 4, 10 },
                    { 6, 11 },
                    { 4, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_ProductId1",
                table: "Instructors",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InstructorId",
                table: "Products",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Products_ProductId1",
                table: "Instructors",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Products_ProductId1",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smarest.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Total = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ItemId = table.Column<string>(nullable: true),
                    ItemQuantity = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    TableId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ItemId = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "TableName", "UserId" },
                values: new object[,]
                {
                    { "dbe3d202-7aa8-4c50-ab5b-1d22774cb5d5", new DateTime(2023, 10, 7, 21, 12, 10, 519, DateTimeKind.Local).AddTicks(9019), null, null },
                    { "a60d426c-e89a-48ee-bff9-58d8ae3cccd8", new DateTime(2023, 10, 8, 21, 12, 10, 519, DateTimeKind.Local).AddTicks(9400), null, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "101", "Food" },
                    { "102", "Drink" },
                    { "103", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "100", "6f2c8359-4e62-4c9a-a3bf-00b753173ce4", "Role", "Admin", "ADMIN" },
                    { "101", "2b7e71e0-0395-4c29-aafb-a3ecfeb8ce2f", "Role", "Manager", "MANAGER" },
                    { "102", "956986e3-edfc-4177-aca2-a0ee45906396", "Role", "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsAvailable", "Name" },
                values: new object[,]
                {
                    { "7cb13f6d-6f59-4fb7-b357-6eb43df59a55", true, "Table 1" },
                    { "9fa96f9a-5e4b-48c2-a055-e1f65b047257", true, "Table 2" },
                    { "9580fa2b-5694-4ba3-9266-1cfda7287fb3", true, "Table 3" },
                    { "4ac52103-72df-45fb-9b5e-93eb052226fd", true, "Table 4" },
                    { "1b201cef-2203-4d5b-8317-ef9dce80ac70", true, "Table 5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "CreatedDate", "FirstName", "LastName", "RefreshToken" },
                values: new object[,]
                {
                    { "201", 0, "93f35d99-ce7c-4add-8241-a886dcac7533", "User", "Admin201@gmail.com", false, false, null, "ADMIN201@GMAIL.COM", "ADMIN201@GMAIL.COM", "AQAAAAEAACcQAAAAEGulghiJ9xIrOE8xTxxzVtD5OJkzfwW96LumTFU//5hVLmLSDgUdKkFPqf5qYQDCFg==", null, false, "4c2d2300-21fb-4c26-bd2d-03287347e685", false, "Admin201@gmail.com", new DateTime(2023, 10, 5, 21, 12, 10, 505, DateTimeKind.Local).AddTicks(7786), "Ngoc Huy", "Bui", null },
                    { "202", 0, "bd100e85-4960-4d06-bb3c-5148712201ac", "User", "Manager202@gmail.com", false, false, null, "MANAGER202@GMAIL.COM", "MANAGER202@GMAIL.COM", "AQAAAAEAACcQAAAAEPsrnyXHwjVnD6sCOjkrMTRkVk/sfuWF0QuCjp3WSUaSU82s17dOu4FKVWbf6HaH7w==", null, false, "d8476147-404d-4dcc-be77-f0ff9270b283", false, "Manager202@gmail.com", new DateTime(2023, 10, 5, 21, 12, 10, 512, DateTimeKind.Local).AddTicks(3031), "Thanh Binh", "Phan", null },
                    { "203", 0, "7c8568ac-38a1-484c-8c53-0e090bb80b81", "User", "Guest203@gmail.com", false, false, null, "GUEST203@GMAIL.COM", "GUEST203@GMAIL.COM", "AQAAAAEAACcQAAAAECzEb2WXADqeQKx7xmP/Mtln/zfcSLz/WGmVO5poc4xM1xQolwg0WiXSfZMPBfFOaw==", null, false, "93ddb9b6-b0c9-49ef-929f-be6d3f90d115", false, "Guest203@gmail.com", new DateTime(2023, 10, 5, 21, 12, 10, 518, DateTimeKind.Local).AddTicks(1381), "Hoai Anh", "Bui Ngoc", null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Cost", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { "e79d714f-4cb6-4f91-baee-f0ee2ab14f3f", "101", 30.5, "https://www.jessicagavin.com/wp-content/uploads/2018/09/fried-rice-8-1200.jpg", "Fried rice" },
                    { "66e43535-dc15-415d-b8dd-ae627e34527e", "101", 30.5, "https://www.allrecipes.com/thmb/r29Rv3SakBBaqpbOZu4fHibsf8k=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/236992-santa-maria-grilled-tri-tip-beef-ddmfs-1x1-1-517a088b88a8431c8a41b81c1e978758.jpg", "Santa Maria Grilled Tri-Tip Beef" },
                    { "9641de9b-c718-4430-adfa-0583bfb53e31", "101", 304.5, "https://www.giallozafferano.com/images/228-22832/spaghetti-with-tomato-sauce_1200x800.jpg", "Spaghetti al pomodoro" },
                    { "68f59a27-de01-4105-8e11-b2492bb31902", "101", 312.5, "https://www.checkyourfood.com/content/blob/Meals/Turkey-and-ham-pie-recipe-calories-nutrition-facts.jpg", "Turkey and ham pie" },
                    { "a4dec8d1-ff6c-4b6a-ba23-e0c63e05012e", "101", 124.5, "https://www.thespruceeats.com/thmb/ZmXhBNNc9tFWwnDHTUGFsRCIcrk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/slow-roasted-pork-belly-crispy-skin-3059509-7_preview-5b16dcbb1d6404003605a196.jpeg", "Crispy pork" },
                    { "12953128-60f2-454a-87a1-011854206005", "101", 747.5, "https://properfoodie.com/wp-content/uploads/2021/04/square-Steak-and-chips-8.jpg", "Steak with chips" },
                    { "7ceb6584-70b1-4192-9955-f8ec1eeedd02", "102", 12.5, "https://cf.shopee.vn/file/bacb189db5215ac1f25033d76b6c6add", "Coca" },
                    { "e4770043-bfbe-4cf3-b4ab-642a068d2144", "102", 13.5, "https://www.pepsi.com/en-us/uploads/images/twil-can.png", "Pepsi" },
                    { "773bf01a-c7f1-4922-85e1-99d048c0652b", "103", 10.0, "https://www.intour.com.vn/upload/2021/03/thumbs/chuyen-san-xuat-khan-uot-kham-lanh-omi-gia-tot-nhat-vn-2.jpg", "Tissue" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "201", "100" },
                    { "201", "101" },
                    { "201", "102" },
                    { "202", "101" },
                    { "202", "102" },
                    { "203", "102" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ItemId",
                table: "Carts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_TableId",
                table: "Carts",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

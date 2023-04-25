using Microsoft.EntityFrameworkCore.Migrations;

namespace Smarest.Migrations
{
    public partial class fixtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Users_UserId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_UserId",
                table: "Tables");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "051d64ee-8fde-4e78-ad42-b023bc74543f");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "265e6111-45d9-49b8-afaa-e234a847587a");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "3c3a68bc-485f-4ab6-9764-7c3d5fe4f8b5");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "53afef5c-d1e1-420e-a12c-4085dbc48d4f");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "7ad67ccc-24b6-4a9a-b754-716a7cfff389");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "7cbe5b1c-1a47-4efb-8b85-0f9854ff3336");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "b94f0fda-91c2-47b8-bf60-b9aafed334da");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "e701fe8c-ff22-49f7-a3d3-4f34d7e7496a");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "ebde0881-3235-4a5b-aaea-71c522d4a5c5");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "01240f0e-82b8-4e63-b9ba-96c0eea537cb");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "163ad111-dfde-4b11-8646-414d1c14151c");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "446f7dd9-3643-4184-a86e-6d5f18b65f26");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "5dc0b1b8-ecf0-4b77-9f4c-25bdede53e0e");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "b5ca2ee9-2295-466a-b096-4ed90c698acd");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tables");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Tables",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Cost", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { "b2b8359c-f938-49d9-aba5-8907a9e0134b", "101", 30.5, "https://www.jessicagavin.com/wp-content/uploads/2018/09/fried-rice-8-1200.jpg", "Fried rice" },
                    { "78e1d8e8-d275-4c06-827c-57e53f8fd281", "101", 30.5, "https://www.allrecipes.com/thmb/r29Rv3SakBBaqpbOZu4fHibsf8k=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/236992-santa-maria-grilled-tri-tip-beef-ddmfs-1x1-1-517a088b88a8431c8a41b81c1e978758.jpg", "Santa Maria Grilled Tri-Tip Beef" },
                    { "b5dec252-7317-46b5-9a27-5898ed448c1e", "102", 12.5, "https://cf.shopee.vn/file/bacb189db5215ac1f25033d76b6c6add", "Coca" },
                    { "00510ae5-929b-4560-bb1d-1e536f7589f8", "102", 13.5, "https://www.pepsi.com/en-us/uploads/images/twil-can.png", "Pepsi" },
                    { "aae6f85f-ca9e-4ec4-990f-9574291ae6a6", "103", 10.0, "https://www.intour.com.vn/upload/2021/03/thumbs/chuyen-san-xuat-khan-uot-kham-lanh-omi-gia-tot-nhat-vn-2.jpg", "Tissue" },
                    { "fb3d4aec-6175-4471-8acd-c05c21ae703f", "101", 304.5, "https://www.giallozafferano.com/images/228-22832/spaghetti-with-tomato-sauce_1200x800.jpg", "Spaghetti al pomodoro" },
                    { "af7e7840-33fd-47e8-95f5-d831f32b2de4", "101", 312.5, "https://www.checkyourfood.com/content/blob/Meals/Turkey-and-ham-pie-recipe-calories-nutrition-facts.jpg", "Turkey and ham pie" },
                    { "7d180003-d512-44ad-b9e8-571bc3aa8c5d", "101", 124.5, "https://www.thespruceeats.com/thmb/ZmXhBNNc9tFWwnDHTUGFsRCIcrk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/slow-roasted-pork-belly-crispy-skin-3059509-7_preview-5b16dcbb1d6404003605a196.jpeg", "Crispy pork" },
                    { "e1ffbda1-5f45-48ff-9faf-d83d7249ecb9", "101", 747.5, "https://properfoodie.com/wp-content/uploads/2021/04/square-Steak-and-chips-8.jpg", "Steak with chips" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "100",
                column: "ConcurrencyStamp",
                value: "6e86d41d-f63c-4bac-812f-66ed02616a60");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "101",
                column: "ConcurrencyStamp",
                value: "d02b23d0-d020-4d9b-8111-000f0a20ad0e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "102",
                column: "ConcurrencyStamp",
                value: "c5b40808-efaf-400d-855b-ac5f5c37ac1f");

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsAvailable", "Name" },
                values: new object[,]
                {
                    { "32bbd24d-5e82-454f-91eb-58e01f184656", false, "Table 4" },
                    { "49effc61-d326-4f3a-b7fa-e88afef17c5b", false, "Table 5" },
                    { "571706ef-31ea-4f31-b959-ccc99d6c0925", false, "Table 2" },
                    { "41c2759b-9412-43cb-af7e-1400e4d16ce0", false, "Table 3" },
                    { "6e40aa36-cd40-4197-bac9-ac6284e0522b", false, "Table 1" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "201",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd8f6265-ee62-41a0-b994-a78db1fa7c31", "AQAAAAEAACcQAAAAECYvI2lu86lQJLKGG71GipRCLdGc4oQ6UnojcprgvcuWIjL59D9DqiJwquwzPduAHg==", "6d3de083-234b-42d8-ab78-14f56f400815" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "202",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60f23382-6601-4581-a33e-23f9f1f13829", "AQAAAAEAACcQAAAAEJb6Fx5if8iUYChRPwv7pCA6ARUwOV2HFL9EP2Pjg33q5lyYPNSn25+po7/acJt/zw==", "c7701d96-598e-4fac-af0f-a196c912f620" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "203",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edeb7c7e-db71-4596-8798-d0cd7f35a7cd", "AQAAAAEAACcQAAAAEIxp20ti7Ro6O8SQ95+gtvhClnR+EylMG8VA6OT4UgRfa+8BjI+0I3zu7uTM8OOUNw==", "b5f4887e-3b1f-44a0-bbe2-c3643f45bb72" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "00510ae5-929b-4560-bb1d-1e536f7589f8");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "78e1d8e8-d275-4c06-827c-57e53f8fd281");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "7d180003-d512-44ad-b9e8-571bc3aa8c5d");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "aae6f85f-ca9e-4ec4-990f-9574291ae6a6");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "af7e7840-33fd-47e8-95f5-d831f32b2de4");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "b2b8359c-f938-49d9-aba5-8907a9e0134b");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "b5dec252-7317-46b5-9a27-5898ed448c1e");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "e1ffbda1-5f45-48ff-9faf-d83d7249ecb9");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "fb3d4aec-6175-4471-8acd-c05c21ae703f");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "32bbd24d-5e82-454f-91eb-58e01f184656");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "41c2759b-9412-43cb-af7e-1400e4d16ce0");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "49effc61-d326-4f3a-b7fa-e88afef17c5b");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "571706ef-31ea-4f31-b959-ccc99d6c0925");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "6e40aa36-cd40-4197-bac9-ac6284e0522b");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Tables");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Tables",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Cost", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { "53afef5c-d1e1-420e-a12c-4085dbc48d4f", "101", 30.5, "https://www.jessicagavin.com/wp-content/uploads/2018/09/fried-rice-8-1200.jpg", "Fried rice" },
                    { "7cbe5b1c-1a47-4efb-8b85-0f9854ff3336", "101", 30.5, "https://www.allrecipes.com/thmb/r29Rv3SakBBaqpbOZu4fHibsf8k=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/236992-santa-maria-grilled-tri-tip-beef-ddmfs-1x1-1-517a088b88a8431c8a41b81c1e978758.jpg", "Santa Maria Grilled Tri-Tip Beef" },
                    { "e701fe8c-ff22-49f7-a3d3-4f34d7e7496a", "102", 12.5, "https://cf.shopee.vn/file/bacb189db5215ac1f25033d76b6c6add", "Coca" },
                    { "265e6111-45d9-49b8-afaa-e234a847587a", "102", 13.5, "https://www.pepsi.com/en-us/uploads/images/twil-can.png", "Pepsi" },
                    { "7ad67ccc-24b6-4a9a-b754-716a7cfff389", "103", 10.0, "https://www.intour.com.vn/upload/2021/03/thumbs/chuyen-san-xuat-khan-uot-kham-lanh-omi-gia-tot-nhat-vn-2.jpg", "Tissue" },
                    { "3c3a68bc-485f-4ab6-9764-7c3d5fe4f8b5", "101", 304.5, "https://www.giallozafferano.com/images/228-22832/spaghetti-with-tomato-sauce_1200x800.jpg", "Spaghetti al pomodoro" },
                    { "b94f0fda-91c2-47b8-bf60-b9aafed334da", "101", 312.5, "https://www.checkyourfood.com/content/blob/Meals/Turkey-and-ham-pie-recipe-calories-nutrition-facts.jpg", "Turkey and ham pie" },
                    { "ebde0881-3235-4a5b-aaea-71c522d4a5c5", "101", 124.5, "https://www.thespruceeats.com/thmb/ZmXhBNNc9tFWwnDHTUGFsRCIcrk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/slow-roasted-pork-belly-crispy-skin-3059509-7_preview-5b16dcbb1d6404003605a196.jpeg", "Crispy pork" },
                    { "051d64ee-8fde-4e78-ad42-b023bc74543f", "101", 747.5, "https://properfoodie.com/wp-content/uploads/2021/04/square-Steak-and-chips-8.jpg", "Steak with chips" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "100",
                column: "ConcurrencyStamp",
                value: "733b7c29-3424-4a40-94b3-c4afed6154ce");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "101",
                column: "ConcurrencyStamp",
                value: "cd81aa1f-d57c-4184-8b29-6cfa31e305dc");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "102",
                column: "ConcurrencyStamp",
                value: "d8524aa4-1bd0-47b1-8802-af15d3ad4eb2");

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { "b5ca2ee9-2295-466a-b096-4ed90c698acd", "Table 4", null },
                    { "5dc0b1b8-ecf0-4b77-9f4c-25bdede53e0e", "Table 5", null },
                    { "163ad111-dfde-4b11-8646-414d1c14151c", "Table 2", null },
                    { "446f7dd9-3643-4184-a86e-6d5f18b65f26", "Table 3", null },
                    { "01240f0e-82b8-4e63-b9ba-96c0eea537cb", "Table 1", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "201",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7920ecf0-4b9e-4c18-9b08-5b476422e8ff", "AQAAAAEAACcQAAAAEEMrsUBI34vf4UuuIPlKxuylf9YOPsa5jD02mEVNYdcg+wIG9VPRyrgCbjI2AMNjOA==", "e8f10108-95a0-47ad-8ad6-e2d03a22fad8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "202",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b92e75f-71f5-4109-a943-de01c28a4da7", "AQAAAAEAACcQAAAAEAF+BrYLqBa1qa0NPfJRvT/Ot3qru1XhcomJO2+FwFaG7MWrEEqrxjC54mWjEXh/pA==", "fbe35fdf-dead-4157-831d-168ce38ea689" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "203",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abba4846-b360-4508-b6ae-8c5d3009ab4f", "AQAAAAEAACcQAAAAEMNS6xRYKdoLTapMPaciZvoXd4+BWkkxHOzWNL3gWqMbPBiNU2vLYnrVqWe+BJolmA==", "c0c3e483-d2a1-4e7b-ac22-1cb7189da688" });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_UserId",
                table: "Tables",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Users_UserId",
                table: "Tables",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

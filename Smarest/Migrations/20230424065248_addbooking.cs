using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smarest.Migrations
{
    public partial class addbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "UserId" },
                values: new object[,]
                {
                    { "2463e8a2-bd02-47b2-be89-6fb6e2fb7fc3", new DateTime(2023, 4, 26, 13, 52, 48, 100, DateTimeKind.Local).AddTicks(2472), null },
                    { "5488b674-372f-415c-8b6f-196b5067ddfe", new DateTime(2023, 4, 27, 13, 52, 48, 100, DateTimeKind.Local).AddTicks(9705), null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Cost", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { "20673f86-7313-49ae-b12b-38dd57fe9a0c", "101", 124.5, "https://www.thespruceeats.com/thmb/ZmXhBNNc9tFWwnDHTUGFsRCIcrk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/slow-roasted-pork-belly-crispy-skin-3059509-7_preview-5b16dcbb1d6404003605a196.jpeg", "Crispy pork" },
                    { "b7fee914-670a-4488-be98-534a335e4922", "101", 312.5, "https://www.checkyourfood.com/content/blob/Meals/Turkey-and-ham-pie-recipe-calories-nutrition-facts.jpg", "Turkey and ham pie" },
                    { "8d85eb3b-df2d-4803-83b0-bdbdba8f5df6", "101", 304.5, "https://www.giallozafferano.com/images/228-22832/spaghetti-with-tomato-sauce_1200x800.jpg", "Spaghetti al pomodoro" },
                    { "418dca2b-3d3f-46e6-bb94-37d4fe153f69", "103", 10.0, "https://www.intour.com.vn/upload/2021/03/thumbs/chuyen-san-xuat-khan-uot-kham-lanh-omi-gia-tot-nhat-vn-2.jpg", "Tissue" },
                    { "5e4a0313-ad60-4150-8f76-1d2775478df7", "101", 747.5, "https://properfoodie.com/wp-content/uploads/2021/04/square-Steak-and-chips-8.jpg", "Steak with chips" },
                    { "773f1f6d-dceb-4188-ae50-4f687573061a", "102", 12.5, "https://cf.shopee.vn/file/bacb189db5215ac1f25033d76b6c6add", "Coca" },
                    { "91aa9da8-c06c-4aa8-8392-9531abb8822f", "101", 30.5, "https://www.allrecipes.com/thmb/r29Rv3SakBBaqpbOZu4fHibsf8k=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/236992-santa-maria-grilled-tri-tip-beef-ddmfs-1x1-1-517a088b88a8431c8a41b81c1e978758.jpg", "Santa Maria Grilled Tri-Tip Beef" },
                    { "b41404b5-9a6a-48d7-9251-b0e0b357fe16", "101", 30.5, "https://www.jessicagavin.com/wp-content/uploads/2018/09/fried-rice-8-1200.jpg", "Fried rice" },
                    { "638700fa-036f-412b-aecf-58f85ffe0b8b", "102", 13.5, "https://www.pepsi.com/en-us/uploads/images/twil-can.png", "Pepsi" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "100",
                column: "ConcurrencyStamp",
                value: "bfd85e59-dca1-4c99-a9e7-ca16f1b5cddb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "101",
                column: "ConcurrencyStamp",
                value: "ddc0d6f5-b2fc-471a-8189-6f6c64d31e7d");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "102",
                column: "ConcurrencyStamp",
                value: "a2a163dd-1d9c-4a83-86f5-8279677d60b0");

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsAvailable", "Name" },
                values: new object[,]
                {
                    { "b3e8b460-fdb4-4ca0-af1f-70afe0451422", false, "Table 1" },
                    { "eab6bceb-9ec2-40fe-9c8b-9a8c111ef984", false, "Table 2" },
                    { "c9aecd73-361e-47c7-9c24-c3469aeef1f2", false, "Table 3" },
                    { "aa5cbfcc-b55c-4755-b911-f5b49fe7557a", false, "Table 4" },
                    { "29dc864e-2784-432b-bd8c-96c22c0e6a36", false, "Table 5" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "201",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bfce6a6-487b-4fb9-bc94-d413d261f1ef", "AQAAAAEAACcQAAAAEGLde9pSP9yHzl+oyTROqUnJv3YL8G/WEyRa10wqeEB9lHngoOFGGZaZG2E3dvwU5Q==", "3bcaf869-501b-4c0a-a1f5-02993173cf7f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "202",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5072b4fc-cbff-420c-8031-291fd71a1b47", "AQAAAAEAACcQAAAAEBxTEBhO3JxRNm9DLcUBpBCsSkPTuggnBws6MnZd4pn1KKX4mrzZr5wmCo/rzEBMpQ==", "33151862-4e65-4ae1-b266-d2578b7c9111" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "203",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8fd87f6-9249-483f-b1e2-a394efd15bb1", "AQAAAAEAACcQAAAAEONAEcSnPuHCbs0qTUknaoBUVJXXvvTcqEA/iCgLFZrxf/6D5i6W3xQX+LE9cBmRXQ==", "bb049282-495f-41d8-a5d3-d08ac4ed9e99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "2463e8a2-bd02-47b2-be89-6fb6e2fb7fc3");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "5488b674-372f-415c-8b6f-196b5067ddfe");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "20673f86-7313-49ae-b12b-38dd57fe9a0c");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "418dca2b-3d3f-46e6-bb94-37d4fe153f69");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "5e4a0313-ad60-4150-8f76-1d2775478df7");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "638700fa-036f-412b-aecf-58f85ffe0b8b");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "773f1f6d-dceb-4188-ae50-4f687573061a");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "8d85eb3b-df2d-4803-83b0-bdbdba8f5df6");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "91aa9da8-c06c-4aa8-8392-9531abb8822f");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "b41404b5-9a6a-48d7-9251-b0e0b357fe16");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "b7fee914-670a-4488-be98-534a335e4922");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "29dc864e-2784-432b-bd8c-96c22c0e6a36");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "aa5cbfcc-b55c-4755-b911-f5b49fe7557a");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "b3e8b460-fdb4-4ca0-af1f-70afe0451422");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "c9aecd73-361e-47c7-9c24-c3469aeef1f2");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "eab6bceb-9ec2-40fe-9c8b-9a8c111ef984");

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
    }
}

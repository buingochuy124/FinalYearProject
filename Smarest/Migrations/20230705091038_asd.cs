using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smarest.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "TableName",
                table: "Bookings",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "TableName", "UserId" },
                values: new object[,]
                {
                    { "d0753c5f-bfd8-4da5-912c-d7d2888d02cb", new DateTime(2023, 7, 7, 16, 10, 37, 725, DateTimeKind.Local).AddTicks(6351), null, null },
                    { "2f879a2f-39f5-44f2-a266-8611177839e7", new DateTime(2023, 7, 8, 16, 10, 37, 726, DateTimeKind.Local).AddTicks(2596), null, null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Cost", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { "af660623-c3c9-4c23-b85c-43bfd688a1a8", "101", 124.5, "https://www.thespruceeats.com/thmb/ZmXhBNNc9tFWwnDHTUGFsRCIcrk=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/slow-roasted-pork-belly-crispy-skin-3059509-7_preview-5b16dcbb1d6404003605a196.jpeg", "Crispy pork" },
                    { "0726d553-26f3-4791-894b-25c6806780b6", "101", 312.5, "https://www.checkyourfood.com/content/blob/Meals/Turkey-and-ham-pie-recipe-calories-nutrition-facts.jpg", "Turkey and ham pie" },
                    { "2259accd-2a7a-43cc-87b8-eb5b9e2ac854", "101", 304.5, "https://www.giallozafferano.com/images/228-22832/spaghetti-with-tomato-sauce_1200x800.jpg", "Spaghetti al pomodoro" },
                    { "c4d6a25c-e920-42c5-ab15-5b3c62c405e2", "103", 10.0, "https://www.intour.com.vn/upload/2021/03/thumbs/chuyen-san-xuat-khan-uot-kham-lanh-omi-gia-tot-nhat-vn-2.jpg", "Tissue" },
                    { "26523f43-715c-47aa-9a0d-9c33a393642d", "101", 747.5, "https://properfoodie.com/wp-content/uploads/2021/04/square-Steak-and-chips-8.jpg", "Steak with chips" },
                    { "3b3f3188-6d91-4548-b84b-b98048a1952a", "102", 12.5, "https://cf.shopee.vn/file/bacb189db5215ac1f25033d76b6c6add", "Coca" },
                    { "b2d512ac-9bfc-4e6d-a60d-b07974160080", "101", 30.5, "https://www.allrecipes.com/thmb/r29Rv3SakBBaqpbOZu4fHibsf8k=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/236992-santa-maria-grilled-tri-tip-beef-ddmfs-1x1-1-517a088b88a8431c8a41b81c1e978758.jpg", "Santa Maria Grilled Tri-Tip Beef" },
                    { "117f483f-ecb4-4566-88a2-b93bfedad898", "101", 30.5, "https://www.jessicagavin.com/wp-content/uploads/2018/09/fried-rice-8-1200.jpg", "Fried rice" },
                    { "1251d844-4605-4a48-b701-a9b6eb0fe2d8", "102", 13.5, "https://www.pepsi.com/en-us/uploads/images/twil-can.png", "Pepsi" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "100",
                column: "ConcurrencyStamp",
                value: "e454c3d2-b442-4c85-ba42-4824a46ca9e6");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "101",
                column: "ConcurrencyStamp",
                value: "2716e5e2-695b-487a-86e0-46bfe7df2336");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "102",
                column: "ConcurrencyStamp",
                value: "a5ad8008-f501-4ded-806a-f8daaa08f402");

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "IsAvailable", "Name" },
                values: new object[,]
                {
                    { "01c29aad-0ee6-47ce-8fbc-9891902be132", false, "Table 1" },
                    { "8c539ec3-82b0-4154-bfc4-945c132d3450", false, "Table 2" },
                    { "4610b12e-0394-4c74-b059-86392af8ebe3", false, "Table 3" },
                    { "b8968f67-427c-4e25-b688-75b6bd39d8dc", false, "Table 4" },
                    { "8b46b878-0180-417a-8d66-0bff507b99d1", false, "Table 5" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "201",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2282a458-c989-4d6c-909f-ec30fb066faf", "AQAAAAEAACcQAAAAEIg4SOgmKf46LW9NLgc2QGQNFvKFo0fzhuuxVyjIL1f6Y8+Pk8nWLLtrkpjgWiJbaQ==", "d970f365-88dd-4363-b918-64ea9e592c8c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "202",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f24a90d-0164-4957-887a-6d07cc7f0303", "AQAAAAEAACcQAAAAECKkJIqhnweHlKsk9S8QqwoqsoFif3v1pPAVQUJE4k5+Bggd+vwq3DuZmZMUJ9BmFA==", "b79a03d7-b7cb-4197-864f-02bec00d1297" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "203",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce24f610-2635-44bd-bb47-0920b3e72fc7", "AQAAAAEAACcQAAAAEKaOUUnImkBRdY5jejpot+F4VyVP2iOchc1pm+i/7DTJ9lpSnYiQfnOZFvH7jq50MA==", "2bf90adc-a876-44ae-b33d-f5dd34d19623" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "2f879a2f-39f5-44f2-a266-8611177839e7");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "d0753c5f-bfd8-4da5-912c-d7d2888d02cb");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "0726d553-26f3-4791-894b-25c6806780b6");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "117f483f-ecb4-4566-88a2-b93bfedad898");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "1251d844-4605-4a48-b701-a9b6eb0fe2d8");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "2259accd-2a7a-43cc-87b8-eb5b9e2ac854");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "26523f43-715c-47aa-9a0d-9c33a393642d");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "3b3f3188-6d91-4548-b84b-b98048a1952a");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "af660623-c3c9-4c23-b85c-43bfd688a1a8");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "b2d512ac-9bfc-4e6d-a60d-b07974160080");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: "c4d6a25c-e920-42c5-ab15-5b3c62c405e2");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "01c29aad-0ee6-47ce-8fbc-9891902be132");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "4610b12e-0394-4c74-b059-86392af8ebe3");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "8b46b878-0180-417a-8d66-0bff507b99d1");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "8c539ec3-82b0-4154-bfc4-945c132d3450");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: "b8968f67-427c-4e25-b688-75b6bd39d8dc");

            migrationBuilder.DropColumn(
                name: "TableName",
                table: "Bookings");

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
    }
}

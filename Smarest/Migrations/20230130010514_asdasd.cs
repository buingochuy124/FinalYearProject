using Microsoft.EntityFrameworkCore.Migrations;

namespace Smarest.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "128bf57e-b614-481a-a3cb-8dac7019a68c");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "65ca7944-a115-4795-9a7d-5e1eef30d401");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "aa8a4f75-c657-4b53-a1d4-72a6c28f733c");

            migrationBuilder.AlterColumn<double>(
                name: "Cost",
                table: "Items",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "101", "Food" },
                    { "102", "Drink" },
                    { "103", "Other" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "100",
                column: "ConcurrencyStamp",
                value: "f682b58e-87c1-4a16-8494-36ff1ce2b207");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "101",
                column: "ConcurrencyStamp",
                value: "23d97792-ef8a-4ace-943a-1f818a0d13bb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "102",
                column: "ConcurrencyStamp",
                value: "2392f7bf-b1aa-4631-a6b2-7060d5470f38");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "201",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ac64e8a-d9a3-4a98-808a-3cd21949b592", "AQAAAAEAACcQAAAAEN6118eADqCvBwqBWo468odSgmAxvWbSus+YzMJKwYcxdNm57IX5uwm5p9xFWcXaCw==", "fc742924-1566-4574-a0ac-2e69557a9dbc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "202",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fa3665f-8313-4a4b-8b36-0db928445275", "AQAAAAEAACcQAAAAECy4jAgEJBib/SF9HKSG3uCPWOwbB9yjvkimGDnCGDm/w4tkHeYV4PkzbZDUKyPjdA==", "02eba6f9-a706-4888-99b9-4ea774ec1225" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "203",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc830ddc-eb87-403d-86dd-b3b315f24829", "AQAAAAEAACcQAAAAEJOL69eOmvjy6tTOOoEXI5OqKacC8RhqmX8YGok7XZIPbKQsR6MN7uVE3u66oXee4g==", "bebd301a-d860-4059-a055-802ad9cff9dc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "101");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "102");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "103");

            migrationBuilder.AlterColumn<float>(
                name: "Cost",
                table: "Items",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "128bf57e-b614-481a-a3cb-8dac7019a68c", "Food" },
                    { "65ca7944-a115-4795-9a7d-5e1eef30d401", "Drink" },
                    { "aa8a4f75-c657-4b53-a1d4-72a6c28f733c", "Other" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "100",
                column: "ConcurrencyStamp",
                value: "ff672733-0c7b-438c-af04-2b3d092785d2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "101",
                column: "ConcurrencyStamp",
                value: "c2bac172-b000-4d5c-a632-8ae1ab3e025f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "102",
                column: "ConcurrencyStamp",
                value: "5b1b9544-75a0-475b-a326-7a26a644b3d5");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "201",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f845b19-a90e-471f-9604-a44a473dbdae", "AQAAAAEAACcQAAAAEOTsdsZOUNIcpaSQeKF5rV0kXBRFh0lmFH4lxmyQ4SMYaPQWh7YKhvp1FplaXPvCww==", "772e9668-ca29-48da-9aad-b476db6d0e9e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "202",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61c9805d-d18c-4101-8e1b-b84c409f1073", "AQAAAAEAACcQAAAAENw8CI6MqNNCIaS15A1T1kNRjgzWTOLir/9HedQkZ2ZhwqHFuYD9KiFLizYOrP8o1w==", "a7a12254-86a2-4c0b-bec6-679723b2a772" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "203",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bb8206c-8e08-4b26-859f-a8dcc1b8e234", "AQAAAAEAACcQAAAAEJvZimkplrgl0sVoeqt9xrLTwF40R95xelVKhMKbs/84BLWH0AcVXzNjTTxPq54r1w==", "cf0ee07f-658b-4b9b-add4-b3e75ddfe5bc" });
        }
    }
}

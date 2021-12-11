using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep_BackEnd.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChangePassword",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "1",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 9, 18, 53, 20, 659, DateTimeKind.Local).AddTicks(5536), new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(6408) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "2",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7016), new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7025) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "3",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7030), new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7032) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "4",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7035), new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "5",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7040), new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7042) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "6",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7046), new DateTime(2021, 12, 9, 18, 53, 20, 661, DateTimeKind.Local).AddTicks(7047) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangePassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "1",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 4, 18, 5, 1, 931, DateTimeKind.Local).AddTicks(7269), new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7348) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "2",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7922), new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "3",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7935), new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7937) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "4",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7940), new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7942) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "5",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7945), new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7947) });

            migrationBuilder.UpdateData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "6",
                columns: new[] { "CreateTime", "UpdateTime" },
                values: new object[] { new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7950), new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7952) });
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep_BackEnd.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "3d810b20-fa75-4636-a9ac-b3ffb85da5ce");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "4fdf1bd9-1262-4df2-b918-a4254d424959");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "c6e99714-342c-4cd5-9cf7-ff1f333e6593");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "23e0ae97-3aff-4231-9d87-13b93386ff95", "95", "4dddfeb4-b7de-4206-840e-51128364cd7e", false, "1", new DateTime(2021, 12, 22, 20, 13, 32, 624, DateTimeKind.Local).AddTicks(3558), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, false, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 22, 20, 13, 32, 627, DateTimeKind.Local).AddTicks(6206), "a9c2975b-9ad0-41f1-8f49-797202bac932" });

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "26418070-48de-445a-a527-bcdcdf82f5ee", "95", "4dddfeb4-b7de-4206-840e-51128364cd7e", false, "1", new DateTime(2021, 12, 22, 20, 13, 32, 627, DateTimeKind.Local).AddTicks(7079), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, false, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 22, 20, 13, 32, 627, DateTimeKind.Local).AddTicks(7089), "a9c2975b-9ad0-41f1-8f49-797202bac932" });

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "25a794aa-9d0a-41ae-820f-4f00b509fa41", "95", "1e6eb4b9-f1c3-40d2-bbef-0cd34477efa4", false, "2", new DateTime(2021, 12, 22, 20, 13, 32, 627, DateTimeKind.Local).AddTicks(7100), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, false, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 22, 20, 13, 32, 627, DateTimeKind.Local).AddTicks(7102), "a9c2975b-9ad0-41f1-8f49-797202bac932" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "23e0ae97-3aff-4231-9d87-13b93386ff95");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "25a794aa-9d0a-41ae-820f-4f00b509fa41");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "26418070-48de-445a-a527-bcdcdf82f5ee");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "orders");

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "4fdf1bd9-1262-4df2-b918-a4254d424959", "95", "4dddfeb4-b7de-4206-840e-51128364cd7e", false, "1", new DateTime(2021, 12, 18, 15, 22, 10, 797, DateTimeKind.Local).AddTicks(9558), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, false, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 18, 15, 22, 10, 799, DateTimeKind.Local).AddTicks(6549), "a9c2975b-9ad0-41f1-8f49-797202bac932" });

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "c6e99714-342c-4cd5-9cf7-ff1f333e6593", "95", "4dddfeb4-b7de-4206-840e-51128364cd7e", false, "1", new DateTime(2021, 12, 18, 15, 22, 10, 799, DateTimeKind.Local).AddTicks(7804), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, false, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 18, 15, 22, 10, 799, DateTimeKind.Local).AddTicks(7816), "a9c2975b-9ad0-41f1-8f49-797202bac932" });

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "3d810b20-fa75-4636-a9ac-b3ffb85da5ce", "95", "1e6eb4b9-f1c3-40d2-bbef-0cd34477efa4", false, "2", new DateTime(2021, 12, 18, 15, 22, 10, 799, DateTimeKind.Local).AddTicks(7845), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, false, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 18, 15, 22, 10, 799, DateTimeKind.Local).AddTicks(7847), "a9c2975b-9ad0-41f1-8f49-797202bac932" });
        }
    }
}

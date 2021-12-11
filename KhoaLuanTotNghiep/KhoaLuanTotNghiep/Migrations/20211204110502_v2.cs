using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep_BackEnd.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[,]
                {
                    { "1", "95", 1, "1", new DateTime(2021, 12, 4, 18, 5, 1, 931, DateTimeKind.Local).AddTicks(7269), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, 1, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7348), "6b9d189f-011a-438b-9477-1b01e78d160d" },
                    { "2", "95", 1, "1", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7922), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, 1, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7930), "6b9d189f-011a-438b-9477-1b01e78d160d" },
                    { "3", "95", 1, "2", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7935), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, 1, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7937), "6b9d189f-011a-438b-9477-1b01e78d160d" },
                    { "4", "95", 1, "2", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7940), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, 1, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7942), "6b9d189f-011a-438b-9477-1b01e78d160d" },
                    { "5", "95", 1, "3", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7945), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg", "50 Lê Lợi", "19 tỷ", null, 1, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7947), "6b9d189f-011a-438b-9477-1b01e78d160d" },
                    { "6", "95", 1, "3", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7950), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg", "50 Lê Lợi", "19 tỷ", null, 1, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 4, 18, 5, 1, 932, DateTimeKind.Local).AddTicks(7952), "6b9d189f-011a-438b-9477-1b01e78d160d" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "6");
        }
    }
}

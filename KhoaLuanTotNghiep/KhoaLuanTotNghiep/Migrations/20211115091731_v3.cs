using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep_BackEnd.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Slug", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[,]
                {
                    { "1", "95", 1, "1", new DateTime(2021, 11, 15, 16, 17, 30, 163, DateTimeKind.Local).AddTicks(7510), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(7554), "bd9881d1-e1ca-4e45-a8d0-b67ca20eeadd" },
                    { "2", "95", 1, "1", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8141), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8149), "bd9881d1-e1ca-4e45-a8d0-b67ca20eeadd" },
                    { "3", "95", 1, "2", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8155), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8157), "bd9881d1-e1ca-4e45-a8d0-b67ca20eeadd" },
                    { "4", "95", 1, "2", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8161), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8163), "bd9881d1-e1ca-4e45-a8d0-b67ca20eeadd" },
                    { "5", "95", 1, "3", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8167), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8168), "bd9881d1-e1ca-4e45-a8d0-b67ca20eeadd" },
                    { "6", "95", 1, "3", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8172), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 15, 16, 17, 30, 164, DateTimeKind.Local).AddTicks(8174), "bd9881d1-e1ca-4e45-a8d0-b67ca20eeadd" }
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

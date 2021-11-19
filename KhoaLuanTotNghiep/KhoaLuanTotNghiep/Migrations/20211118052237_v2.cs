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
                columns: new[] { "RealEstateID", "Acgreage", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Slug", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[,]
                {
                    { "1", "95", 1, "1", new DateTime(2021, 11, 18, 12, 22, 36, 334, DateTimeKind.Local).AddTicks(6604), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(8626), "4b200c0b-b637-4ff9-9f6a-8c98231bf12f" },
                    { "2", "95", 1, "1", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9420), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9429), "4b200c0b-b637-4ff9-9f6a-8c98231bf12f" },
                    { "3", "95", 1, "2", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9436), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9438), "4b200c0b-b637-4ff9-9f6a-8c98231bf12f" },
                    { "4", "95", 1, "2", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9443), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9445), "4b200c0b-b637-4ff9-9f6a-8c98231bf12f" },
                    { "5", "95", 1, "3", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9450), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9452), "4b200c0b-b637-4ff9-9f6a-8c98231bf12f" },
                    { "6", "95", 1, "3", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9457), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg", "50 Lê Lợi", "19 tỷ", null, "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US", "Đang Bán", "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 11, 18, 12, 22, 36, 335, DateTimeKind.Local).AddTicks(9459), "4b200c0b-b637-4ff9-9f6a-8c98231bf12f" }
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

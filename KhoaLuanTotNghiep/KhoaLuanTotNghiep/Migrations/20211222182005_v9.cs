using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KhoaLuanTotNghiep_BackEnd.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "realEstates",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "121ace12-7467-4d92-8f79-eefd6b27eed8", "95", "4dddfeb4-b7de-4206-840e-51128364cd7e", false, "1", new DateTime(2021, 12, 23, 1, 20, 2, 918, DateTimeKind.Local).AddTicks(6451), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, 0, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 23, 1, 20, 2, 944, DateTimeKind.Local).AddTicks(7769), "a9c2975b-9ad0-41f1-8f49-797202bac932" });

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "45abcccb-3c20-49ee-b02d-cf703b225ec9", "95", "4dddfeb4-b7de-4206-840e-51128364cd7e", false, "1", new DateTime(2021, 12, 23, 1, 20, 2, 944, DateTimeKind.Local).AddTicks(8941), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png", "50 Lê Lợi", "19 tỷ", null, 0, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 23, 1, 20, 2, 944, DateTimeKind.Local).AddTicks(8952), "a9c2975b-9ad0-41f1-8f49-797202bac932" });

            migrationBuilder.InsertData(
                table: "realEstates",
                columns: new[] { "RealEstateID", "Acgreage", "AdminID", "Approve", "CategoryID", "CreateTime", "Description", "Image", "Location", "Price", "ReportID", "Status", "Title", "UpdateTime", "UserID" },
                values: new object[] { "de4bacbb-043c-4802-9933-c2c9a2761db3", "95", "1e6eb4b9-f1c3-40d2-bbef-0cd34477efa4", false, "2", new DateTime(2021, 12, 23, 1, 20, 2, 944, DateTimeKind.Local).AddTicks(8978), "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park", "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png", "50 Lê Lợi", "19 tỷ", null, 0, "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT", new DateTime(2021, 12, 23, 1, 20, 2, 944, DateTimeKind.Local).AddTicks(8981), "a9c2975b-9ad0-41f1-8f49-797202bac932" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "121ace12-7467-4d92-8f79-eefd6b27eed8");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "45abcccb-3c20-49ee-b02d-cf703b225ec9");

            migrationBuilder.DeleteData(
                table: "realEstates",
                keyColumn: "RealEstateID",
                keyValue: "de4bacbb-043c-4802-9933-c2c9a2761db3");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "realEstates",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}

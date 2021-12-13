using KhoaLuanTotNghiep_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuanTotNghiep_BackEnd.Data.SeedData
{
    public static class RealEstateDataInitializer
    {
        public static void SeedRealEstateData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealEstate>().HasData(
                new RealEstate
                {
                    RealEstateID = Guid.NewGuid().ToString(),
                    UserID = "a9c2975b-9ad0-41f1-8f49-797202bac932",
                    AdminID = "4dddfeb4-b7de-4206-840e-51128364cd7e",
                    CategoryID = "1",
                    Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                    Price = "19 tỷ",
                    Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png",
                    Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                    Acgreage = "95",
                    Approve = false,
                    Status = false,
                    Location = "50 Lê Lợi",
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                },
                new RealEstate
                {
                    RealEstateID = Guid.NewGuid().ToString(),
                    UserID = "a9c2975b-9ad0-41f1-8f49-797202bac932",
                    AdminID = "4dddfeb4-b7de-4206-840e-51128364cd7e",
                    CategoryID = "1",
                    Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                    Price = "19 tỷ",
                    Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png",
                    Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                    Acgreage = "95",
                    Approve = false,
                    Status = false,
                    Location = "50 Lê Lợi",
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                },
                new RealEstate
                {
                    RealEstateID = Guid.NewGuid().ToString(),
                    UserID = "a9c2975b-9ad0-41f1-8f49-797202bac932",
                    AdminID = "1e6eb4b9-f1c3-40d2-bbef-0cd34477efa4",
                    CategoryID = "2",
                    Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                    Price = "19 tỷ",
                    Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png",
                    Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                    Acgreage = "95",
                    Approve = false,
                    Status = false,
                    Location = "50 Lê Lợi",
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                }
                //new RealEstate
                //{
                //    RealEstateID = "4",
                //    UserID = "6b9d189f-011a-438b-9477-1b01e78d160d",
                //    CategoryID = "2",
                //    Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                //    Price = "19 tỷ",
                //    Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png",
                //    Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                //    Acgreage = "95",
                //    Approve = false,
                //    Status = false,
                //    Location = "50 Lê Lợi",
                //    CreateTime = DateTime.Now,
                //    UpdateTime = DateTime.Now,
                //},
                //new RealEstate
                //{
                //    RealEstateID = "5",
                //    UserID = "6b9d189f-011a-438b-9477-1b01e78d160d",
                //    CategoryID = "3",
                //    Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                //    Price = "19 tỷ",
                //    Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg",
                //    Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                //    Acgreage = "95",
                //    Approve = false,
                //    Status = false,
                //    Location = "50 Lê Lợi",
                //    CreateTime = DateTime.Now,
                //    UpdateTime = DateTime.Now,
                //},
                //new RealEstate
                //{
                //    RealEstateID = "6",
                //    UserID = "6b9d189f-011a-438b-9477-1b01e78d160d",
                //    CategoryID = "3",
                //    Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                //    Price = "19 tỷ",
                //    Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg",
                //    Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                //    Acgreage = "95",
                //    Approve = false,
                //    Status = false,
                //    Location = "50 Lê Lợi",
                //    CreateTime = DateTime.Now,
                //    UpdateTime = DateTime.Now,
                //}
            );
        }
    }
}

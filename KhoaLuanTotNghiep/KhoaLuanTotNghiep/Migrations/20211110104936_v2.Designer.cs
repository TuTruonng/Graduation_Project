﻿// <auto-generated />
using System;
using KhoaLuanTotNghiep.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KhoaLuanTotNghiep_BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211110104936_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.Category", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.News", b =>
                {
                    b.Property<string>("NewsID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NewsID");

                    b.HasIndex("UserID");

                    b.ToTable("news");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.Rates", b =>
                {
                    b.Property<int>("IDRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RealEstateID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("IDRate");

                    b.ToTable("rates");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.RealEstate", b =>
                {
                    b.Property<string>("RealEstateID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Acgreage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Approve")
                        .HasColumnType("int");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReportID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RealEstateID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("realEstates");

                    b.HasData(
                        new
                        {
                            RealEstateID = "1",
                            Acgreage = "95",
                            Approve = 1,
                            CategoryID = "1",
                            CreateTime = new DateTime(2021, 11, 10, 17, 49, 34, 742, DateTimeKind.Local).AddTicks(162),
                            Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                            Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png",
                            Location = "50 Lê Lợi",
                            Price = "19 tỷ",
                            Slug = "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US",
                            Status = "Đang Bán",
                            Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                            UpdateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(529),
                            UserID = "9ccb5f39-7b81-47fa-a1cd-2e18d1ad7a8b"
                        },
                        new
                        {
                            RealEstateID = "2",
                            Acgreage = "95",
                            Approve = 1,
                            CategoryID = "1",
                            CreateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1945),
                            Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                            Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634380024/leduyen/rv7lrwnztkzvnzrqltha.png",
                            Location = "50 Lê Lợi",
                            Price = "19 tỷ",
                            Slug = "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US",
                            Status = "Đang Bán",
                            Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                            UpdateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1968),
                            UserID = "9ccb5f39-7b81-47fa-a1cd-2e18d1ad7a8b"
                        },
                        new
                        {
                            RealEstateID = "3",
                            Acgreage = "95",
                            Approve = 1,
                            CategoryID = "2",
                            CreateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1974),
                            Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                            Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png",
                            Location = "50 Lê Lợi",
                            Price = "19 tỷ",
                            Slug = "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US",
                            Status = "Đang Bán",
                            Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                            UpdateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1976),
                            UserID = "9ccb5f39-7b81-47fa-a1cd-2e18d1ad7a8b"
                        },
                        new
                        {
                            RealEstateID = "4",
                            Acgreage = "95",
                            Approve = 1,
                            CategoryID = "2",
                            CreateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1980),
                            Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                            Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379964/leduyen/p9zypdbshv8spvwl0m0o.png",
                            Location = "50 Lê Lợi",
                            Price = "19 tỷ",
                            Slug = "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US",
                            Status = "Đang Bán",
                            Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                            UpdateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1982),
                            UserID = "9ccb5f39-7b81-47fa-a1cd-2e18d1ad7a8b"
                        },
                        new
                        {
                            RealEstateID = "5",
                            Acgreage = "95",
                            Approve = 1,
                            CategoryID = "3",
                            CreateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1986),
                            Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                            Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg",
                            Location = "50 Lê Lợi",
                            Price = "19 tỷ",
                            Slug = "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US",
                            Status = "Đang Bán",
                            Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                            UpdateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1988),
                            UserID = "9ccb5f39-7b81-47fa-a1cd-2e18d1ad7a8b"
                        },
                        new
                        {
                            RealEstateID = "6",
                            Acgreage = "95",
                            Approve = 1,
                            CategoryID = "3",
                            CreateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1991),
                            Description = "Bảng giá các căn giá tốt nhất thị trường của dự án The Manor Central Park: Mua trực tiếp chủ đầu tư Bitexco Group.Bảng hàng shophouse các căn vị trí đẹp của giai đoạn 1 và giai đoạn 2 của dự án The Manor Central Park",
                            Image = "https://res.cloudinary.com/dusq8k6rj/image/upload/v1634379264/leduyen/mmgcl8rhah6i2nzfuef3.jpg",
                            Location = "50 Lê Lợi",
                            Price = "19 tỷ",
                            Slug = "https://www.google.com/maps/place/20%C2%B058'31.1%22N+105%C2%B048'51.7%22E/@20.975292,105.814369,15z/data=!4m5!3m4!1s0x0:0x0!8m2!3d20.9752922!4d105.8143692?hl=en-US",
                            Status = "Đang Bán",
                            Title = "RA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐTRA HÀNG DÃY SHOPHOUSE CHÂN THÁP TÀI CHÍNH DỰ ÁN THE MANOR CETRAL PARK KINH DOANH CỰC TỐT",
                            UpdateTime = new DateTime(2021, 11, 10, 17, 49, 34, 743, DateTimeKind.Local).AddTicks(1993),
                            UserID = "9ccb5f39-7b81-47fa-a1cd-2e18d1ad7a8b"
                        });
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.Report", b =>
                {
                    b.Property<string>("ReportID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreaeTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealEstateID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpadateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ReportID");

                    b.HasIndex("RealEstateID");

                    b.ToTable("reports");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.Transaction", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Profit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealEstateID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.News", b =>
                {
                    b.HasOne("KhoaLuanTotNghiep_BackEnd.Models.User", "user")
                        .WithMany("news")
                        .HasForeignKey("UserID");

                    b.Navigation("user");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.RealEstate", b =>
                {
                    b.HasOne("KhoaLuanTotNghiep_BackEnd.Models.Category", "category")
                        .WithMany("realEstates")
                        .HasForeignKey("CategoryID");

                    b.HasOne("KhoaLuanTotNghiep_BackEnd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("category");

                    b.Navigation("user");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.Report", b =>
                {
                    b.HasOne("KhoaLuanTotNghiep_BackEnd.Models.RealEstate", null)
                        .WithMany("reports")
                        .HasForeignKey("RealEstateID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KhoaLuanTotNghiep_BackEnd.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KhoaLuanTotNghiep_BackEnd.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KhoaLuanTotNghiep_BackEnd.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KhoaLuanTotNghiep_BackEnd.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.Category", b =>
                {
                    b.Navigation("realEstates");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.RealEstate", b =>
                {
                    b.Navigation("reports");
                });

            modelBuilder.Entity("KhoaLuanTotNghiep_BackEnd.Models.User", b =>
                {
                    b.Navigation("news");
                });
#pragma warning restore 612, 618
        }
    }
}

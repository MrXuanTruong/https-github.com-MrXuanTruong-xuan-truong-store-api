using Microsoft.EntityFrameworkCore;
using Store.Entity.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Entity.Extentions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>()
                .HasData(
                new AccountType
                {
                    AccountTypeId = 1,
                    AccountTypeName = "Supervisor"
                },
                new AccountType
                {
                    AccountTypeId = 2,
                    AccountTypeName = "Saler"
                },
                new AccountType
                {
                    AccountTypeId = 3,
                    AccountTypeName = "Customer"
                }
                //...
                );

            modelBuilder.Entity<Province>()
                .HasData(
                new Province
                {
                    ProvinceId = 1,
                    ProvinceName = "Hồ Chí Minh",  
                }
                //...
                );

            modelBuilder.Entity<District>()
               .HasData(
               new District
               {
                   DistrictId = 1,
                   DistrictName = "Quận 1",
                   ProvinceId = 1,
               }
               //...
               );
            modelBuilder.Entity<Branch>()
                .HasData(
                new Branch
                {
                    BranchId= 1,
                    BranchName = "Hồ Chí Minh",
                },
                new Branch
                {
                    BranchId = 2,
                    BranchName = "Hà Nội",
                }

                );
            modelBuilder.Entity<AccountStatus>()
                .HasData(
                new AccountStatus
                {
                    AccountStatusId = 1,
                    AccountStatusName = "Đang hoạt động",
                },
                new AccountStatus
                {
                    AccountStatusId = 2,
                    AccountStatusName = "Đã nghỉ",
                }

                );

            modelBuilder.Entity<Account>()
                .HasData(
                    new Account
                    {
                        AccountId = 1,
                        Username = "admin",
                        FullName = "Admin",
                        Email = "xuantruongmu98@gmail.com",
                        CreatedBy = null,
                        UpdatedBy = null,
                        DateOfBirth = new DateTime(1998, 8, 20),
                        CreatedDate = DateTime.UtcNow,
                        Phone = "0345286525",
                        Address = "9 District",
                        AccountStatusId=1,
                        AccountTypeId=1,
                        BranchId=1,
                        CreatedByName=null,
                        UpdatedByName=null,
                        UpdatedDate = DateTime.UtcNow,
                        Password = "e10adc3949ba59abbe56e057f20f883e",
                    },
                    new Account
                    {
                        AccountId = 2,
                        Username = "truongit",
                        FullName = "xuantruong",
                        Email = "xuantruongmu98@gmail.com",
                        CreatedBy = null,
                        UpdatedBy = null,
                        DateOfBirth = new DateTime(1998, 8, 20),
                        CreatedDate = DateTime.UtcNow,
                        Phone = "0345286525",
                        Address = "9 District",
                        AccountStatusId = 2,
                        AccountTypeId = 2,
                        BranchId = 2,
                        CreatedByName = null,
                        UpdatedByName = null,
                        UpdatedDate = DateTime.UtcNow,
                        Password = "e10adc3949ba59abbe56e057f20f883e",
                    },
                    new Account
                    {
                        AccountId = 3,
                        Username = "customer",
                        FullName = "Nguyễn Văn A",
                        Email = "nguyenvana@gmail.com",
                        CreatedBy = null,
                        UpdatedBy = null,
                        DateOfBirth = new DateTime(1995, 8, 20),
                        CreatedDate = DateTime.UtcNow,
                        Phone = "0345286525",
                        Address = "Binh Thanh District",
                        AccountStatusId = 1,
                        AccountTypeId = 3,
                        BranchId = 1,
                        CreatedByName = null,
                        UpdatedByName = null,
                        UpdatedDate = DateTime.UtcNow,
                        Password = "e10adc3949ba59abbe56e057f20f883e",
                    }
                );
            
            modelBuilder.Entity<Category>()
                .HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Xe số",
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Xe tay ga",
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Xe côn tay",
                }
                );
            modelBuilder.Entity<ProductBrand>()
                .HasData(
                new ProductBrand
                {
                    ProductBrandId = 1,
                    ProductBrandName = "Honda",
                },
                new ProductBrand
                {
                    ProductBrandId = 2,
                    ProductBrandName = "Yamaha",
                }
                );
           
            modelBuilder.Entity<ProductStatus>()
                .HasData(
                new ProductStatus
                {
                    ProductStatusId = 1,
                    ProductStatusName = "Sẵn sàng giao dịch",
                },
                new ProductStatus
                {
                    ProductStatusId = 2,
                    ProductStatusName = "Chưa thể giao dịch",
                }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductBrandId = 1,
                    Price = 1000,
                    Stock = 100,
                    ViewCount = 50,
                    ProductStatusId = 1,
                    Description = "Mẫu xe số hiện đại bán chạy nhất tháng",
                    CreatedDate = DateTime.UtcNow,
                    ProductName = "Winner"
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 2,
                    ProductBrandId = 2,
                    Price = 1500,
                    Stock = 80,
                    ViewCount = 50,
                    ProductStatusId = 1,
                    Description = "Specification:OK",
                    CreatedDate = DateTime.UtcNow,
                    ProductName = "Air Blade 2020"
                }
                );

            modelBuilder.Entity<Color>()
               .HasData(
               new Color
               {
                   ColorId = 1,
                   ColorName = "Trắng",
               },
               new Color
               {
                   ColorId = 2,
                   ColorName = "Đen",
               }
               );

            modelBuilder.Entity<ProductColor>()
               .HasData(
               new ProductColor
               {
                   ProductColorId = 1,
                   ColorId = 1,
                   ProductId = 1,
                   Price = 1000,
               },
               new ProductColor
               {
                   ProductColorId = 2,
                   ColorId = 2,
                   ProductId = 1,
                   Price = 1200,
               }
               );
            modelBuilder.Entity<ProductBranch>()
               .HasData(
               new ProductBranch
               {
                   ProductBranchId = 1,
                   LocalStock = 50,
                   ProductId = 1,
                   BranchId = 1,
               },
               new ProductBranch
               {
                   ProductBranchId = 2,
                   LocalStock = 40,
                   ProductId = 1,
                   BranchId = 2,
               }
               );

            modelBuilder.Entity<ProductImage>()
                .HasData(
                new ProductImage
                {
                    ProductImageId = 1,
                    ProductImageUrl = "/images/product/hondawaversx.jpg",
                    ProductId = 1
                },
                new ProductImage
                {
                    ProductImageId = 2,
                    ProductImageUrl = "/images/product/hondawaversx.jpg",
                    ProductId = 1
                }
                );

        }
    }
}

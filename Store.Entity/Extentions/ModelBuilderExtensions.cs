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
                        DateOfBirth = new DateTime(1991, 2, 6),
                        CreatedDate = DateTime.UtcNow,
                        Phone = "0345286525",
                        Address = "Quận 9",
                        UpdatedDate = DateTime.UtcNow,
                        Password = "e10adc3949ba59abbe56e057f20f883e",
                    },
                    new Account
                    {
                        AccountId = 2,
                        Username = "locxtit",
                        FullName = "locxtit",
                        Email = "locxtit1@gmail.com",
                        CreatedBy = null,
                        UpdatedBy = null,
                        DateOfBirth = new DateTime(1991, 2, 6),
                        CreatedDate = DateTime.UtcNow,
                        Phone = "0986210955",
                        UpdatedDate = DateTime.UtcNow,
                        Password = "e10adc3949ba59abbe56e057f20f883e",
                    }
                );
        }
    }
}

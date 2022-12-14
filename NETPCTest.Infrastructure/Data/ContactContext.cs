using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NETPCTest.Core.Entities;
using NETPCTest.Infrastructure.Models;

namespace NETPCTest.Infrastructure.Data
{
    public class ContactContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        public ContactContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //to make identityWork
            base.OnModelCreating(builder);
            //i made few of the fields required and email indexed as unique, 
            //i didnt go with it further as i think its out of scope, i will handle
            //validation on front and backend as well. 
            builder.Entity<Contact>(e =>
            {
                e.HasIndex(p => p.Email).IsUnique();
                e.Property(p => p.Email).IsRequired();
                e.Property(p => p.DateOfBirth).IsRequired();
                e.Property(p => p.DateOfBirth).IsRequired();
                e.Property(p => p.FirstName).IsRequired();
            });
            //i choose to seed data this way to make it fasster in development
            // and easier for you to test. I didnt choose IEntityTypeConfiguration
            // because its small project
            builder.Entity<SubCategory>()
                .HasData(
                    new SubCategory
                    {
                        Id = 1,
                        SubCategoryName = "Szefito"
                    },
                    new SubCategory
                    {
                        Id = 2, 
                        SubCategoryName = "Kliencik"
                    },
                    new SubCategory
                        { 
                            Id = 3,
                            SubCategoryName = "Gangster"
                        }
                    );

            builder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        CategoryName = "Prywatny"
                    },
                    new Category
                    {
                        Id = 2,
                        CategoryName = "Inny"
                    },
                    new Category
                    {
                        Id = 3, 
                        CategoryName = "Sluzbowy"
                    });

            builder.Entity<Contact>()
                .HasData(
                    new Contact
                    {
                        Id = 1,
                        CategoryId = 1,
                        DateOfBirth = DateTime.Now,
                        Email = "wooow@o2.pl",
                        FirstName = "Mateusz",
                        LastName = "Szreder",
                        Password = "StrongPassword",
                        PhoneNumber = 795343455,
                    });
        }
    }
}

﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentId");

                    b.Property<string>("Picture");

                    b.Property<string>("Titel");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Comments.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("InsertDate");

                    b.Property<long?>("ParentId");

                    b.Property<long>("ProductId");

                    b.Property<string>("Title");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Entities.Comments.CommentVote", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CommentId");

                    b.Property<string>("UserId");

                    b.Property<int>("Vote");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("CommentId", "UserId")
                        .IsUnique()
                        .HasName("Comment_Vote_Group")
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("CommentVotes");
                });

            modelBuilder.Entity("Entities.Files.DefaultLogo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("CustomerAvatarUrl")
                        .IsRequired();

                    b.Property<string>("Loading")
                        .IsRequired();

                    b.Property<string>("ShopLogoUrl")
                        .IsRequired();

                    b.Property<string>("ShopMainImageUrl")
                        .IsRequired();

                    b.Property<string>("ShopOwnerAvatarUrl")
                        .IsRequired();

                    b.Property<string>("UserAvatarUrl")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Files_DefaultLogos");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerId")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderPaymentType");

                    b.Property<bool?>("PaySucceeded");

                    b.Property<DateTime?>("PaymentDate");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Price");

                    b.Property<bool>("RedirectedToBank");

                    b.Property<int>("TotalAmount");

                    b.Property<int>("TotalDiscount");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.OrderChild", b =>
                {
                    b.Property<long>("Id");

                    b.Property<long>("OrderId");

                    b.Property<int>("OrderStatus");

                    b.Property<string>("SellerId");

                    b.Property<DateTime?>("SendDate");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SellerId");

                    b.ToTable("OrderChildren");
                });

            modelBuilder.Entity("Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ProductId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<decimal>("Discount");

                    b.Property<int?>("Like");

                    b.Property<decimal>("Price");

                    b.Property<int>("SalesNumber");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.ProductCategory", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<long>("ProductId");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount_Of_Punishment_For_Reserving_The_Book");

                    b.Property<decimal>("Amount_Of_Punishment_For_Returning_The_Book");

                    b.Property<int>("BorrowDay");

                    b.Property<int>("ReservCount");

                    b.Property<int>("ReservDay");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Entities.ShopingCart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count");

                    b.Property<long>("ProductId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId", "ProductId")
                        .IsUnique()
                        .HasName("Group1");

                    b.ToTable("ShopingCarts");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar")
                        .HasMaxLength(100);

                    b.Property<string>("BarCode");

                    b.Property<string>("Biography")
                        .HasMaxLength(100);

                    b.Property<decimal>("ChargeAmount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DisplayName")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("IBAN");

                    b.Property<bool>("IsActive");

                    b.Property<DateTimeOffset?>("LastLoginDate");

                    b.Property<double>("Lat");

                    b.Property<double>("Lng");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<decimal>("MarketingAmount");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirm");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<decimal>("SellingAmount");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Entities.UserTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CID");

                    b.Property<DateTime>("InsertDate");

                    b.Property<DateTime?>("PaidDate");

                    b.Property<int>("PaymentState");

                    b.Property<int>("PaymentType");

                    b.Property<long>("Price");

                    b.Property<string>("RRN");

                    b.Property<string>("ReferenceNumber");

                    b.Property<string>("ReservationCode");

                    b.Property<string>("SecurePan");

                    b.Property<string>("State");

                    b.Property<string>("TRACENO");

                    b.Property<int>("Type");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("User_Transactions");
                });

            modelBuilder.Entity("Entities.WalletLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount");

                    b.Property<int>("ChargeOperation");

                    b.Property<int>("ChargeType");

                    b.Property<DateTime>("InsertDate");

                    b.Property<long?>("OrderId");

                    b.Property<string>("UserId");

                    b.Property<long?>("UserTransactionId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserTransactionId");

                    b.ToTable("WalletLogs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Entities.Address", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Entities.Category", b =>
                {
                    b.HasOne("Entities.Category", "Parent")
                        .WithMany("Categories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Entities.Comments.Comment", b =>
                {
                    b.HasOne("Entities.Comments.Comment", "Parent")
                        .WithMany("Comments")
                        .HasForeignKey("ParentId");

                    b.HasOne("Entities.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.Comments.CommentVote", b =>
                {
                    b.HasOne("Entities.Comments.Comment", "Comment")
                        .WithMany("CommentVote")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Entities.Order", b =>
                {
                    b.HasOne("Entities.User", "Customer")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.OrderChild", b =>
                {
                    b.HasOne("Entities.UserTransaction", "UserTransaction")
                        .WithOne("CustomerOrder")
                        .HasForeignKey("Entities.OrderChild", "Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Order", "Order")
                        .WithMany("OrderChilds")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.User", "Seller")
                        .WithMany("SellerOrders")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("Entities.Picture", b =>
                {
                    b.HasOne("Entities.Product")
                        .WithMany("Pictures")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Entities.ProductCategory", b =>
                {
                    b.HasOne("Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.ShopingCart", b =>
                {
                    b.HasOne("Entities.Product", "Product")
                        .WithMany("ShopingCarts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.User", "User")
                        .WithMany("ShopingCarts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Entities.UserTransaction", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Entities.WalletLog", b =>
                {
                    b.HasOne("Entities.Order", "Order")
                        .WithMany("WalletLogs")
                        .HasForeignKey("OrderId");

                    b.HasOne("Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Entities.UserTransaction", "UserTransaction")
                        .WithMany("WalletLogs")
                        .HasForeignKey("UserTransactionId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

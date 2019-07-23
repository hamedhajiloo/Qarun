using Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sepehran.Pooshako.Utilities.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User : IdentityUser, IEntity
    {
        public User()
        {
            CustomUserTokens = new HashSet<CustomUserToken>();
        }
        #region Properties

        #region وضعیت فعال و غیر فعال بودن


        public bool IsDeleted { get; set; }
        public bool Blocked { get; set; }

        public DateTimeOffset? BlockedDatetime { get; set; }

        public int BlockedCount { get; set; } = 0;

        public BlockeType BlockeType { get; set; }
        #endregion



        /// <summary>
        /// بودن می تواند خرید کند True در صورت 
        /// </summary>
        public bool IsCustomer { get; set; }


        /// <summary>
        /// بودن می تواند فروش کند True در صورت 
        /// </summary>
        public bool IsSeller { get; set; }


        /// <summary>
        /// بودن می تواند مبلغ حاصل از بازاریابی را برداشت کند True در صورت 
        /// </summary>
        public bool IsMarketer { get; set; }


        [DisplayName("نام نمایشی")]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [DisplayName("نصویر پروفایل")]
        [StringLength(100)]
        public string Avatar { get; set; }

        [DisplayName("بیوگرافی")]
        [StringLength(100)]
        public string Biography { get; set; }

        
       


        [DisplayName("آخرین ورود")]
        public DateTimeOffset? LastLoginDate { get; set; } = DateTimeOffset.Now;


        [DisplayName("آدرس ها")]
        [EnsureOneElement(ErrorMessage = "حد اقل یک آدرس باید وارد شود")]
        public List<Address> Addresses { get; set; }



        [DisplayName("شهر ها")]
        [EnsureOneElement(ErrorMessage = "حد اقل یک شهر باید وارد شود")]
        public virtual ICollection<UserCity> UserCities { get; set; }



        public double Lat { get; set; }
        public double Long { get; set; }

        /// <summary>
        /// کد شبا
        /// </summary>
        public string IBAN { get; set; }


      
        public string QRCode { get; set; }



        #region مبالغ پولی



        /// <summary>
        /// مبلغ شارژ دستی
        /// </summary>
        public decimal ChargeAmount { get; set; } = 0;


        /// <summary>
        /// مبلغ فروش
        /// </summary>
        public decimal SellingAmount { get; set; } = 0;


        /// <summary>
        /// مبلغ بازاریابی
        /// </summary>
        public decimal MarketingAmount { get; set; } = 0;


        /// <summary>
        /// مقدار بدهی 
        /// </summary>
        public decimal AmountOfDebt { get; set; } = 0;


        public DateTimeOffset? StartDebtDateTime { get; set; }



        #endregion


        public OrderLimitation OrderLimitation { get; set; }


        #endregion Properties

        #region Relations

        public virtual ICollection<Product> Products { get; set; }


        public virtual ICollection<ShopingCart> ShopingCarts { get; set; }


        /// <summary>
        /// سفارشات مشتری
        /// </summary>
        public virtual ICollection<Order> CustomerOrders { get; set; }


        /// <summary>
        /// مشتریان معرفی شده توسط بازاریاب
        /// </summary>
        public virtual ICollection<User> Presented { get; set; }


        [ForeignKey(nameof(Presenter))]
        public string PresenterId { get; set; }
        public virtual User Presenter { get; set; }

        public virtual ICollection<Follower> Followers { get; set; }
        public virtual ICollection<Following> Followings { get; set; }
        public virtual ICollection<CustomUserToken> CustomUserTokens { get; set; }



        /// <summary>
        /// لیست افرادی که این کاربر آن ها را ریپورت کرده است
        /// </summary>
        [InverseProperty("ReporterUser")]
        public virtual ICollection<Report> Reporters { get; set; }


        /// <summary>
        /// لیست افرادی که این کاربر را ریپورت کرده اند
        /// </summary>
        [InverseProperty("ReportedUser")]
        public virtual ICollection<Report> Reporteds { get; set; }



        #endregion
    }

    #region Config

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
        }
    }

    #endregion Config
}
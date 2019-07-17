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
        #region Properties

        [DisplayName("نام نمایشی")]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [DisplayName("نصویر پروفایل")]
        [StringLength(100)]
        public string Avatar { get; set; }

        [DisplayName("بیوگرافی")]
        [StringLength(100)]
        public string Biography { get; set; }

        [DisplayName("وضعیت")]
        public bool IsActive { get; set; } = true;


        [DisplayName("آخرین ورود")]
        public DateTimeOffset? LastLoginDate { get; set; } = DateTimeOffset.Now;

        public bool PhoneNumberConfirm { get; set; } = false;

        [DisplayName("آدرس ها")]
        [EnsureOneElement(ErrorMessage ="حد اقل یک آدرس باید وارد شود")]
        public List<Address> Addresses { get; set; }


        public double Lat { get; set; }
        public double Lng { get; set; }

        /// <summary>
        /// کد شبا
        /// </summary>
        public string IBAN  { get; set; }

        [DisplayName("بارکد")]
        public string BarCode { get; set; }


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


        #endregion Properties

        #region Relations
        public virtual ICollection<ShopingCart> ShopingCarts { get; set; }


        /// <summary>
        /// سفارشات مشتری
        /// </summary>
        public virtual ICollection<Order> CustomerOrders { get; set; }


        /// <summary>
        /// سفارشات فروشنده 
        /// </summary>
        public virtual ICollection<OrderChild> SellerOrders { get; set; }


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
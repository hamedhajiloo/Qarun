using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    /// <summary>
    /// جزئیات سفارش
    /// </summary>
    public class OrderShopDetails : BaseEntity<long>
    {
        
        public long OrderShopId { get; set; }
        public virtual OrderSeller OrderShop { get; set; }

        /// <summary>
        /// فروشنده
        /// </summary>
        [Required]
        public string SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        /// <summary>
        /// محصول
        /// </summary>
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }


        /// <summary>
        /// تعداد
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// تخفیف واحد
        /// </summary>
        public int UnitDiscount { get; set; }

        /// <summary>
        /// مالیات
        /// </summary>
        public float Tax { get; set; }

        /// <summary>
        /// قیمت واحد
        /// </summary>
        public int UnitAmount { get; set; }

        /// <summary>
        /// جمع کل تخفیف
        /// </summary>
        public int TotalDiscount { get; set; }

        /// <summary>
        /// جمع کل مبلغ
        /// </summary>
        public int TotalAmount { get; set; }

        /// <summary>
        /// : قیمت نهایی کل + مالیات - تخفیف 
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// حذف شده
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// تاریخ بروزرسانی
        /// </summary>
        public DateTime LastUpdate { get; set; }
        public float TotalWeight { get; set; }
    }

    #region Config

    public class OrderShopDetailsConfiguration : IEntityTypeConfiguration<OrderShopDetails>
    {
        public void Configure(EntityTypeBuilder<OrderShopDetails> builder)
        {
            builder.HasIndex(c => c.OrderShopId).HasName("Group1");
        }
    }

    #endregion Config
}

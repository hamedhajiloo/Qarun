using Common;
using Entities.Comments;
using Sepehran.Pooshako.Utilities.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Product:BaseEntity<long>
    {


        [DisplayName("عنوان")]
        [Required(ErrorMessage =DataAnotations.EnterMessage)]
        public string Title { get; set; }



        [DisplayName("توضیحات")]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }


        [DisplayName("قیمت")]
        public decimal Price { get; set; }



        [DisplayName("تخفیف")]
        public decimal Discount { get; set; } = 0;

        [DisplayName("تعداد فروش")]
        public int SalesNumber { get; set; } = 0;

        [DisplayName("تصاویر")]
        [EnsureOneElement(ErrorMessage = "حد اقل یک عکس باید ثبت شود"), MaxCount4List(5)]
        public List<Picture> Pictures { get; set; }

        public string SellerId { get; set; }
        public virtual User Seller { get; set; }


        public int Visit { get; set; }


        public List<Comment> Comments { get; set; }

        public virtual ICollection<ShopingCart> ShopingCarts { get; set; }


        public int Like { get; set; } = 0;


        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        
        /// <summary>
        /// سفارشات  
        /// </summary>
        public virtual ICollection<OrderChild> Orders { get; set; }

        public virtual ICollection<ProductHashtag> ProductHashtags { get; set; }

    }
}

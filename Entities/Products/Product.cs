﻿using Common;
using Entities.Comments;
using Sepehran.Pooshako.Utilities.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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



        [DisplayName("قیمت")]
        public decimal Price { get; set; }



        [DisplayName("تخفیف")]
        public decimal Discount { get; set; } = 0;


        public int SalesNumber { get; set; } = 0;

        [DisplayName("تصاویر")]
        [EnsureOneElement(ErrorMessage = "حد اقل یک عکس باید ثبت شود")]
        public List<Picture> Pictures { get; set; }



        public List<Comment> Comments { get; set; }

        public virtual ICollection<ShopingCart> ShopingCarts { get; set; }


        public int? Like { get; set; }


        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
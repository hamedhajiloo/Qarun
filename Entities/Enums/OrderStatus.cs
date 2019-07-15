using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public enum OrderStatus
    {
        [Display(Name = "درانتظار تعیین وضعیت پرداخت")]
        WaitingForPaymentStatus = 0,

        [Display(Name = "درانتظار تأیید فروشنده")]
        WaitingForDealerApproval = 1,

        [Display(Name = "درحال ازسال")]
        Sending = 2,

        [Display(Name = "تحویل شده")]
        Delivered = 3,

        [Display(Name = "لغو شده توسط خریدار")]
        CanceledByCustomer = 4,

        [Display(Name = "عدم تأیید فروشنده")]
        SellerDisapproval = 5,

        [Display(Name = "عدم تحویل")]
        DisapprovedDelivery = 6

    }
}

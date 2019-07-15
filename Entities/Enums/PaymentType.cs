namespace Entities
{
    public enum PaymentType
    {
        /// <summary>
        /// پرداخت آنلاین
        /// </summary>
        OnlinePayment = 1,
        /// <summary>
        /// کارت‌خوان سیار
        /// </summary>
        MobileCardReaderPayment = 2,
        /// <summary>
        /// پرداخت به حساب
        /// </summary>
        PayToAccount = 3,
        /// <summary>
        /// وجه نقد
        /// </summary>
        Cash = 4

    }
}
